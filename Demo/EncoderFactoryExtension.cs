using Encoder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class EncoderFactoryExtension
    {
        public static EncoderFactory GetEncoderFactory(this string encoderType)
        {
            return encoderType.ToLower() switch
            {
                "a" => new AudioFactory(),
                "b" => new VideoFactory(),
                "c" => new IntegerFactory(),
                _ => new AudioFactory(),
            };
        }
    }
}
