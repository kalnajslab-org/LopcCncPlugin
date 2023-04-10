using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using PluginReference;

namespace AllenTestPlugin
{
    public class AllenTestPlugin : PluginBase
    {
        private AllenTestConfig configControl;
        private Panel configPanel = null;
        private string LOPCserialNumber;
        private string CNCSerialNumber;
        private double LOPCFlow;
        private double CNCFlow;
        private int daisyChainIndex;

        private AllenTestDataView dataViewControl;
        private Panel dataViewPanel = null;
        private double OPC300, OPC350, OPC400, OPC500, OPC600, OPC800, OPC1000;
        private double OPC1500, OPC2000, OPC2500, OPC3000, OPC4000, OPC5000, OPC6000, OPC10000, OPC16000;
        private double IPump1, IPump2, BatteryV, TPumps;
        private double CNOPC300, CNOPC500, CNOPC700, CNOPC1000, CNOPC3000, CNPump1I, CNPump2I, CNBatteryV, CNSatT, IceT, CNTPumps;
        private int CNOPC300Int, CNOPC500Int, CNOPC700Int, CNOPC1000Int, CNOPC3000Int;

        private Int16 OPC300Int, OPC350Int, OPC400Int, OPC500Int, OPC600Int, OPC800Int, OPC1000Int;
        private Int16 OPC1500Int, OPC2000Int, OPC2500Int, OPC3000Int, OPC4000Int, OPC5000Int, OPC6000Int, OPC10000Int, OPC16000Int;


        //private double UpStreamT, MiddleT, DownStreamT, HeaterBatteryV;
        //private int ValveState;

        /**
         * The name of the plugin's instrument, to be shown in the GUI.  
         */
        override public string InstrumentName { get { return "LOPC+CNC v1.2"; } }

        /**
         * A sentence or two describing the instrument in more detail.  
         */
        override public string InstrumentDescription { get { return "LASP Optical Particle Counter and CNC"; } }

        /**
         * Create and return a Windows Forms Panel containing any setup/configuration/metadata controls required by the plugin instrument.  
         */
        override public Panel GetConfigPanel()
        {
            if (configPanel == null)
            {
                configPanel = new Panel();
                configPanel.AutoSize = true;

                configControl = new AllenTestConfig();
                configPanel.Controls.Add(configControl);
            }

            return configPanel;
        }

        /**
         * After the user has finished entering config values in the GUI and pressed "OK", this method will be called.  
         * The plugin should parse its own config panel controls and store the results.  
         * 
         * @param selectedDaisyChainIndex       The user-selected daisy chain index for this instrument in case multiple duplicate instruments are attached.  
         *                                      A value of 0 means to allow all daisy chain indices, no particular instrument has been selected so there is only one attached.  
         */
        override public void ParseConfigPanel()
        {
            LOPCserialNumber = configControl.LOPCSerialNumber;
            daisyChainIndex = configControl.DaisyChainIndex;
            LOPCFlow = configControl.LOPCFlow;

            CNCSerialNumber = configControl.CNCSerialNumber;
            CNCFlow = configControl.CNCFlow;
        }

        /**
         * Create and return a Windows Forms Panel for displaying real-time data from the plugin's instrument.  The ParsePacket method should update the panel's controls as data comes in.  
         */
        override public Panel GetDataViewPanel()
        {
            if (dataViewPanel == null)
            {
                dataViewPanel = new Panel();
                dataViewPanel.Dock = DockStyle.Fill;

                dataViewControl = new AllenTestDataView();
                dataViewPanel.Controls.Add(dataViewControl);
            }

            return dataViewPanel;
        }

        /**
         * Output XML elements using XmlTextWriter's WriteElementString method for saving any of the plugin instrument's metadata fields in the flight's rawconfig file.  
         * 
         * Do not output any parent/surrounding elements, this will be handled by the calling code.  
         */
        override public void OutputRawconfigXML(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteElementString("LOPCSerialNumber", LOPCserialNumber);
            xmlWriter.WriteElementString("LOPCDaisyChainIndex", daisyChainIndex.ToString());
            xmlWriter.WriteElementString("CNCSerialNumber", LOPCserialNumber);
        }

        /**
         * For reprocessing flights, this method should parse the rawconfig xml file to restore any of the plugin's required metadata fields, and update the config GUI panel.  
         * This should also set the plugin's "Enabled" property if an appropriate xml field is located for the plugin's instrument.  
         */
        override public void ParseRawconfig(string filename)
        {
            XDocument doc = XDocument.Load(filename);

            var serialNumberElements = doc.Descendants("LOPCSerialNumber");
            if (serialNumberElements.Count() > 0)
            {
                LOPCserialNumber = serialNumberElements.First().Value;
                //also update the GUI if possible
                if (configControl != null) configControl.LOPCSerialNumber = LOPCserialNumber;

                //enable this plugin since there is XML data available
                this.Enabled = true;
            }

            var daisyChainIndexElements = doc.Descendants("LOPCDaisyChainIndex");
            daisyChainIndex = 0;
            if (daisyChainIndexElements.Count() > 0)
            {
                daisyChainIndex = int.Parse(daisyChainIndexElements.First().Value);
            }
            //update the GUI
            if (configControl != null) configControl.DaisyChainIndex = daisyChainIndex;
        }

        /**
         * Parse a real-time data packet if it matches the plugin's expected format, and display th e
         * @param packet    The ascii hexadecimal packet as received by SkySonde Server.  
         * @param dateTimeUTC   The UTC date/time (from the computer's system clock) when the packet was received by SkySonde Client.  
         * 
         * This could be (but currently isn't) called from an alternate thread, so maybe use BeginInvoke when updating the data view GUI panel.  
         */

        override public void ParsePacket(string packet, DateTime dateTimeUTC)
        {
            //check the XDATA instrument ID to see if this is our instrument's data packet
            byte instrumentID = Byte.Parse(packet.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            if (instrumentID != 0x3e) return; //self defined ID number for LOPC 
            //if (packet.Length != 48) return; // assuming this includes everything except CR-LF

            //parse the packet's daisy chain index, in case of duplicate instruments
            byte packetDaisyChainIndex = Byte.Parse(packet.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //if the user selected a daisy chain index other than "Any", there are multiple duplicate instruments so skip any packets that don't match our daisy chain index
            if (daisyChainIndex > 0)
            {
                if (packetDaisyChainIndex != daisyChainIndex) return;
            }

            //OPC300, OPC350, OPC400, OPC450, OPC500, OPC600, OPC700, OPC800, OPC900, OPC1000, OPC1250;
            //OPC1500, OPC1750, OPC2000, OPC2500, OPC3000, OPC4000, OPC5000, OPC6000, OPC8000, OPC10000, OPC16000;
            //parse the pressure and temperature values from the XDATA instrument packet

            OPC300Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10, 4));
            OPC350Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 4, 4));
            OPC400Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 8, 4));
            OPC500Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 12, 4));
            OPC600Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 16, 4));
            OPC800Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 20, 4));
            OPC1000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 24, 4));
            OPC1500Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 28, 2));
            OPC2000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 30, 2));
            OPC2500Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 32, 2));
            OPC3000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 34, 2));
            OPC4000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 36, 2));
            OPC5000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 38, 2));
            OPC6000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 40, 2));
            OPC10000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 42, 2));
            OPC16000Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 44, 2));
            Int16 TPumpsInt = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 46, 2));
            Int16 IPump1Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 48, 2));
            Int16 IPump2Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 50, 2));
            Int16 VBat_Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 52, 2));

            CNOPC300Int = (UInt16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 54, 4));
            CNOPC500Int = (UInt16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 58, 2));
            CNOPC700Int = (UInt16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 60, 2));
            CNOPC1000Int = (UInt16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 62, 2));
            CNOPC3000Int = (UInt16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 64, 2));
            Int16 CNPump1IInt = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 66, 2));
            Int16 CNPump2IInt = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 68, 2));
            Int16 CNTPumpsInt = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 70, 2));
            Int16 CNVBat_Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 72, 2));
            Int16 SatT_Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 74, 4));
            Int16 IceT_Int = (Int16)PluginHelper.IntFromMSBHexString(packet.Substring(10 + 78, 2));

            OPC16000 = ((double)OPC16000Int) / (LOPCFlow * 1000.0 / 30.0);
            OPC10000 = ((double)OPC10000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC16000;
            OPC6000 = ((double)OPC6000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC10000;
            OPC5000 = ((double)OPC5000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC6000;
            OPC4000 = ((double)OPC4000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC5000;
            OPC3000 = ((double)OPC3000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC4000;
            OPC2500 = ((double)OPC2500Int) / (LOPCFlow * 1000.0 / 30.0) + OPC3000;
            OPC2000 = ((double)OPC2000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC2500;
            OPC1500 = ((double)OPC1500Int) / (LOPCFlow * 1000.0 / 30.0) + OPC2000;
            OPC1000 = ((double)OPC1000Int) / (LOPCFlow * 1000.0 / 30.0) + OPC1500;
            OPC800 = ((double)OPC800Int) / (LOPCFlow * 1000.0 / 30.0) + OPC1000;
            OPC600 = ((double)OPC600Int) / (LOPCFlow * 1000.0 / 30.0) + OPC800;
            OPC500 = ((double)OPC500Int) / (LOPCFlow * 1000.0 / 30.0) + OPC600;
            OPC400 = ((double)OPC400Int) / (LOPCFlow * 1000.0 / 30.0) + OPC500;
            OPC350 = ((double)OPC350Int) / (LOPCFlow * 1000.0 / 30.0) + OPC400;
            OPC300 = ((double)OPC300Int) / (LOPCFlow * 1000.0 / 30.0) + OPC350;


            IPump1 = ((double)IPump1Int) * 4.0;
            IPump2 = ((double)IPump2Int) * 4.0;
            TPumps = ((double)TPumpsInt) - 100.0;
            BatteryV = ((double)VBat_Int) / 10.0;

            CNOPC500Int = CNOPC300Int - CNOPC500Int;
            CNOPC700Int = CNOPC500Int - CNOPC700Int;
            CNOPC1000Int = CNOPC700Int - CNOPC1000Int;
            CNOPC3000Int = CNOPC1000Int - CNOPC3000Int;

            CNOPC300 = (double)CNOPC300Int / (CNCFlow * 1000.0 / 30.0);
            CNOPC500 = (double)CNOPC500Int / (CNCFlow * 1000.0 / 30.0);
            CNOPC700 = (double)CNOPC700Int / (CNCFlow * 1000.0 / 30.0);
            CNOPC1000 = (double)CNOPC1000Int / (CNCFlow * 1000.0 / 30.0);
            CNOPC3000 = (double)CNOPC3000Int / (CNCFlow * 1000.0 / 30.0);
            CNPump1I = (double)CNPump1IInt;
            CNPump2I = (double)CNPump2IInt;
            CNTPumps = (double)CNTPumpsInt - 100.0;
            CNBatteryV = (double)CNVBat_Int / 10.0;
            CNSatT = (double)SatT_Int / 100.0;
            IceT = ((double)IceT_Int / 10.0) - 10.0;

            //update the GUI using the data view control
            dataViewControl.UpdateData(OPC300, OPC350, OPC400, OPC500, OPC600, OPC800, OPC1000,
                OPC1500, OPC2000, OPC2500, OPC3000, OPC4000, OPC5000, OPC6000, OPC10000, OPC16000, IPump1, IPump2, TPumps, BatteryV,
                CNOPC300, CNOPC500, CNOPC700, CNOPC1000, CNOPC3000, CNPump1I, CNPump2I, CNTPumps, CNBatteryV, CNSatT, IceT);
        }


        /**
         * Output instrument metadata lines to the top of the CSV file in the format:
         * name1:, value1
         * name2:, value2
         */
        override public string OutputCSVMetadataLines()
        {
            return string.Format("LOPC Serial Number:, {0:0}, CNC Serial Number:, {1:0}, LOPC Flow:, {2:0.00}, CNC Flow:, {3:0.00},  ", LOPCserialNumber, CNCSerialNumber, LOPCFlow, CNCFlow);
        }

        /**
         * Output CSV header field names for the plugin's output fields.  Please include units in square brackets at the end of the name.  Always start with a leading comma, and finish without a comma.  Example:
         * , fieldname1 [units1], fieldname2 [units2]
         */
        override public string OutputCSVHeaderSegment()
        {
            return ", 300nm [#/2s], 350nm [#/2s], 400nm [#/2s], 500nm [#/2s], 600nm [#/2s], 700nm [#/2s], 800nm [#/2s], 1um [#/2s], 1.5um [#/2s], 2um [#/2s], 2.5um [#/2s], 3um [#/2s], 4um [#/2s], 5um [#/2s], 6um [#/2s], 10um [#/2s], 16um [#/2s], I Pump1 [mA], I Pump2 [mA], T Pump (average) [C], Battery [V], CN 300nm [#/2s], CN 500nm [#/2s], CN 700nm [#/2s], CN 1000 [#/2s], CN 3000 [#/2s], CN Pump1 I [mA],  CN Pump2 I [mA], CN T Pump (Ave) [C], CN Saturator T [C], CN Battery V [V], Ice Jacket [C], ";
        }

        /**
         * Output the plugin's data matching the supplied UTC date time in a partial CSV row.  
         * The resulting string should be comma separated and begin with a comma, like this:
         * ", data1, data2, data3"
         */
        override public string OutputCSVRowSegment(DateTime dateTimeUTC, RadiosondeFields radiosondeFields)
        {
            return string.Format(", {0:0}, {1:0}, {2:0}, {3:0}, {4:0}, {5:0}, {5:0}, {6:0}, {7:0}, {8:0}, {9:0}, {10:0}, {11:0}, {12:0}, {13:0}, {14:0},{15:0}, {16:0.00}, {17:0.00}, {18:0.00}, {19:0.00}, {20:0}, {21:0}, {22:0}, {23:0}, {24:0}, {25:0.00}, {26:0.00}, {27:0.00}, {28:0.00}, {29:0.00}, {30:0.00}, ",
               OPC300Int, OPC350Int, OPC400Int, OPC500Int, OPC600Int, OPC800Int, OPC1000Int,
                OPC1500Int, OPC2000Int, OPC2500Int, OPC3000Int, OPC4000Int, OPC5000Int, OPC6000Int, OPC10000Int, OPC16000Int, IPump1, IPump2, TPumps, BatteryV,
                CNOPC300Int, CNOPC500Int, CNOPC700Int, CNOPC1000Int, CNOPC3000Int, CNPump1I, CNPump2I, CNTPumps, CNSatT, CNBatteryV, IceT);
        }
    }
}
