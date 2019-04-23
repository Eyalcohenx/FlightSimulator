using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class Connect
    {
      
        private ISettingsModel _apsm;
        #region Singleton
        private static Connect m_Instance = null;
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
        #endregion
        private Connect()
        {
            _apsm = ApplicationSettingsModel.Instance;
        }
        public ISettingsModel getAPSM()
        {
            return _apsm;
        }
        public void connect()
        {
            Console.WriteLine("print");
            //eyal implement here
            GetLonAndLat();
        }
        private void GetLonAndLat()
        {
            
              FlightBoardViewModel fvm = FlightBoardViewModel.Instance;
            //eyal implement here - cotinouesly get lon and lat
            //fvm.Lon = 0.5; fvm.Lat = 0.3;//delete when u work! - need to work like that with while(get info from user)
           
          
           
        }
       
    }
}
