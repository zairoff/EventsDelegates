using Encoder.Source;

namespace Encoder
{
    public class VideoEncoder : BaseEncoder
    {
        private readonly Video _source;

        public VideoEncoder(Video source)
        {
            _source = source;
        }

        public override void Encode()
        {
            OnPreparing(new EncoderEventArgs("Video is preparing to be encoded..."));

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
