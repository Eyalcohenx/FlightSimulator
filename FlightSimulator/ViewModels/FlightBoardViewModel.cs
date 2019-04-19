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
        public ICommand ConnectCommand
        {
            get; set;
        }
        //implement setters:
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
