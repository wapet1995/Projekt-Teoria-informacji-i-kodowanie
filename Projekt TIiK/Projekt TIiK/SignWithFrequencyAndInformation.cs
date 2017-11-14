using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_TIiK
{
    class SignWithFrequencyAndInformation
    {
            public char Sign { get; set; }
            public double Frequency { get; set; }
            public double Information { get; set; }
            public SignWithFrequencyAndInformation(char Sign, double Frequency, double Information)
            {
                this.Sign = Sign;
                this.Frequency = Frequency;
                this.Information = Information;
            }
    }
}
