using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private double lon, lat;
        private Connect _connect;
        #region Singleton
        private static FlightBoardViewModel m_Instance = null;
        public static FlightBoardViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardViewModel(Connect.Instance);
                    
                }
                return m_Instance;
            }
        }
        #endregion
        #region Commands
        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            _connect.connect();
        }
        #endregion
        #endregion
        private FlightBoardViewModel(Connect con)
        {
            _connect = con;
        }
        public double Lon
        {
            get { return lon; }
            set { lon = value; NotifyPropertyChanged("Lon"); }
        }

        public double Lat
        {
            get { return lat; }
            set { lat = value; NotifyPropertyChanged("Lat"); }
        }
    }
}
