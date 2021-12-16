namespace Encoder.Factory
{
    public abstract class EncoderFactory
    {
        public abstract BaseEncoder GetEncoder(object source);
    }
}
