using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder.Factory
{
    public abstract class EncoderFactory
    {
        public abstract BaseEncoder GetEncoder();
    }
}
