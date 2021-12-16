using Encoder.Source;
using System;

namespace Encoder.Factory
{
    public class AudioFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder(object source)
        {
            if (source is not Audio)
                throw new FormatException("source format not supported");

            return new AudioEncoder((Audio)source);
        }
    }
}
