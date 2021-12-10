using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encoder
{
    public class AudioEncoder : IEncoder
    {
        public event EventHandler Preparing;
        public event EventHandler Starting;
        public event EventHandler Finishing;
        public event EventHandler Encoded;

        protected void OnPreparing()
        {
            Preparing?.Invoke(this, EventArgs.Empty);
        }

        protected void OnStarting()
        {
            Starting?.Invoke(this, EventArgs.Empty);
        }

        protected void OnFinishing()
        {
            Finishing?.Invoke(this, EventArgs.Empty);
        }

        protected void OnEncoded()
        {
            Encoded?.Invoke(this, EventArgs.Empty);
        }

        public void Encode(byte[] source)
        {
            OnPreparing();

            OnStarting();

            OnFinishing();

            OnEncoded();
        }
    }
}
