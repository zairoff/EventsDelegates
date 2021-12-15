using Encoder.Source;
using System;

namespace Encoder.Factory
{
    public class VideoFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder(object source)
        {
            if (source is not Video)
                throw new InvalidOperationException();

            return new VideoEncoder((Video)source);
        }
    }
}
