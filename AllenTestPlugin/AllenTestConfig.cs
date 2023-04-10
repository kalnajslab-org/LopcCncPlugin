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
    public partial class AllenTestConfig : UserControl
    {
        public int DaisyChainIndex
        {
            get { return multipleInstrumentsControl1.DaisyChainIndex; }
            set { multipleInstrumentsControl1.DaisyChainIndex = value; }
        }

        public string LOPCSerialNumber
        {
            get { return serialNumberTextBox.Text; }
            set { serialNumberTextBox.Text = value; }
        }

        public string CNCSerialNumber
        {
            get { return CNCSerialNumberTextBox.Text; }
            set { CNCSerialNumberTextBox.Text = value; }
        }

        public double LOPCFlow
        {
            get { return double.Parse(FlowTextBox.Text); }
            set { FlowTextBox.Text = FlowTextBox.Text; }
        }

        public double CNCFlow
        {
            get { return double.Parse(CNCFlowTextBox.Text); }
            set { CNCFlowTextBox.Text = CNCFlowTextBox.Text; }
        }

        public AllenTestConfig()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FlowTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
