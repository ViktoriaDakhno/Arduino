//Form1.cs
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ESP8266Controller
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
            serialPort.DataReceived += SerialPort_DataReceived;

            RefreshComPorts();
        }

        private void RefreshComPorts()
        {
            comboBoxPorts.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                comboBoxPorts.Items.Add(port);
            }
            if (comboBoxPorts.Items.Count > 0)
            {
                comboBoxPorts.SelectedIndex = 0;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                DisconnectPort();
            }
            else
            {
                ConnectPort();
            }
        }

        private void ConnectPort()
        {
            if (comboBoxPorts.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть COM-порт.");
                return;
            }

            try
            {
                serialPort.PortName = comboBoxPorts.SelectedItem.ToString();
                serialPort.Open();
                buttonConnect.Text = "Відключити";
                comboBoxPorts.Enabled = false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Доступ до порту заборонено. Можливо, \r\nпорт вже використовується іншою програмою або у вас \r\nнедостатньо прав.");
                ClosePortIfOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\"Помилка при відкритті порту: {ex.Message}");
                ClosePortIfOpen();
            }
        }

        private void DisconnectPort()
        {
            ClosePortIfOpen();
            buttonConnect.Text = "Підключити";
            comboBoxPorts.Enabled = true;
        }

        private void ClosePortIfOpen()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void buttonLED1_Click(object sender, EventArgs e)
        {
            SendCommand(buttonLED1.Text == "LED 1 ON" ? "5ON" : "5OFF");
            buttonLED1.Text = buttonLED1.Text == "LED 1 ON" ? "LED 1 OFF" : "LED 1 ON";
        }

        private void buttonLED2_Click(object sender, EventArgs e)
        {
            SendCommand(buttonLED2.Text == "LED 2 ON" ? "4ON" : "4OFF");
            buttonLED2.Text = buttonLED2.Text == "LED 2 ON" ? "LED 2 OFF" : "LED 2 ON";
        }

        private void SendCommand(string command)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"\"Помилка при відправці команди: {ex.Message}");
                    DisconnectPort();
                }
            }
            else
            {
                MessageBox.Show("Порт не відкритий. Будь ласка, \r\nпідключіться до COM-порту.");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                this.Invoke((MethodInvoker)delegate
                {
                    textBoxReceivedData.AppendText(data + Environment.NewLine);
                });
                this.Invoke(new Action(() =>
                {
                    if (data.Contains("ButtonPressed"))
                    {
                        label1.Text = "Кнопка нажата";
                    }
                    else if (data.Contains("ButtonReleased"))
                    {
                        label1.Text = "Кнопка не нажата";
                    }
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Помилка при отриманні даних: {ex.Message}");
                    DisconnectPort();
                });
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePortIfOpen();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void textBoxReceivedData_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

