using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FlightSimulator.Model
{
    public class Connect
    {
        private ISettingsModel _apsm;

        #region Singleton

        private static Connect m_Instance = null;

        //the server we created to read lon and lat
        private TcpListener listner;

        //the client we created to send the commands from
        private Commands commands;
        private TcpClient Info;

        public static Connect Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Connect();
                }
                return m_Instance;
            }
        }

        #endregion Singleton

        private Connect()
        {
            
            //getting the instance from the APSM
            _apsm = ApplicationSettingsModel.Instance;
            listner = new TcpListener(_apsm.FlightInfoPort);
            listner.Start();
            commands = Commands.Instance;
        }

        public ISettingsModel getAPSM()
        {
            return _apsm;
        }

        public void connect()
        {
            commands.Connect(_apsm.FlightServerIP, _apsm.FlightCommandPort);
            //create thread to run the loop
            ThreadStart loopref = new ThreadStart(GetLonAndLat);
            Thread loopThread = new Thread(loopref);
            loopThread.Start();
        }
        public void disconnect()
        {
            listner.Stop();
            commands.close();
        }

        private void GetLonAndLat()
        {
            FlightBoardViewModel fvm = FlightBoardViewModel.Instance;
            Info = listner.AcceptTcpClient();                               //getting the info path
            NetworkStream ns = Info.GetStream();                            //networkstream is used to send/receive messages
            ns.Flush();
            while (Info.Connected)                                          //while the client is connected, we look for incoming messages
            {
                byte[] msg = new byte[1024];                                //the messages arrive as byte array
                ns.Read(msg, 0, msg.Length);                                //the same networkstream reads the message sent by the client
                String message = Encoding.Default.GetString(msg).TrimEnd(); //now , we write the message as string
                string[] lines = message.Split('\n');
                if (lines.Length > 0)
                {
                    string[] numbers = lines[0].Split(',');
                    if(numbers.Length == 25) { 
                        double temp1, temp2;
                        if (Double.TryParse(numbers[1], out temp2))
                            fvm.Lat = Math.Round(temp2,2);
                        if (Double.TryParse(numbers[0], out temp1))
                            fvm.Lon = Math.Round(temp1,2);
                    }
                }
            }
        }
    }
}