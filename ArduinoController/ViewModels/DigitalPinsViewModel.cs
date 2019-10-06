using ArduinoController.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArduinoController.ViewModels
{
    public class DigitalPinsViewModel : BaseViewModel
    {
        public bool Connected { get; set; }

        private bool d2Pin;
        private bool d3Pin;
        private bool d4Pin;
        private bool d5Pin;
        private bool d6Pin;
        private bool d7Pin;
        private bool d8Pin;
        private bool d9Pin;
        private bool d10Pin;
        private bool d11Pin;
        private bool d12Pin;
        private bool d13Pin;

        public bool D2Pin  { get => d2Pin; set  { d2Pin = value; RaisePropertyChanged(); } }
        public bool D3Pin  { get => d3Pin; set  { d3Pin = value; RaisePropertyChanged(); } }
        public bool D4Pin  { get => d4Pin; set  { d4Pin = value; RaisePropertyChanged(); } }
        public bool D5Pin  { get => d5Pin; set  { d5Pin = value; RaisePropertyChanged(); } }
        public bool D6Pin  { get => d6Pin; set  { d6Pin = value; RaisePropertyChanged(); } }
        public bool D7Pin  { get => d7Pin; set  { d7Pin = value; RaisePropertyChanged(); } }
        public bool D8Pin  { get => d8Pin; set  { d8Pin = value; RaisePropertyChanged(); } }
        public bool D9Pin  { get => d9Pin; set  { d9Pin = value; RaisePropertyChanged(); } }
        public bool D10Pin { get => d10Pin; set { d10Pin = value; RaisePropertyChanged(); } }
        public bool D11Pin { get => d11Pin; set { d11Pin = value; RaisePropertyChanged(); } }
        public bool D12Pin { get => d12Pin; set { d12Pin = value; RaisePropertyChanged(); } }
        public bool D13Pin { get => d13Pin; set { d13Pin = value; RaisePropertyChanged(); } }

        public Action<string> MessageCallback { get; set; }
        public Action<int, bool> DigitalWrite { get; set; }

        public ICommand SetDigitalPinCommand { get; set; }

        public DigitalPinsViewModel()
        {
            SetDigitalPinCommand = new CommandParam(SetDigitalPin);
        }

        public void SetDigitalPin(object pin)
        {
            if (Connected)
            { 
                switch (Convert.ToInt32(pin.ToString()))
                {
                    case 2 : if (D2Pin ) { WriteDigitalPin(2,  false); D2Pin =  false; } else { WriteDigitalPin(2,  true); D2Pin =  true; } break;
                    case 3 : if (D3Pin ) { WriteDigitalPin(3 , false); D3Pin  = false; } else { WriteDigitalPin(3 , true); D3Pin  = true; } break;
                    case 4 : if (D4Pin ) { WriteDigitalPin(4 , false); D4Pin  = false; } else { WriteDigitalPin(4 , true); D4Pin  = true; } break;
                    case 5 : if (D5Pin ) { WriteDigitalPin(5 , false); D5Pin  = false; } else { WriteDigitalPin(5 , true); D5Pin  = true; } break;
                    case 6 : if (D6Pin ) { WriteDigitalPin(6 , false); D6Pin  = false; } else { WriteDigitalPin(6 , true); D6Pin  = true; } break;
                    case 7 : if (D7Pin ) { WriteDigitalPin(7 , false); D7Pin  = false; } else { WriteDigitalPin(7 , true); D7Pin  = true; } break;
                    case 8 : if (D8Pin ) { WriteDigitalPin(8 , false); D8Pin  = false; } else { WriteDigitalPin(8 , true); D8Pin  = true; } break;
                    case 9 : if (D9Pin ) { WriteDigitalPin(9 , false); D9Pin  = false; } else { WriteDigitalPin(9 , true); D9Pin  = true; } break;
                    case 10: if (D10Pin) { WriteDigitalPin(10, false); D10Pin = false; } else { WriteDigitalPin(10, true); D10Pin = true; } break;
                    case 11: if (D11Pin) { WriteDigitalPin(11, false); D11Pin = false; } else { WriteDigitalPin(11, true); D11Pin = true; } break;
                    case 12: if (D12Pin) { WriteDigitalPin(12, false); D12Pin = false; } else { WriteDigitalPin(12, true); D12Pin = true; } break;
                    case 13: if (D13Pin) { WriteDigitalPin(13, false); D13Pin = false; } else { WriteDigitalPin(13, true); D13Pin = true; } break;
                }
            }
        }

        public void WriteDigitalPin(int pin, bool highTRUElowFALSE)
        {
            DigitalWrite(pin, highTRUElowFALSE);
            if (highTRUElowFALSE)
            {
                MessageCallback($"Setting Pin {pin} to HIGH");
            }
            else
            {
                MessageCallback($"Setting Pin {pin} to LOW");
            }
        }
    }
}
