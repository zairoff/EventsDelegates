using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encoder
{
    public class AudioEncoder : BaseEncoder
    {
        public override void Encode(byte[] source)
        {
            OnPreparing();

            OnStarting();

            OnFinishing();

            OnEncoded();
        }
    }
}
