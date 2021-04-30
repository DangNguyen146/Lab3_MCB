using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_UDPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] senBytes = Encoding.ASCII.GetBytes(textBox3.Text.Trim());
            udpClient.Send(senBytes, senBytes.Length, textBox1.Text.Trim(), Int32.Parse(textBox2.Text));
        }
    }
}
