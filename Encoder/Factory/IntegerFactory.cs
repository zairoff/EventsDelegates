using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder.Factory
{
    public class IntegerFactory : EncoderFactory
    {
        public override BaseEncoder GetEncoder()
        {
            return new IntegerEncoder(new Random().Next(1, 100));
        }
    }
}
