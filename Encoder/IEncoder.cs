using System;

namespace Encoder
{
    public interface IEncoder
    {
        void Encode(byte[] source);
    }
}
