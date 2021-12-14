namespace Encoder.Factory
{
    public class VideoFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder()
        {
            return new VideoEncoder();
        }
    }
}
