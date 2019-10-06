using ArduinoController.Serial;
using ArduinoController.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArduinoController.ViewModels
{
    public class SerialViewModel : BaseViewModel
    {
        private string portName;
        //private string sBaudRate;
        private ObservableCollection<string> portsList = new ObservableCollection<string>();
        private string buttonContent;
        private bool connected;
        private string text;

        private SerialPort sPort = new SerialPort();
        private SerialMessageListener listener = new SerialMessageListener();

        private List<Task> tasks = new List<Task>();

        public string SelectedPortName { get => portName; set { portName = value; RaisePropertyChanged(); } }
        //public string SBaudRate { get => sBaudRate; set { sBaudRate = value; RaisePropertyChanged(); } }
        public ObservableCollection<string> PortsList { get => portsList; set { portsList = value; RaisePropertyChanged(); } }
        public string ButtonContent { get => buttonContent; set { buttonContent = value; RaisePropertyChanged(); } }
        public bool Connected { get { return connected; } set { connected = value; DigitalPins.Connected = value; } }
        public string TransceivedText { get => text; set { text = value; RaisePropertyChanged(); } }

        public AnaloguePinsViewModel AnaloguePins { get; set; } = new AnaloguePinsViewModel();
        public DigitalPinsViewModel DigitalPins { get; set; } = new DigitalPinsViewModel();

        public ICommand ConnectCommand { get; set; }
        public ICommand RefreshPortsCommand { get; set; }
        public ICommand ClearTransceivedMessages { get; set; }

        public SerialViewModel()
        {
            sPort.NewLine = "\n";
            TransceivedText = "";
            ConnectCommand = new Command(AutoConnectArduino);
            RefreshPortsCommand = new Command(RefreshPorts);
            ClearTransceivedMessages = new Command(ClearTransceiverMessages);

            DigitalPins.MessageCallback = WriteTransceivedMessages;
            DigitalPins.DigitalWrite = vDigitalWrite;
            listener.OnMessage = ListenerMessageCallback;

            ButtonContent = "Connect";
            RefreshPorts();
        }

        public void ClearTransceiverMessages()
        {
            TransceivedText = "";
        }

        public void AutoConnectArduino()
        {
            if (!Connected)
                ConnectArduino();
            else
                DisconnectArduino();
        }

        public void ConnectArduino()
        {
            sPort = null;
            if (SelectedPortName == null)
            {
                WriteTransceivedMessages("Select a port name to connect to.");
                return;
            }
            sPort = new SerialPort(SelectedPortName, 115200, Parity.None, 8, StopBits.One);
            try
            {
                sPort.Open();
                StartSerialListener();
            }
            catch(Exception e) { WriteTransceivedMessages($"Failed to open port. Err: {e.Message}"); }
            WriteTransceivedMessages("Connected");
            ButtonContent = "Disconnect";
            Connected = true;
        }

        public void DisconnectArduino()
        {
            try
            {
                StopSerialListener();
                sPort.Close();
                sPort.Dispose();
            }
            catch (Exception e) { WriteTransceivedMessages($"Failed to close port. Err: {e.Message}"); }
            WriteTransceivedMessages("Disconnected");
            ButtonContent = "Connect";
            Connected = false;
        }

        public void RefreshPorts()
        {
            PortsList.Clear();
            foreach (string port in SerialPort.GetPortNames())
                PortsList.Add(port);
        }

        public void WriteTransceivedMessages(string message)
        {
            //if (TransceivedText.Length > 400)
            //    TransceivedText = "";
            //TransceivedText += $"{message}\n";
        }

        public void vDigitalWrite(int pin, bool HIGHorLOW)
        {
            switch (pin)
            {
                case 2 : if (HIGHorLOW) WriteSerialData("02HIGH"); else WriteSerialData("02LOW"); break;
                case 3 : if (HIGHorLOW) WriteSerialData("03HIGH"); else WriteSerialData("03LOW"); break;
                case 4 : if (HIGHorLOW) WriteSerialData("04HIGH"); else WriteSerialData("04LOW"); break;
                case 5 : if (HIGHorLOW) WriteSerialData("05HIGH"); else WriteSerialData("05LOW"); break;
                case 6 : if (HIGHorLOW) WriteSerialData("06HIGH"); else WriteSerialData("06LOW"); break;
                case 7 : if (HIGHorLOW) WriteSerialData("07HIGH"); else WriteSerialData("07LOW"); break;
                case 8 : if (HIGHorLOW) WriteSerialData("08HIGH"); else WriteSerialData("08LOW"); break;
                case 9 : if (HIGHorLOW) WriteSerialData("09HIGH"); else WriteSerialData("09LOW"); break;
                case 10: if (HIGHorLOW) WriteSerialData("10HIGH"); else WriteSerialData("10LOW"); break;
                case 11: if (HIGHorLOW) WriteSerialData("11HIGH"); else WriteSerialData("11LOW"); break;
                case 12: if (HIGHorLOW) WriteSerialData("12HIGH"); else WriteSerialData("12LOW"); break;
                case 13: if (HIGHorLOW) WriteSerialData("13HIGH"); else WriteSerialData("13LOW"); break;
            }
        }

        public void WriteSerialData(string data)
        {
            try
            {
                WriteTransceivedMessages($"TX> {data}");
                sPort.WriteLine(data);
            }
            catch(Exception e)
            {
                WriteTransceivedMessages($"Failed to write to serial port. Err: {e.Message}");
            }
        }

        public void ListenerMessageCallback(string data, string RXorTX)
        {
            WriteTransceivedMessages($"{RXorTX}> {data}");

            if (data.Substring(0, 1) == "A")
            {
                AnaloguePins.AnalogueMessage(data);
            }
        }

        private void StartSerialListener()
        {
            tasks.Add(listener.BeginMessageListener(sPort));
        }

        private void StopSerialListener()
        {
            Task.WhenAll(tasks);
        }
    }
}
