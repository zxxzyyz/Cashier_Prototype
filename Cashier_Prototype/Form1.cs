using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cashier_Prototype.Commands;

namespace Cashier_Prototype
{
    public partial class Form1 : Form
    {
        public SericalComm Port { get; set; } = new SericalComm();

        public Form1()
        {
            InitializeComponent();
            axOPOSCashChanger1.BeginDeposit();
            Port.Open(textBox1.Text, 9600);
            var a = new Cmd35();
            //a.SetData(Cmd56.Cmd35Format.TwentyBytes,2,2,2,2,2,2,2);
            //a.SetData(Cmd52.Cm52Config.CloseProcess, "11112222");
            //a.SetData(Cmd3C.Cmd3CConfig.Get);
            //var i = 0;
            //while(true)
            //{
            //    a.SetData(i);
            //    Port.Send(a.ToFrame());
            //    i++;
            //    System.Threading.Thread.Sleep(100);
            //    if (i > 100) return;
            //    if (Port.serialPort.BytesToRead > 1)
            //    {
            //        int bytes = Port.serialPort.BytesToRead;
            //        byte[] buffer = new byte[bytes];
            //        Port.serialPort.Read(buffer, 0, bytes);
            //        Console.WriteLine(buffer.ToHexString());
            //    }
            //}
            var b = new Cmd30();
            //System.Threading.Thread.Sleep(100);
            //Port.Send(new Cmd47().ToFrame());
            //System.Threading.Thread.Sleep(100);
            //Port.Send(new Cmd46().ToFrame());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(true)
            {
                var a = new Cmd3B();
                a.SetData(1);
                Port.Send(a.ToFrame());

                System.Threading.Thread.Sleep(100);

                int bytes = Port.serialPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                Port.serialPort.Read(buffer, 0, bytes);
                Console.WriteLine(buffer.ToHexString());

                System.Threading.Thread.Sleep(400);
            }
            //var a = new Cmd35();
            //a.SetData(Cmd35.Cmd35Format.TwelveBytes, 1, 1, 1, 1, 1, 1);
            //Port.Send(a.ToFrame());
            //return;
            //var b = new Cmd31();
            //b.SetData("00999");
            //Port.Send(b.ToFrame());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var c1 = new Cmd35();
            //c1.SetData("210407000102");
            c1.SetData(Cmd35.Cmd35Format.TwentyBytes, 1, 1, 1, 1, 1, 1, 1);
            var d1 = c1.ToFrame();
            var c2 = new Cmd4C();
            c2.SetData(Cmd4C.Cmd4CConfig.Lock);
            var d2 = c2.ToFrame();
            var c3 = new Cmd50();
            c3.SetData(Cmd50.Cmd50Config.Permit);
            var d3 = c3.ToFrame();
            var test = new Cmd35();
            Port.Send(c1.ToFrame());
            //Port.Send(d1);
            //Port.Send(d2);
            //Port.Send(d3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Port.Receive();
        }
    }
}
