using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    public class EncoderEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public bool Stop { get; set; }

        public EncoderEventArgs(string message)
        {
            Message = message;
        }
    }
}
