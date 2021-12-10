using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External.Encoder
{
    public class EncodedEventArgs : EventArgs
    {
        public string Data { get; private set; }

        public EncodedEventArgs(string data)
        {
            Data = data;
        }
    }
}
