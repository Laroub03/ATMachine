using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMachine
{
    // PinValidator.cs
    public class PinValidator
    {
        private string CorrectPin = "1234"; 

        public bool ValidatePin(string enteredPin)
        {
            return enteredPin == CorrectPin;
        }
    }
}
