using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcvbn.net;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Zxcvbn.Entropy("LamePassword");

            for (int i = 0; i < 100; i++)
            {
                Zxcvbn.Entropy("LamePassword");
            }
        }
    }
}
