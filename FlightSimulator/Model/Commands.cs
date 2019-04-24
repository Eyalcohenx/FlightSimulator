using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Commands
    {
        private TcpClient client;

        private static Commands m_Instance;

        public static Commands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Commands();
                }
                return m_Instance;
            }
        }
        private Commands()
        {
            client = new TcpClient();
        }

        public void Connect(String FlightServerIP, int FlightCommandsPort)
        {
            client = new TcpClient(FlightServerIP, FlightCommandsPort);
        }

        public void close()
        {
            client.Close();
        }

        public void sendCommand(String Command)
        {
            if (!client.Connected)
                return;
            Command = Command + "\n\r\n\r";
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(Command);

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
        }
    }
}
