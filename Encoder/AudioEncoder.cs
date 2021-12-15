using Encoder.Source;

namespace Encoder
{
    public class AudioEncoder : BaseEncoder
    {
        private readonly Audio _source;

        public AudioEncoder(Audio source)
        {
            _source = source;
        }
        public override void Encode()
        {
            OnPreparing(new EncoderEventArgs("Audio is preparing to be encoded..."));

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
