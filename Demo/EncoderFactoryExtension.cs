using Encoder.Factory;

namespace Demo
{
    public static class EncoderFactoryExtension
    {
        public static EncoderFactory GetEncoderFactory(this char encoderType)
        {
            return encoderType switch
            {
                'a' => new AudioFactory(),
                'v' => new VideoFactory(),
                'i' => new IntegerFactory(),
                _ => new AudioFactory(),
            };
        }
    }
}
