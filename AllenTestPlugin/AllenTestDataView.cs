using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllenTestPlugin
{
    public partial class AllenTestDataView : UserControl
    {
        public AllenTestDataView()
        {
            InitializeComponent();
        }

        private delegate void UpdateDataDelegate(double OPC300, double OPC350, double OPC400, double OPC500, double OPC600, double OPC800,
            double OPC1000, double OPC1500, double OPC2000, double OPC2500, double OPC3000, double OPC4000,
            double OPC5000, double OPC6000, double OPC10000, double OPC16000, double IPump1, double IPump2, double TPumps, double BatteryV,
            double CNOPC300, double CNOPC500, double CNOPC700, double CNOPC1000, double CNOPC3000, double CNPump1I, double CNPump2I, double CNTPumps, double CNBatteryV, double CNSatT, double IceT );
        public void UpdateData(double OPC300, double OPC350, double OPC400, double OPC500, double OPC600, double OPC800,
            double OPC1000, double OPC1500, double OPC2000, double OPC2500, double OPC3000, double OPC4000,
            double OPC5000, double OPC6000, double OPC10000, double OPC16000, double IPump1, double IPump2, double TPumps, double BatteryV,
            double CNOPC300, double CNOPC500, double CNOPC700, double CNOPC1000, double CNOPC3000, double CNPump1I, double CNPump2I, double CNTPumps, double CNBatteryV, double CNSatT, double IceT)
        { 
        
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateDataDelegate(UpdateData), new object[] { OPC300, OPC350, OPC400, OPC500, OPC600, OPC800, OPC1000,
                OPC1500, OPC2000, OPC2500, OPC3000, OPC4000, OPC5000, OPC6000, OPC10000, OPC16000, IPump1, IPump2, TPumps, BatteryV,
                CNOPC300, CNOPC500, CNOPC700, CNOPC1000, CNOPC3000, CNPump1I, CNPump2I, CNTPumps, CNBatteryV, CNSatT, IceT });
            }
            else
            {
                OPC300Label.Text = string.Format("{0:0.000} [#/cc]", OPC300);
                OPC350Label.Text = string.Format("{0:0.000} [#/cc]", OPC350);
                OPC400Label.Text = string.Format("{0:0.000} [#/cc]", OPC400);
                
                OPC500Label.Text = string.Format("{0:0.000} [#/cc]", OPC500);
                OPC600Label.Text = string.Format("{0:0.000} [#/cc]", OPC600);
                OPC800Label.Text = string.Format("{0:0.000} [#/cc]", OPC800);
                OPC1000Label.Text = string.Format("{0:0.000} [#/cc]", OPC1000);
                OPC1500Label.Text = string.Format("{0:0.000} [#/cc]", OPC1500);
                OPC2000Label.Text = string.Format("{0:0.000} [#/cc]", OPC2000);
                OPC2500Label.Text = string.Format("{0:0.000} [#/cc]", OPC2500);
                OPC3000Label.Text = string.Format("{0:0.000} [#/cc]", OPC3000);
                OPC4000Label.Text = string.Format("{0:0.000} [#/cc]", OPC4000);
                OPC5000Label.Text = string.Format("{0:0.000} [#/cc]", OPC5000);
                OPC6000Label.Text = string.Format("{0:0.000} [#/cc]", OPC6000);
                OPC10000Label.Text = string.Format("{0:0.000} [#/cc]", OPC10000);
                OPC16000Label.Text = string.Format("{0:0.000} [#/cc]", OPC16000);
                
                IPump1Label.Text = string.Format("{0:0.00} [mA]", IPump1);
                IPump2Label.Text = string.Format("{0:0.00} [mA]", IPump2);
                TPumpsLabel.Text = string.Format("{0:0.0} [C]", TPumps);
                BatteryVLabel.Text = string.Format("{0:0.00} [V]", BatteryV);

                CN_300nmLabel.Text = string.Format("{0:0.00} [#/cc]", CNOPC300);
                CN_500nmLabel.Text = string.Format("{0:0.00} [#/cc]", CNOPC500);
                CN_700nmLabel.Text = string.Format("{0:0.00} [#/cc]", CNOPC700);
                CN_1000nmLabel.Text = string.Format("{0:0.00} [#/cc]", CNOPC1000);
                CN_3000nmLabel.Text = string.Format("{0:0.00} [#/cc]", CNOPC3000);
                CNPump1ILabel.Text = string.Format("{0:0.00} [mA]", CNPump1I);
                CNPump2ILabel.Text = string.Format("{0:0.00} [mA]", CNPump2I);
                CNTPumpsLabel.Text = string.Format("{0:0.0} [C]", CNTPumps);
                CNBatteryVLabel.Text = string.Format("{0:0.00} [V]", CNBatteryV);
                CNSaturatorTLabel.Text = string.Format("{0:0.00} [C]", CNSatT);
                IceTLabel.Text = string.Format("{0:0.00} [C]", IceT);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void nm500Label_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OPC300Label_Click(object sender, EventArgs e)
        {

        }
    }
}
