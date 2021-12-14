namespace Encoder
{
    public class AudioEncoder : BaseEncoder
    {
        public override void Encode(byte[] source)
        {
            OnPreparing(new EncoderEventArgs("Audio is preparing to be encoded..."));

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
