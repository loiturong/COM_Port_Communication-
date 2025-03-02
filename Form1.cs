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
    private SerialPort _serialPort;
    private System.Windows.Forms.Timer _Timer;
    
    public Form1()
    {
        _serialPort = new SerialPort();
        _serialPort.ReadTimeout = 1000;
        _Timer = new System.Windows.Forms.Timer();
        _Timer.Interval = 2000; // Interval in milliseconds (200 miliseconds)
        
        // Initialize form
        InitializeComponent();
        
        // Get COM ports available:
        GetComPortAvailable();
        
        // get data
        _Timer.Tick += Timer_Tick;
        _Timer.Start(); // Start the timer
        
        // Setup button
        _OPEN_Port.Click += Open_button_Click;
        _CLOSE_Port.Click += _Close_button_click;
        _SEND_Button.Click += _SEND_Button_Click;
    }

    private void GetComPortAvailable()
    {
        String[] Port_names = SerialPort.GetPortNames();
        
        // Push COM ports available to box:
        _COM_Port_box.Items.Clear();
        _COM_Port_box.Items.AddRange(Port_names);
    }

    private void Open_button_Click(object sender, EventArgs e)
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

    private void _Close_button_click(object sender, EventArgs e)
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

    private void _SEND_Button_Click(object sender, EventArgs e)
    {
        _serialPort.WriteLine(_Transmiter_Content.Text);
        _Transmiter_Content.Text = "";
    }
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        // Read data 
        if (_serialPort.IsOpen)
        {
            // Read data
            try
            {
                _Receiver_Content.Text = _serialPort.ReadLine();
            }
            catch (TimeoutException)
            {
                _Receiver_Content.Text = "Timeout Exception.";
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

        }
        else ;
    }
    
    // Close timer when the form is downed
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _Timer.Stop();
        _Timer.Dispose();
        base.OnFormClosing(e);
    }
}