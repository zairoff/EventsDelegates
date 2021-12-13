using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    public class IntegerEncoder : BaseEncoder
    {
        public int Random { get; private set; }

        public IntegerEncoder(int randomNumber)
        {
            Random = randomNumber;
        }

        public override void Encode(byte[] source)
        {
            OnPreparing(new EncoderEventArgs("Integer is preparing to be encoded... Random number is: " + Random));

            if (Random % 2 != 0)
                return;

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
