using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace External.Encoder
{
    public class VideoEncoder : IEncoder
    {
        public event EventHandler<EncodedEventArgs> Encoded;

        public void Encode(byte[] source)
        {
            Console.WriteLine("Video is encoding...");
            Thread.Sleep(1000);

            Notify("Video is encoded successfully!");
        }

        public void Notify(string message)
        {
            Encoded?.Invoke(null, new EncodedEventArgs(message));
        }
    }
}
