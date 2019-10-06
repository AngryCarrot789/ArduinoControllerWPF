using ArduinoController.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArduinoController.ViewModels
{
    public class AnaloguePinsViewModel : BaseViewModel
    {
        public int MaxLength = 50;
        private string a0Text;
        private string a1Text;
        private string a2Text;
        private string a3Text;
        private string a4Text;
        private string a5Text;

        public string A0Text { get => a0Text; set { a0Text = value; RaisePropertyChanged(); } }
        public string A1Text { get => a1Text; set { a1Text = value; RaisePropertyChanged(); } }
        public string A2Text { get => a2Text; set { a2Text = value; RaisePropertyChanged(); } }
        public string A3Text { get => a3Text; set { a3Text = value; RaisePropertyChanged(); } }
        public string A4Text { get => a4Text; set { a4Text = value; RaisePropertyChanged(); } }
        public string A5Text { get => a5Text; set { a5Text = value; RaisePropertyChanged(); } }

        private bool a0Enabled;
        private bool a1Enabled;
        private bool a2Enabled;
        private bool a3Enabled;
        private bool a4Enabled;
        private bool a5Enabled;

        public bool A0Enabled { get => a0Enabled; set { a0Enabled = value; RaisePropertyChanged(); } }
        public bool A1Enabled { get => a1Enabled; set { a1Enabled = value; RaisePropertyChanged(); } }
        public bool A2Enabled { get => a2Enabled; set { a2Enabled = value; RaisePropertyChanged(); } }
        public bool A3Enabled { get => a3Enabled; set { a3Enabled = value; RaisePropertyChanged(); } }
        public bool A4Enabled { get => a4Enabled; set { a4Enabled = value; RaisePropertyChanged(); } }
        public bool A5Enabled { get => a5Enabled; set { a5Enabled = value; RaisePropertyChanged(); } }

        public ICommand ClearText { get; set; }

        public AnaloguePinsViewModel()
        {
            ClearText = new CommandParam(ClrText);
            A0Enabled = true;
            A1Enabled = true;
            A2Enabled = true;
            A3Enabled = true;
            A4Enabled = true;
            A5Enabled = true;
        }

        public void ClrText(object box)
        {
            switch (Convert.ToInt32(box.ToString()))
            {
                case 0: A0Text = ""; break;
                case 1: A1Text = ""; break;
                case 2: A2Text = ""; break;
                case 3: A3Text = ""; break;
                case 4: A4Text = ""; break;
                case 5: A5Text = ""; break;
            }
        }

        public void AnalogueMessage(string message)
        {
            int pin = Convert.ToInt32(message.Substring(1, 1));
            switch (pin)
            {
                case 0: WriteA0Box(message.Substring(2)); break;
                case 1: WriteA1Box(message.Substring(2)); break;
                case 2: WriteA2Box(message.Substring(2)); break;
                case 3: WriteA3Box(message.Substring(2)); break;
                case 4: WriteA4Box(message.Substring(2)); break;
                case 5: WriteA5Box(message.Substring(2)); break;
            }
        }

        public void WriteA0Box(string data) { if (A0Enabled) A0Text += $"{data}"; if (A0Text.Length >= 100) ClrText(0); }
        public void WriteA1Box(string data) { if (A1Enabled) A1Text += $"{data}"; if (A1Text.Length >= 100) ClrText(1); }
        public void WriteA2Box(string data) { if (A2Enabled) A2Text += $"{data}"; if (A2Text.Length >= 100) ClrText(2); }
        public void WriteA3Box(string data) { if (A3Enabled) A3Text += $"{data}"; if (A3Text.Length >= 100) ClrText(3); }
        public void WriteA4Box(string data) { if (A4Enabled) A4Text += $"{data}"; if (A4Text.Length >= 100) ClrText(4); }
        public void WriteA5Box(string data) { if (A5Enabled) A5Text += $"{data}"; if (A5Text.Length >= 100) ClrText(5); }
    }
}
