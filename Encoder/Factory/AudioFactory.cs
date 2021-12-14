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
