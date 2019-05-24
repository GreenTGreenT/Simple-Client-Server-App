using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace client_tutorial
{
    public partial class Form1 : Form
    {
        string serverIP = "localhost";
        int port = 8000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient(serverIP, port);
            int byteCount = Encoding.ASCII.GetByteCount(massage.Text);
            byte[] sendData = new byte[byteCount];
            sendData = Encoding.ASCII.GetBytes(massage.Text);
            NetworkStream stream = client.GetStream();
            stream.Write(sendData, 0, sendData.Length);
            stream.Close();
            client.Close();

        }
    }
}
