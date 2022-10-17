using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier_Prototype
{
    public class SericalComm
    {
        public SerialPort serialPort = new SerialPort();

        public SericalComm()
        {
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        public bool Open(string portNumber, int baudRate)
        {
            try
            {
                if (serialPort.IsOpen) serialPort.Close();
                serialPort.PortName = portNumber;
                serialPort.BaudRate = baudRate;
                serialPort.DataBits = 7;
                serialPort.Parity = Parity.Even;
                serialPort.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Clear()
        {
            try
            {
                serialPort.ReadExisting();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Send(byte[] data)
        {
            try
            {
                serialPort.Write(data, 0, data.Length);
                Console.WriteLine(data.ToHexString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public byte[] Receive()
        {
            if (serialPort.BytesToRead != 0)
            {
                var temp = new byte[serialPort.BytesToRead];
                serialPort.Read(temp, 0, temp.GetLength(0));
                return temp;
            }
            return new byte[1];
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = serialPort.BytesToRead;
            byte[] buffer = new byte[bytes];
            serialPort.Read(buffer, 0, bytes);
            Console.WriteLine(buffer.ToHexString());
        }
    }
}
