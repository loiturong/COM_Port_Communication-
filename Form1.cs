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
    public Form1()
    {
        // Initialize form
        InitializeComponent();
        
        // Get COM ports available:
        GetComPortAvailable();
    }

    private void GetComPortAvailable()
    {
        string[] Port_names = SerialPort.GetPortNames();
        
        // Push COM ports available to box:
        _COM_Port_box.Items.Clear();
        _COM_Port_box.Items.AddRange(Port_names);
    }
}