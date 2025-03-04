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
    private bool _RUN_LED_State = false;
    private readonly Color _runledOnColor = Color.Lime;
    private readonly Color _runledOffColor = Color.DarkGreen;
    
    private bool _STOP_LED_State = false;
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
        
        // get data
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
        _serialPort.WriteLine(_Transmiter_Content.Text);
        _Transmiter_Content.Text = "";
    }

    private void _SerialPort_DataReceive(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            var data = _serialPort.ReadLine();

            _Receiver_Content.Text = data;
            HandleRunStop(data);
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
            if (!data.Contains("STAR_STAR_STAR_")) return;
            if (!data.Contains("_RATS_RAST_RAST")) return;
            // Handle run and stop
            var n = data.Length;
            switch (data[n -1])
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
        _serialPort.WriteLine("STAR_STAR_STAR_1_RATS_RAST_RAST");
    }
    private void _Stop_K1_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine("STAR_STAR_STAR_2_RATS_RAST_RAST");
    }
    private void _Run_K2_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine("STAR_STAR_STAR_3_RATS_RAST_RAST");
    }
    private void _Stop_K2_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine("STAR_STAR_STAR_4_RATS_RAST_RAST");
    }
    private void _Run_K3_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine("STAR_STAR_STAR_5_RATS_RAST_RAST");
    }
    private void _Stop_K3_Click(object? sender, EventArgs e)
    {
        _serialPort.WriteLine("STAR_STAR_STAR_6_RATS_RAST_RAST");
    }
}