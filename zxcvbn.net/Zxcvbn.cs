using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zxcvbn.net
{
    public static class Zxcvbn 
    {
        private static ZxcvbnInstance Instance { get { return LazyLoadZxcvbnInstance.Value; } }
        private static readonly Lazy<ZxcvbnInstance> LazyLoadZxcvbnInstance = new Lazy<ZxcvbnInstance>(() => new ZxcvbnInstance());

        public static int Score(String password)
        {
            return Instance.Score(password);
        }

        public static Double Entropy(String password)
        {
            return Instance.Entropy(password);
        }

        public static double crack_time(String password)
        {
            return Instance.crack_time(password);
        }

        public static String crack_time_display(String password)
        {
            return Instance.crack_time_display(password);
        }

        public static List<String> match_sequence(String password)
        {
            return Instance.match_sequence(password);
        }

        public static int calculation_time(String password)
        {
            return Instance.calculation_time(password);
        }
    }
}
