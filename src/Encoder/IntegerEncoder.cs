namespace Encoder
{
    public class IntegerEncoder : BaseEncoder 
    {
        public int Source { get; private set; }

        public IntegerEncoder(int source)
        {
            Source = source;
        }

        public override void Encode()
        {
            var args = OnPreparing(new EncoderEventArgs("Integer is preparing to be encoded..." + Source));

            if (args.Stop)
                return;

            OnStarting(new EncoderEventArgs("Starting encoding..."));

            OnFinishing(new EncoderEventArgs("Finishing encoding..."));

            OnEncoded(new EncoderEventArgs("Finished encoding..."));
        }
    }
}
