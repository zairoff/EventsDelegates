using Encoder;
using Encoder.Source;
using Xunit;

namespace EncoderTest
{
    public class AudioEncoderTests
    {
        [Fact]
        public void Encode_ShouldRaisOnPreparingEvent()
        {
            var eventMessage = "";
            var encoder = new AudioEncoder(new Audio());

            encoder.Preparing += delegate (object sender, EncoderEventArgs args)
            {
                eventMessage = args.Message;
            };

            encoder.Encode();

            Assert.NotNull(eventMessage);
            Assert.Equal("Audio is preparing to be encoded...", eventMessage);
        }

        [Fact]
        public void Encode_ShouldRaisOnStartingEvent()
        {
            var eventMessage = "";
            var encoder = new AudioEncoder(new Audio());

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
            var encoder = new AudioEncoder(new Audio());

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
            var encoder = new AudioEncoder(new Audio());

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
            var encoder = new AudioEncoder(new Audio());

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
    }
}
