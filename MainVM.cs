using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Metrology
{
    class MainVM : INotifyPropertyChanged
    {
        public MainVM()
        {
            AmountPlates = 5;
            Plates = new ObservableCollection<int>();
            Channels = new ObservableCollection<int>();
            for (int i = 1; i <= 16; i++) Channels.Add(i);
            SetLL = new SetLogicLevelClass();
            MeasLL = new MeasLogicLevelClass();
            MeasC = new MeasCurrentClass();
        }

        public enum StateButtons {Off=0, SetLogicLev, MeasLogicLev, MakeImpuls, SetVoltage, MeasInputCurr, Counter };
        StateButtons stateButton = StateButtons.Off;
        public StateButtons StateButton
        {
            get { return stateButton; }
            set { stateButton = value; OnPropertyChanged(); }
        }

        private int amountPlates;
        public int AmountPlates
        {
            get { return amountPlates; }
            set
            {
                amountPlates = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<int> channels;
        public ObservableCollection<int> Channels
        {
            get { return channels; }
            set { channels = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> plates;
        public ObservableCollection<int> Plates
        {
            get { return plates; }
            set { plates = value; OnPropertyChanged(); }
        }

        public static int plate;
        public int Plate
        {
            get { return plate; }
            set { plate = value; OnPropertyChanged(); }
        }
        private bool initState;
        public bool InitState
        {
            get { return initState; }
            set { initState = value; OnPropertyChanged(); }
        }
        private SetLogicLevelClass setLL;
        public SetLogicLevelClass SetLL
        {
            get { return setLL; }
            set { setLL = value; OnPropertyChanged(); }
        }
        private MeasLogicLevelClass measLL;
        public MeasLogicLevelClass MeasLL
        {
            get { return measLL; }
            set { measLL = value; OnPropertyChanged(); }
        }
        private MeasCurrentClass measC;
        public MeasCurrentClass MeasC
        {
            get { return measC; }
            set { measC = value; OnPropertyChanged(); }
        }




        #region ICommand Initialization
        private ICommand initialization;
        public ICommand Initialization
        {
            get
            {
                if (initialization == null)
                    initialization = new MyCommand(InitializationButton, () => { return true; });
                return initialization;
            }
        }
        public void InitializationButton()
        {
            if (InitState)
            {
                Plates.Clear();

                Plate = -1;
                InitState = !InitState;
            }
            else
            {
                //AmountPlates = OpenATE.pe16_init();
                OpenATE.Reset();

                for (int i = 1; i <= AmountPlates; i++)
                    Plates.Add(i);

                InitState = !InitState;
            }
        }
        #endregion

        #region ICommand SetLogicLevel
        private ICommand setLogicLevel;
        public ICommand SetLogicLevel
        {
            get
            {
                if (setLogicLevel == null)
                    setLogicLevel = new MyCommand(SetLogicLevelButton, () => {
                        if (SetLL.Channel > 0 && SetLL.Voltage > 0) return true;
                        else return false;
                    });
                return setLogicLevel;
            }
        }
        public void SetLogicLevelButton()
        {
            if (StateButton == StateButtons.Off)
            {
                SetLL.launch();

                StateButton = StateButtons.SetLogicLev;
            }
            else
            {
                SetLL.stop();

                StateButton = StateButtons.Off;
            }
        }
        #endregion

        #region ICommand MeasLogicLevel
        private ICommand measLogicLevel;
        public ICommand MeasLogicLevel
        {
            get
            {
                if (measLogicLevel == null)
                    measLogicLevel = new MyCommand(MeasLogicLevelButton, () => {
                        if (MeasLL.Channel > 0) return true;
                        else return false;
                    });
                return measLogicLevel;
            }
        }
        public void MeasLogicLevelButton()
        {
            if (StateButton == StateButtons.Off)
            {
                MeasLL.launch();

                StateButton = StateButtons.MeasLogicLev;
            }
            else
            {
                MeasLL.stop();

                StateButton = StateButtons.Off;
            }
        }
        #endregion

        #region ICommand MeasCurr
        private ICommand measCurr;
        public ICommand MeasCurr
        {
            get
            {
                if (measCurr == null)
                    measCurr = new MyCommand(MeasCurrButton, () => {
                        if (MeasLL.Channel > 0) return true;
                        else return false;
                    });
                return measCurr;
            }
        }
        public void MeasCurrButton()
        {
            if (StateButton == StateButtons.Off)
            {
                MeasC.launch();

                StateButton = StateButtons.MeasInputCurr;
            }
            else
            {
                MeasC.stop();

                StateButton = StateButtons.Off;
            }
        }
        #endregion

        #region ICommand ChangeRadio
        private ICommand changeRadio;
        public ICommand ChangeRadio
        {
            get
            {
                if (changeRadio == null)
                    changeRadio = new MyCommand(ChangeRadioButton, () => { return true; });
                return changeRadio;
            }
        }
        public void ChangeRadioButton()
        {
            OpenATE.Reset();
        }
        #endregion





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
