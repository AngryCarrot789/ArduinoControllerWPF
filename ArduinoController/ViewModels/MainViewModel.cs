using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoController.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public SerialViewModel SerialView { get; set; }

        public MainViewModel()
        {
            SerialView = new SerialViewModel();
        }
    }
}
