using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_GUI
{
    public class AgeBelowZeroException : Exception
    {
        private static string _msg = "Age cannot be below zero.";

        public AgeBelowZeroException() : base(_msg) { }
    }
}
