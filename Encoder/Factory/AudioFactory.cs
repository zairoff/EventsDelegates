using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder.Factory
{
    public class AudioFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder()
        {
            return new AudioEncoder();
        }
    }
}
