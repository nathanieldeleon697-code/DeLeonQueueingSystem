using System;
using System.Collections.Generic;
using System.Text;

namespace DeLeonQueueingSystem
{
    internal class CashierClass
    {
        private int _counter = 10000;

        public static Queue<string> CashierQueue { get; } = new Queue<string>();

        public string CashierGeneratedNumber(string prefix)
        {
            _counter++;
            return $"{prefix}{_counter}";
        }
    }
}
    

