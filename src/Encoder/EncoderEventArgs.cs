using System;

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
