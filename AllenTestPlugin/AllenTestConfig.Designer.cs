namespace AllenTestPlugin
{
    partial class AllenTestConfig
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FlowTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.multipleInstrumentsControl1 = new PluginReference.MultipleInstrumentsControl();
            this.label1 = new System.Windows.Forms.Label();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CNCFlowTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CNCSerialNumberTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FlowTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.multipleInstrumentsControl1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serialNumberTextBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(405, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOPC Configuration";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // FlowTextBox
            // 
            this.FlowTextBox.Location = new System.Drawing.Point(232, 53);
            this.FlowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FlowTextBox.Name = "FlowTextBox";
            this.FlowTextBox.Size = new System.Drawing.Size(88, 22);
            this.FlowTextBox.TabIndex = 4;
            this.FlowTextBox.TextChanged += new System.EventHandler(this.FlowTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sample Flow Rate [Volume LPM]:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // multipleInstrumentsControl1
            // 
            this.multipleInstrumentsControl1.DaisyChainIndex = 0;
            this.multipleInstrumentsControl1.Location = new System.Drawing.Point(9, 84);
            this.multipleInstrumentsControl1.Margin = new System.Windows.Forms.Padding(5);
            this.multipleInstrumentsControl1.Name = "multipleInstrumentsControl1";
            this.multipleInstrumentsControl1.Size = new System.Drawing.Size(384, 65);
            this.multipleInstrumentsControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Number:";
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(117, 21);
            this.serialNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(160, 22);
            this.serialNumberTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CNCFlowTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CNCSerialNumberTextBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CNC Configuration";
            // 
            // CNCFlowTextBox
            // 
            this.CNCFlowTextBox.Location = new System.Drawing.Point(232, 66);
            this.CNCFlowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CNCFlowTextBox.Name = "CNCFlowTextBox";
            this.CNCFlowTextBox.Size = new System.Drawing.Size(88, 22);
            this.CNCFlowTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sample Flow Rate [Volume LPM]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Serial Number:";
            // 
            // CNCSerialNumberTextBox
            // 
            this.CNCSerialNumberTextBox.Location = new System.Drawing.Point(117, 34);
            this.CNCSerialNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CNCSerialNumberTextBox.Name = "CNCSerialNumberTextBox";
            this.CNCSerialNumberTextBox.Size = new System.Drawing.Size(160, 22);
            this.CNCSerialNumberTextBox.TabIndex = 5;
            // 
            // AllenTestConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllenTestConfig";
            this.Size = new System.Drawing.Size(413, 307);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private PluginReference.MultipleInstrumentsControl multipleInstrumentsControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FlowTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox CNCFlowTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CNCSerialNumberTextBox;
    }
}
