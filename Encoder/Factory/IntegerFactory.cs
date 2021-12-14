using System;

namespace Encoder.Factory
{
    public class IntegerFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder()
        {
            return new IntegerEncoder(new Random().Next(1, 100));
        }
    }
}
