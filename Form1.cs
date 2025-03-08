using System.ComponentModel;

namespace Transceiver;

using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
public partial class Form1 : Form
{
    private readonly SerialPort _serialPort;
    private readonly Color _runledOnColor = Color.Lime;
    private readonly Color _runledOffColor = Color.DarkGreen;
    
    private readonly Color _stopledOnColor = Color.Red;
    private readonly Color _stopledOffColor = Color.DarkRed;

    public Form1()
    {
        _serialPort = new SerialPort();
        _serialPort.ReadTimeout = 1000;
        
        // Initialize form
        InitializeComponent();
        
        // Get COM ports available:
        GetComPortAvailable();
        
        // Refresh COM port select box 
        _COM_Port_box.Click += COM_Port_box_ClickChanged;
        
        // get data
        // _serialPort.DataReceived += _SerialPort_DataReceive;
        _serialPort.DataReceived += _SerialPort_DataReceive;
        
        // Setup button
        _OPEN_Port.Click += Open_button_Click;
        _CLOSE_Port.Click += _Close_button_click;
        _SEND_Button.Click += _SEND_Button_Click;
        
        _RUN_1.Click += _Run_K1_Click;
        _RUN_2.Click += _Run_K2_Click;
        _RUN_3.Click += _Run_K3_Click;
        _STOP_1.Click += _Stop_K1_Click;
        _STOP_2.Click += _Stop_K2_Click;
        _STOP_3.Click += _Stop_K3_Click;
    }

    private void COM_Port_box_ClickChanged(object? sender, EventArgs e)
    {
        // Get COM ports available:
        GetComPortAvailable();
    }
    
    private void GetComPortAvailable()
    {
        String[] portNames = SerialPort.GetPortNames();
        
        // Push COM ports available to box:
        _COM_Port_box.Items.Clear();
        _COM_Port_box.Items.AddRange(portNames);
    }

    private void Open_button_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_COM_Port_box.Text == "" || _BanWidth.Text == "")
            {
                MessageBox.Show("Please select a COM port and a ban width.");
            }
            else
            {
                _serialPort.PortName = _COM_Port_box.Text;
                _serialPort.BaudRate = Convert.ToInt32(_BanWidth_box.Text);
                _serialPort.Open();
                
                // Push status
                _StatusBar.Text = "Port Connected";
                
                _CLOSE_Port.Enabled = true;
                _SEND_Button.Enabled = true;
                _Transmiter_Content.Enabled = true;
                _Receiver_Content.Enabled = true;
                _STOP_1.Enabled = true;
                _STOP_2.Enabled = true;
                _STOP_3.Enabled = true;
                _RUN_1.Enabled = true;
                _RUN_2.Enabled = true;
                _RUN_3.Enabled = true;
            }
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Unauthorized access.");
            throw;
        }
    }

    private void _Close_button_click(object? sender, EventArgs e)
    {
        _serialPort.Close();
        
        // clear text box
        _Transmiter_Content.Text = "";
        _Receiver_Content.Text = "";
        
        // Close button
        _SEND_Button.Enabled = false;
        _Transmiter_Content.Enabled = false;
        _Receiver_Content.Enabled = false;
        _CLOSE_Port.Enabled = false;
        _RUN_1.Enabled = false;
        _RUN_2.Enabled = false;
        _RUN_3.Enabled = false;
        _STOP_1.Enabled = false;
        _STOP_2.Enabled = false;
        _STOP_3.Enabled = false;
        
        // update status
        _StatusBar.Text = "Port closed.";
        GetComPortAvailable();
    }

    private void _SEND_Button_Click(object? sender, EventArgs e)
    {
        _serialPort.Write(_Transmiter_Content.Text);
        _Transmiter_Content.Text = "";
    }
    
    private void _SerialPort_DataReceive(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            SerialPort serialPort = (SerialPort)sender;
            while (serialPort.BytesToRead > 0)
            {
                byte[] buffer = new byte[serialPort.BytesToRead];
                int bytesRead = serialPort.Read(buffer, 0, buffer.Length);
                // Handel RunStop
                HandleRunStop(Encoding.ASCII.GetString(buffer));
                // Process buffer
                if (bytesRead > 1)
                {
                    buffer[0] = (byte)(buffer[0] + 1);
                    buffer[bytesRead - 1] = (byte)(buffer[bytesRead - 1] + 1);
                }
                _Receiver_Content.Text = Encoding.ASCII.GetString(buffer);
            }

        }
        catch (TimeoutException)
        {
            _Receiver_Content.Text = "Receive Timeout";
        }
        catch (InvalidOperationException)
        {
            // Handle case where port is closed or invalid
            _Receiver_Content.Text = "Port is closed or invalid";
        }
        catch (IOException)
        {
            // Handle I/O errors (like disconnected device)
            _Receiver_Content.Text = "Communication error - device may be disconnected";
        }

        return;

        void HandleRunStop(string data)
        {
            if (data.Length != 1) return;
            switch (data[0])
            {
                case '7': _toggle_run_LED(true);
                    break;
                case '8': _toggle_run_LED(false);
                    break;
                case '9': _toggle_stop_LED(true);
                    break;
                case 'A': _toggle_stop_LED(false);
                    break;
            }
        }
    }

    private void _toggle_run_LED(bool state)
    {
        _LED_Run.BackColor = state ? _runledOnColor : _runledOffColor;
    }
    private void _toggle_stop_LED(bool state)
    {
        _LED_Stop.BackColor = state ? _stopledOnColor : _stopledOffColor;
    }
    private void _Run_K1_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("1");
    }
    private void _Stop_K1_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("2");
    }
    private void _Run_K2_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("3");
    }
    private void _Stop_K2_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("4");
    }
    private void _Run_K3_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("5");
    }
    private void _Stop_K3_Click(object? sender, EventArgs e)
    {
        _serialPort.Write("6");
    }

    private void _ModifiedRead(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            List<byte> buffer = new List<byte>();

            while (_serialPort.BytesToRead > 0)
            {
                int data = _serialPort.ReadByte() - 48;
                buffer.Add((byte)data);
            }
            buffer[0] = (byte)(buffer[0] + 1);
            buffer[buffer.Count - 1] = (byte)(buffer[buffer.Count - 1] + 1);
            
            _Receiver_Content.Text = string.Join("", buffer.ToArray());
        }
        catch (TimeoutException)
        {
            _Receiver_Content.Text = "Receive Timeout";
        }
    }
}