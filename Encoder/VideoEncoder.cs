using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encoder
{
    public class VideoEncoder : BaseEncoder
    {
        public override void Encode(byte[] source)
        {
            OnPreparing(new EncoderEventArgs("Video is preparing to be encoded..."));

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
