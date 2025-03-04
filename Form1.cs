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
    
    public Form1()
    {
        _serialPort = new SerialPort();
        _serialPort.ReadTimeout = 1000;
        
        // Initialize form
        InitializeComponent();
        
        // Get COM ports available:
        GetComPortAvailable();
        
        // get data
        _serialPort.DataReceived += _SerialPort_DataReceive;
        
        // Setup button
        _OPEN_Port.Click += Open_button_Click;
        _CLOSE_Port.Click += _Close_button_click;
        _SEND_Button.Click += _SEND_Button_Click;
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
        
        // update status
        _StatusBar.Text = "Port closed.";
        GetComPortAvailable();
    }

    private void _SEND_Button_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine(_Transmiter_Content.Text);
        _Transmiter_Content.Text = "";
    }

    private void _SerialPort_DataReceive(object sender, SerialDataReceivedEventArgs e)
    {
        void UpdateText(string text)
        {
            // Invoke(new Action(() => {
            //     _Receiver_Content.Text = text;
            // }));

            if (_Receiver_Content.InvokeRequired)
            {
                _Receiver_Content.Invoke((MethodInvoker)(() => _Receiver_Content.Text = text));
            }
            else
            {
                _Receiver_Content.Text = text; // Already on UI thread (unlikely in this case)
            }
        }
        
        try
        {
            var data = _serialPort.ReadLine();

            UpdateText(data);
        }
        catch (TimeoutException)
        {
            UpdateText("Receive Timeout");
        }
        catch (InvalidOperationException)
        {
            // Handle case where port is closed or invalid
            UpdateText("Port is closed or invalid");
        }
        catch (IOException)
        {
            // Handle I/O errors (like disconnected device)
            UpdateText("Communication error - device may be disconnected");
        }
    }
}