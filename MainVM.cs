﻿using System;
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
            AmountPlates = 2;
            Plates = new ObservableCollection<int>();
            Channels = new ObservableCollection<int>();
            for (int i = 1; i <= 16; i++) Channels.Add(i);
            Sources = new ObservableCollection<string>() { "DPS1", "DPS2" };
            SetLL = new SetLogicLevelClass();
            MeasLL = new MeasLogicLevelClass();
            MeasC = new MeasCurrentClass();
            SetImp = new ImpulsClass();
            SetSV = new SetSourceVoltageClass();
            MeasCount = new CounterClass();
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

        private ObservableCollection<string> sources;
        public ObservableCollection<string> Sources
        {
            get { return sources; }
            set { sources = value; OnPropertyChanged(); }
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
        public static int numPopup;
        public int NumPopup
        {
            get { return numPopup; }
            set { numPopup = value; OnPropertyChanged(); }
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
        private ImpulsClass setImp;
        public ImpulsClass SetImp
        {
            get { return setImp; }
            set { setImp = value; OnPropertyChanged(); }
        }
        private SetSourceVoltageClass setSV;
        public SetSourceVoltageClass SetSV
        {
            get { return setSV; }
            set { setSV = value; OnPropertyChanged(); }
        }
        private CounterClass measCount;
        public CounterClass MeasCount
        {
            get { return measCount; }
            set { measCount = value; OnPropertyChanged(); }
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
                AmountPlates = OpenATE.init_();
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
                        if (SetLL.Channel > 0) return true;
                        else return false;
                    });
                return setLogicLevel;
            }
        }
        public void SetLogicLevelButton()
        {
            if (SetLL.Voltage == null || SetLL.Voltage == 0) { NumPopup = 1; return; }
            NumPopup = 0;
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

        #region ICommand SetImpuls
        private ICommand setImpuls;
        public ICommand SetImpuls
        {
            get
            {
                if (setImpuls == null)
                    setImpuls = new MyCommand(SetImpulsButton, () => {
                        return true;
                    });
                return setImpuls;
            }
        }
        public void SetImpulsButton()
        {
            if (SetImp.Vih<=SetImp.Vil) { NumPopup = 2; return; }

            NumPopup = 0;
            if (StateButton == StateButtons.Off)
            {
                SetImp.launch();

                StateButton = StateButtons.MakeImpuls;
            }
            else
            {
                SetImp.stop();

                StateButton = StateButtons.Off;
            }
        }
        #endregion

        #region ICommand SetSourceVoltage
        private ICommand setSourceVoltage;
        public ICommand SetSourceVoltage
        {
            get
            {
                if (setSourceVoltage == null)
                    setSourceVoltage = new MyCommand(SetSourceVoltageButton, () => {
                        if (SetSV.Source>=0)
                            return true;
                        else return false;
                    });
                return setSourceVoltage;
            }
        }
        public void SetSourceVoltageButton()
        {
            if (SetSV.Voltage == null || SetSV.Voltage == 0) { NumPopup = 3; return; }
            NumPopup = 0;
            if (StateButton == StateButtons.Off)
            {
                SetSV.launch();

                StateButton = StateButtons.SetVoltage;
            }
            else
            {
                SetSV.stop();

                StateButton = StateButtons.Off;
            }
        }
        #endregion

        #region ICommand MeasCounter
        private ICommand measCounter;
        public ICommand MeasCounter
        {
            get
            {
                if (measCounter == null)
                    measCounter = new MyCommand(MeasCounterButton, () => {
                        if (MeasCount.Channel > 0) return true;
                        else return false;
                    });
                return measCounter;
            }
        }
        public void MeasCounterButton()
        {
            if (StateButton == StateButtons.Off)
            {
                MeasCount.launch();

                StateButton = StateButtons.Counter;
            }
            else
            {
                MeasCount.stop();

                StateButton = StateButtons.Off;
            }
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
