using System;
using System.IO.Ports;
using System.Text;


namespace MouseMovementLibraries.HostShieldSupport
{
    public class ArduinoHostShield
    {
        public ArduinoHostShield() { }

        private SerialPort serialPort = new SerialPort();
        private bool Open = false;

        public void StartArduinoMouse()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            serialPort.PortName = ports[0];
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.Open();
            Open = true;
        }

        public void SendMouseCoordinates(int x, int y)
        {
            if (!Open) StartArduinoMouse();
            if (x != 0 || y != 0)
            {
                string message = $"m{x},{y}\n";
                byte[] encodedBytes = Encoding.UTF8.GetBytes(message);
                serialPort.Write(Encoding.UTF8.GetString(encodedBytes));
            }
        }

        public void SendMouseClick(int press)
        {
            if (!Open) StartArduinoMouse();
            string message = "r\n";
            if(press == 1)
            {
                message = "p\n";
            }
            else
            {
                message = "r\n";
            }
            byte[] encodedBytes = Encoding.UTF8.GetBytes(message);
            serialPort.Write(Encoding.UTF8.GetString(encodedBytes));
        }
    }
}