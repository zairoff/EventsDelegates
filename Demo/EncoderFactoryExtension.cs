using Encoder;
using Encoder.Factory;
using Encoder.Source;
using System;

namespace Demo
{
    public static class EncoderFactoryExtension
    {
        public static object GetSource(this char sourceType)
        {
            return sourceType switch
            {
                'a' => new Audio(),
                'v' => new Video(),
                'i' => new Random().Next(1, 100),
                _ => new Audio(),
            };
        }
        public static BaseEncoder GetEncoder(this char encoderType, object source)
        {
            return encoderType switch
            {
                'a' => new AudioFactory().GetEncoder(source),
                'v' => new VideoFactory().GetEncoder(source),
                'i' => new IntegerFactory().GetEncoder(source),
                _ => new AudioFactory().GetEncoder(source),
            };
        }
    }
}
