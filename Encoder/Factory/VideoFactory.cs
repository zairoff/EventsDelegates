using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder.Factory
{
    public class VideoFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder()
        {
            return new VideoEncoder();

        }
    }
}
