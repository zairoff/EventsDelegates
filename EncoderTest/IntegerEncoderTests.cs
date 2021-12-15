using Encoder;
using Xunit;

namespace EncoderTest
{
    public class IntegerEncoderTests
    {
        [Fact]
        public void Encode_ShouldRaisOnPreparingEvent()
        {
            var eventMessage = "";
            var encoder = new IntegerEncoder(10);

            encoder.Preparing += delegate (object sender, EncoderEventArgs args)
            {
                eventMessage = args.Message;
            };

            encoder.Encode();

            Assert.NotNull(eventMessage);
            Assert.Equal("Integer is preparing to be encoded...10", eventMessage);
        }

        [Fact]
        public void Encode_ShouldRaisOnStartingEvent()
        {
            var eventMessage = "";
            var encoder = new IntegerEncoder(10);

            encoder.Starting += delegate (object sender, EncoderEventArgs args)
            {
                eventMessage = args.Message;
            };

            encoder.Encode();

            Assert.NotNull(eventMessage);
            Assert.Equal("Starting encoding...", eventMessage);
        }

        [Fact]
        public void Encode_ShouldRaisOnFinishingEvent()
        {
            var eventMessage = "";
            var encoder = new IntegerEncoder(10);

            encoder.Finishing += delegate (object sender, EncoderEventArgs args)
            {
                eventMessage = args.Message;
            };

            encoder.Encode();

            Assert.NotNull(eventMessage);
            Assert.Equal("Finishing encoding...", eventMessage);
        }

        [Fact]
        public void Encode_ShouldRaisOnEncodedEvent()
        {
            var eventMessage = "";
            var encoder = new IntegerEncoder(10);

            encoder.Encoded += delegate (object sender, EncoderEventArgs args)
            {
                eventMessage = args.Message;
            };

            encoder.Encode();

            Assert.NotNull(eventMessage);
            Assert.Equal("Finished encoding...", eventMessage);
        }

        [Fact]
        public void Encode_ShouldRais4Events()
        {
            var result = 0;
            var encoder = new IntegerEncoder(10);

            encoder.Preparing += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Starting += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Finishing += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Encoded += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Encode();

            Assert.Equal(4, result);
        }

        [Fact]
        public void Encode_ShouldRaisOneEvent()
        {
            var result = 0;
            var encoder = new IntegerEncoder(11);

            encoder.Preparing += delegate (object sender, EncoderEventArgs args)
            {
                result++;
                args.Stop = true;
            };

            encoder.Starting += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Finishing += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Encoded += delegate (object sender, EncoderEventArgs args)
            {
                result++;
            };

            encoder.Encode();


            Assert.Equal(1, result);
        }
    }
}
