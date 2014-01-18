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
            Zxcvbn zxcvbn = new Zxcvbn();
            zxcvbn.Entropy("LamePassword");

            for (int i = 0; i < 100; i++)
            {
                zxcvbn.Entropy("LamePassword");
            }
        }
    }
}
