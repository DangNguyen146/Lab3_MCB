using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_UDPServe
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
           
        }
        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(Int32.Parse(textBox1.Text));
            while (true)
            {
                IPEndPoint RemotelEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemotelEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string mess = RemotelEndPoint.Address.ToString() + ":" + returnData.ToString();
                InfoMessage(mess);
            }
        }
        public void InfoMessage(string mess)
        {
            textBox2.Text += (mess + "\r\n").ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }
    }
}
