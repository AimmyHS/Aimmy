using System;
using System.IO.Ports;
using System.Text;


namespace MouseMovementLibraries.HostShieldSupport
{
    public class ArduinoHostShield
    {
        public ArduinoHostShield() {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            serialPort.PortName = ports[0];
            serialPortName = ports[0];
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.Open();
        }

        public void SendMouseCoordinates(int x, int y)
        {
            if (x != 0 || y != 0)
            {
                string message = $"m{x},{y}";
                byte[] encodedBytes = Encoding.UTF8.GetBytes(message);
                serialPort.Write(Encoding.UTF8.GetString(encodedBytes));
            }
        }

        public void SendMouseClick(int press)
        {
            if(press == 1)
            {
                string message = "p";
            }
            else if(press == 0)
            {
                string message = "r";
            }
            byte[] encodedBytes = Encoding.UTF8.GetBytes(message);
            serialPort.Write(Encoding.UTF8.GetString(encodedBytes));
        }
    }
}