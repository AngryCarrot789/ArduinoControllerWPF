using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoController.Utils
{
    public static class DataStructures
    {
        public const string AnalogueStage1 = "A";
        public const string DigitalStage1  = "D";

        public const string AnalogueStage2 = "(pin number (0-5))";
        public const string DigitalStage2 = "(pin number (2-13))";

        public const string AnalogueStage3 = "(int value)";
        public const string DigitalStage3  = "HIGH or LOW";

        public const string ExampleAnalogueMSG = "A31022   ->  pin A3, value = 1022"; 
        public const string ExampleDigitalMSG  = "D11HIGH  ->  pin D11, is HIGH";
    }
}
