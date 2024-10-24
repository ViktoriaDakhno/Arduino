//Form1.Designer.cs
namespace ESP8266Controller
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxPorts = new ComboBox();
            buttonConnect = new Button();
            buttonLED1 = new Button();
            buttonLED2 = new Button();
            textBoxReceivedData = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(14, 14);
            comboBoxPorts.Margin = new Padding(4, 3, 4, 3);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(140, 23);
            comboBoxPorts.TabIndex = 0;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(162, 14);
            buttonConnect.Margin = new Padding(4, 3, 4, 3);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(88, 27);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonLED1
            // 
            buttonLED1.Location = new Point(14, 45);
            buttonLED1.Margin = new Padding(4, 3, 4, 3);
            buttonLED1.Name = "buttonLED1";
            buttonLED1.Size = new Size(88, 27);
            buttonLED1.TabIndex = 2;
            buttonLED1.Text = "LED 1 ON";
            buttonLED1.UseVisualStyleBackColor = true;
            buttonLED1.Click += buttonLED1_Click;
            // 
            // buttonLED2
            // 
            buttonLED2.Location = new Point(108, 45);
            buttonLED2.Margin = new Padding(4, 3, 4, 3);
            buttonLED2.Name = "buttonLED2";
            buttonLED2.Size = new Size(88, 27);
            buttonLED2.TabIndex = 3;
            buttonLED2.Text = "LED 2 ON";
            buttonLED2.UseVisualStyleBackColor = true;
            buttonLED2.Click += buttonLED2_Click;
            // 
            // textBoxReceivedData
            // 
            textBoxReceivedData.Location = new Point(14, 78);
            textBoxReceivedData.Margin = new Padding(4, 3, 4, 3);
            textBoxReceivedData.Multiline = true;
            textBoxReceivedData.Name = "textBoxReceivedData";
            textBoxReceivedData.ScrollBars = ScrollBars.Vertical;
            textBoxReceivedData.Size = new Size(303, 208);
            textBoxReceivedData.TabIndex = 4;
            textBoxReceivedData.TextChanged += textBoxReceivedData_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 57);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 301);
            Controls.Add(label1);
            Controls.Add(textBoxReceivedData);
            Controls.Add(buttonLED2);
            Controls.Add(buttonLED1);
            Controls.Add(buttonConnect);
            Controls.Add(comboBoxPorts);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "ESP8266 Controller";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonLED1;
        private System.Windows.Forms.Button buttonLED2;
        private System.Windows.Forms.TextBox textBoxReceivedData;
        private Label label1;
    }
}