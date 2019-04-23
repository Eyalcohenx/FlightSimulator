using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private String codetext;
        private String oldtext;
        private Commands _commands;
        #region Singleton
        private static AutoPilotViewModel m_Instance = null;
        public static AutoPilotViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new AutoPilotViewModel(Commands.Instance);
                }
                return m_Instance;
            }
        }
        #endregion
        #region Commands
        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {

            oldText = codeText;
            string[] commands = codeText.Split('\n');
            foreach (String command in commands) {
                _commands.sendCommand(command);
               
            }
        }
        #endregion
        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            oldText = "";
            codeText = "";
        }
        #endregion
        #endregion
        private AutoPilotViewModel(Commands com)
        {
            _commands = com;
            codeText = "";
            oldText = "";
        }

        public String codeText
        {
            get { return codetext; }
            set { codetext = value; NotifyPropertyChanged("codeText"); NotifyPropertyChanged("Background"); }
        }

        public SolidColorBrush Background
        {
            get
            {
                return codetext.Equals(oldtext) ? Brushes.Transparent : Brushes.LightPink;
            }
        }

        public string oldText { get => oldtext; set { oldtext = value; NotifyPropertyChanged("Background"); } }
    }
}
