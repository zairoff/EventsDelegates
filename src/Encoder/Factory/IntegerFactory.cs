using System;

namespace Encoder.Factory
{
    public class IntegerFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder(object source)
        {
            if (source is not int)
                throw new FormatException("source format not supported");

            return new IntegerEncoder((int)source);
        }
    }
}
