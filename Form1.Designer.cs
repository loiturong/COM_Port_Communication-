﻿namespace Transceiver;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _COMPortLabel = new System.Windows.Forms.Label();
        _COM_Port_box = new System.Windows.Forms.ComboBox();
        _BanWidth = new System.Windows.Forms.Label();
        _BanWidth_box = new System.Windows.Forms.ComboBox();
        _OPEN_Port = new System.Windows.Forms.Button();
        _CLOSE_Port = new System.Windows.Forms.Button();
        _StatusBar = new System.Windows.Forms.TextBox();
        _Transmiter = new System.Windows.Forms.GroupBox();
        _Transmiter_Content = new System.Windows.Forms.TextBox();
        _SEND_Button = new System.Windows.Forms.Button();
        _Reciever = new System.Windows.Forms.GroupBox();
        _Receiver_Content = new System.Windows.Forms.TextBox();
        _Controller = new System.Windows.Forms.GroupBox();
        _LED_Stop = new System.Windows.Forms.Panel();
        _LED_Run = new System.Windows.Forms.Panel();
        _RUN_3 = new System.Windows.Forms.Button();
        _RUN_2 = new System.Windows.Forms.Button();
        _RUN_1 = new System.Windows.Forms.Button();
        _STOP_3 = new System.Windows.Forms.Button();
        _STOP_2 = new System.Windows.Forms.Button();
        _STOP_1 = new System.Windows.Forms.Button();
        _K3 = new System.Windows.Forms.Label();
        _K2 = new System.Windows.Forms.Label();
        _K1 = new System.Windows.Forms.Label();
        _Transmiter.SuspendLayout();
        _Reciever.SuspendLayout();
        _Controller.SuspendLayout();
        SuspendLayout();
        // 
        // _COMPortLabel
        // 
        _COMPortLabel.Location = new System.Drawing.Point(25, 25);
        _COMPortLabel.Name = "_COMPortLabel";
        _COMPortLabel.Size = new System.Drawing.Size(100, 25);
        _COMPortLabel.TabIndex = 1;
        _COMPortLabel.Text = "COM Port";
        _COMPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _COM_Port_box
        // 
        _COM_Port_box.FormattingEnabled = true;
        _COM_Port_box.Location = new System.Drawing.Point(25, 60);
        _COM_Port_box.Name = "_COM_Port_box";
        _COM_Port_box.Size = new System.Drawing.Size(88, 23);
        _COM_Port_box.TabIndex = 3;
        // 
        // _BanWidth
        // 
        _BanWidth.Location = new System.Drawing.Point(170, 25);
        _BanWidth.Name = "_BanWidth";
        _BanWidth.Size = new System.Drawing.Size(100, 25);
        _BanWidth.TabIndex = 2;
        _BanWidth.Text = "BAN WIDTH";
        _BanWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _BanWidth_box
        // 
        _BanWidth_box.FormattingEnabled = true;
        _BanWidth_box.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
        _BanWidth_box.Location = new System.Drawing.Point(170, 60);
        _BanWidth_box.Name = "_BanWidth_box";
        _BanWidth_box.Size = new System.Drawing.Size(88, 23);
        _BanWidth_box.TabIndex = 3;
        // 
        // _OPEN_Port
        // 
        _OPEN_Port.Location = new System.Drawing.Point(310, 20);
        _OPEN_Port.Name = "_OPEN_Port";
        _OPEN_Port.Size = new System.Drawing.Size(100, 30);
        _OPEN_Port.TabIndex = 5;
        _OPEN_Port.Text = "OPEN";
        _OPEN_Port.UseVisualStyleBackColor = true;
        // 
        // _CLOSE_Port
        // 
        _CLOSE_Port.Enabled = false;
        _CLOSE_Port.Location = new System.Drawing.Point(310, 56);
        _CLOSE_Port.Name = "_CLOSE_Port";
        _CLOSE_Port.Size = new System.Drawing.Size(100, 30);
        _CLOSE_Port.TabIndex = 5;
        _CLOSE_Port.Text = "CLOSE";
        _CLOSE_Port.UseVisualStyleBackColor = true;
        // 
        // _StatusBar
        // 
        _StatusBar.Location = new System.Drawing.Point(450, 30);
        _StatusBar.Name = "_StatusBar";
        _StatusBar.ReadOnly = true;
        _StatusBar.Size = new System.Drawing.Size(100, 23);
        _StatusBar.TabIndex = 1;
        _StatusBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // _Transmiter
        // 
        _Transmiter.Controls.Add(_Transmiter_Content);
        _Transmiter.Controls.Add(_SEND_Button);
        _Transmiter.Location = new System.Drawing.Point(30, 150);
        _Transmiter.Name = "_Transmiter";
        _Transmiter.Size = new System.Drawing.Size(180, 200);
        _Transmiter.TabIndex = 4;
        _Transmiter.TabStop = false;
        _Transmiter.Text = "Transmiter";
        // 
        // _Transmiter_Content
        // 
        _Transmiter_Content.Enabled = false;
        _Transmiter_Content.Location = new System.Drawing.Point(10, 30);
        _Transmiter_Content.Multiline = true;
        _Transmiter_Content.Name = "_Transmiter_Content";
        _Transmiter_Content.Size = new System.Drawing.Size(160, 120);
        _Transmiter_Content.TabIndex = 5;
        // 
        // _SEND_Button
        // 
        _SEND_Button.Enabled = false;
        _SEND_Button.Location = new System.Drawing.Point(10, 156);
        _SEND_Button.Name = "_SEND_Button";
        _SEND_Button.Size = new System.Drawing.Size(160, 30);
        _SEND_Button.TabIndex = 6;
        _SEND_Button.Text = "SEND";
        _SEND_Button.UseVisualStyleBackColor = true;
        // 
        // _Reciever
        // 
        _Reciever.Controls.Add(_Receiver_Content);
        _Reciever.Location = new System.Drawing.Point(300, 150);
        _Reciever.Name = "_Reciever";
        _Reciever.Size = new System.Drawing.Size(180, 200);
        _Reciever.TabIndex = 4;
        _Reciever.TabStop = false;
        _Reciever.Text = "Transmiter";
        // 
        // _Receiver_Content
        // 
        _Receiver_Content.Enabled = false;
        _Receiver_Content.Location = new System.Drawing.Point(10, 30);
        _Receiver_Content.Multiline = true;
        _Receiver_Content.Name = "_Receiver_Content";
        _Receiver_Content.ReadOnly = true;
        _Receiver_Content.Size = new System.Drawing.Size(160, 150);
        _Receiver_Content.TabIndex = 6;
        // 
        // _Controller
        // 
        _Controller.BackColor = System.Drawing.SystemColors.Control;
        _Controller.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        _Controller.Controls.Add(_LED_Stop);
        _Controller.Controls.Add(_LED_Run);
        _Controller.Controls.Add(_RUN_3);
        _Controller.Controls.Add(_RUN_2);
        _Controller.Controls.Add(_RUN_1);
        _Controller.Controls.Add(_STOP_3);
        _Controller.Controls.Add(_STOP_2);
        _Controller.Controls.Add(_STOP_1);
        _Controller.Controls.Add(_K3);
        _Controller.Controls.Add(_K2);
        _Controller.Controls.Add(_K1);
        _Controller.Location = new System.Drawing.Point(30, 375);
        _Controller.Name = "_Controller";
        _Controller.Size = new System.Drawing.Size(466, 123);
        _Controller.TabIndex = 6;
        _Controller.TabStop = false;
        _Controller.Text = "Monotoring and controlling";
        // 
        // _LED_Stop
        // 
        _LED_Stop.Location = new System.Drawing.Point(406, 66);
        _LED_Stop.Name = "_LED_Stop";
        _LED_Stop.Size = new System.Drawing.Size(43, 35);
        _LED_Stop.TabIndex = 2;
        _LED_Stop.BackColor = _stopledOffColor;
        // 
        // _LED_Run
        // 
        _LED_Run.Location = new System.Drawing.Point(406, 25);
        _LED_Run.Name = "_LED_Run";
        _LED_Run.Size = new System.Drawing.Size(43, 35);
        _LED_Run.TabIndex = 2;
        _LED_Run.BackColor = _runledOffColor;
        // 
        // _RUN_3
        // 
        _RUN_3.Enabled = false;
        _RUN_3.Location = new System.Drawing.Point(275, 60);
        _RUN_3.Name = "_RUN_3";
        _RUN_3.Size = new System.Drawing.Size(50, 25);
        _RUN_3.TabIndex = 1;
        _RUN_3.Text = "RUN";
        _RUN_3.UseVisualStyleBackColor = true;
        // 
        // _RUN_2
        // 
        _RUN_2.Enabled = false;
        _RUN_2.Location = new System.Drawing.Point(150, 60);
        _RUN_2.Name = "_RUN_2";
        _RUN_2.Size = new System.Drawing.Size(50, 25);
        _RUN_2.TabIndex = 1;
        _RUN_2.Text = "RUN";
        _RUN_2.UseVisualStyleBackColor = true;
        // 
        // _RUN_1
        // 
        _RUN_1.Enabled = false;
        _RUN_1.Location = new System.Drawing.Point(25, 60);
        _RUN_1.Name = "_RUN_1";
        _RUN_1.Size = new System.Drawing.Size(50, 25);
        _RUN_1.TabIndex = 1;
        _RUN_1.Text = "RUN";
        _RUN_1.UseVisualStyleBackColor = true;
        // 
        // _STOP_3
        // 
        _STOP_3.Enabled = false;
        _STOP_3.Location = new System.Drawing.Point(331, 60);
        _STOP_3.Name = "_STOP_3";
        _STOP_3.Size = new System.Drawing.Size(50, 25);
        _STOP_3.TabIndex = 1;
        _STOP_3.Text = "STOP";
        _STOP_3.UseVisualStyleBackColor = true;
        // 
        // _STOP_2
        // 
        _STOP_2.Enabled = false;
        _STOP_2.Location = new System.Drawing.Point(206, 60);
        _STOP_2.Name = "_STOP_2";
        _STOP_2.Size = new System.Drawing.Size(50, 25);
        _STOP_2.TabIndex = 1;
        _STOP_2.Text = "STOP";
        _STOP_2.UseVisualStyleBackColor = true;
        // 
        // _STOP_1
        // 
        _STOP_1.Enabled = false;
        _STOP_1.Location = new System.Drawing.Point(81, 60);
        _STOP_1.Name = "_STOP_1";
        _STOP_1.Size = new System.Drawing.Size(50, 25);
        _STOP_1.TabIndex = 1;
        _STOP_1.Text = "STOP";
        _STOP_1.UseVisualStyleBackColor = true;
        // 
        // _K3
        // 
        _K3.BackColor = System.Drawing.SystemColors.Info;
        _K3.Location = new System.Drawing.Point(270, 35);
        _K3.Name = "_K3";
        _K3.Size = new System.Drawing.Size(119, 60);
        _K3.TabIndex = 0;
        _K3.Text = "K3";
        // 
        // _K2
        // 
        _K2.BackColor = System.Drawing.SystemColors.Info;
        _K2.Location = new System.Drawing.Point(145, 35);
        _K2.Name = "_K2";
        _K2.Size = new System.Drawing.Size(119, 60);
        _K2.TabIndex = 0;
        _K2.Text = "K2";
        // 
        // _K1
        // 
        _K1.BackColor = System.Drawing.SystemColors.Info;
        _K1.Location = new System.Drawing.Point(20, 35);
        _K1.Name = "_K1";
        _K1.Size = new System.Drawing.Size(119, 60);
        _K1.TabIndex = 0;
        _K1.Text = "K1";
        // 
        // Form1
        // 
        ClientSize = new System.Drawing.Size(577, 509);
        Controls.Add(_Controller);
        Controls.Add(_COMPortLabel);
        Controls.Add(_COM_Port_box);
        Controls.Add(_BanWidth);
        Controls.Add(_BanWidth_box);
        Controls.Add(_OPEN_Port);
        Controls.Add(_CLOSE_Port);
        Controls.Add(_StatusBar);
        Controls.Add(_Transmiter);
        Controls.Add(_Reciever);
        Text = "Transceiver Interface";
        _Transmiter.ResumeLayout(false);
        _Transmiter.PerformLayout();
        _Reciever.ResumeLayout(false);
        _Reciever.PerformLayout();
        _Controller.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel _LED_Run;

    private System.Windows.Forms.Panel _LED_Stop;

    private System.Windows.Forms.Label _K2;
    private System.Windows.Forms.Button _STOP_2;
    private System.Windows.Forms.Button _RUN_2;
    
    private System.Windows.Forms.Label _K3;
    private System.Windows.Forms.Button _STOP_3;
    private System.Windows.Forms.Button _RUN_3;

    private System.Windows.Forms.Button _STOP_1;
    private System.Windows.Forms.Button _RUN_1;
    private System.Windows.Forms.Label _K1;

    private System.Windows.Forms.GroupBox _Controller;

    private System.Windows.Forms.TextBox _Receiver_Content;
    private System.Windows.Forms.GroupBox _Reciever;
    private System.Windows.Forms.Button _SEND_Button;
    private System.Windows.Forms.TextBox _Transmiter_Content;
    private System.Windows.Forms.GroupBox _Transmiter;

    private System.Windows.Forms.TextBox _StatusBar;
    private System.Windows.Forms.Button _CLOSE_Port;
    private System.Windows.Forms.Button _OPEN_Port;
    private System.Windows.Forms.ComboBox _BanWidth_box;
    private System.Windows.Forms.Label _BanWidth;
    private System.Windows.Forms.ComboBox _COM_Port_box;
    private System.Windows.Forms.Label _COMPortLabel;

    #endregion
}