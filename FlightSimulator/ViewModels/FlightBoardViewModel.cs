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
        //to edit::
        private ICommand _connectCommand;
        private Connect connect;
        public ICommand ConnectCommand
        {
            get; set;
        }
        //implement setters via data binding:
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
    }
}
