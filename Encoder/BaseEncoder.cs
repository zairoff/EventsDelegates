using System;

namespace Encoder
{
    public abstract class BaseEncoder
    {
        public event EventHandler<EncoderEventArgs> Preparing;
        public event EventHandler<EncoderEventArgs> Starting;
        public event EventHandler<EncoderEventArgs> Finishing;
        public event EventHandler<EncoderEventArgs> Encoded;

        protected void OnPreparing(EncoderEventArgs args)
        {
            Preparing?.Invoke(this, args);
        }

        protected void OnStarting(EncoderEventArgs args)
        {
            Starting?.Invoke(this, args);
        }

        protected void OnFinishing(EncoderEventArgs args)
        {
            Finishing?.Invoke(this, args);
        }

        protected void OnEncoded(EncoderEventArgs args)
        {
            Encoded?.Invoke(this, args);
        }

        public abstract void Encode(byte[] source);
    }
}
