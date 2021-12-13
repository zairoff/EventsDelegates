using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encoder
{
    public class AudioEncoder : BaseEncoder
    {
        public override void Encode(byte[] source)
        {
            OnPreparing(new EncoderEventArgs("Audio is preparing to be encoded..."));

            OnStarting(new EncoderEventArgs("Started encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
