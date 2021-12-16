using System;

namespace Encoder
{
    public abstract class BaseEncoder
    {
        public event EventHandler<EncoderEventArgs> Preparing;
        public event EventHandler<EncoderEventArgs> Starting;
        public event EventHandler<EncoderEventArgs> Finishing;
        public event EventHandler<EncoderEventArgs> Encoded;

        protected EncoderEventArgs OnPreparing(EncoderEventArgs args)
        {
            Preparing?.Invoke(this, args);

            return args;
        }

        protected EncoderEventArgs OnStarting(EncoderEventArgs args)
        {
            Starting?.Invoke(this, args);

            return args;
        }

        protected EncoderEventArgs OnFinishing(EncoderEventArgs args)
        {
            Finishing?.Invoke(this, args);

            return args;
        }

        protected EncoderEventArgs OnEncoded(EncoderEventArgs args)
        {
            Encoded?.Invoke(this, args);

            return args;
        }

        public abstract void Encode();
    }
}
