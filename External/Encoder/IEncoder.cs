using System;

namespace External.Encoder
{
    public interface IEncoder
    {
        void Encode(byte[] source);

        void Notify(string message);

        event EventHandler<EncodedEventArgs> Encoded;
    }
}
