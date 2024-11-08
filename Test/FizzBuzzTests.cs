using FizzBuzzComponent;
using FluentAssertions;

namespace Test
{
    public class FizzBuzzTests
    {
        FizzBuzz _sut;

        public FizzBuzzTests()
        {
            _sut = new FizzBuzz();
        }

        [Fact]
        public void ShouldInstantiate()
        {
            _sut.Should().NotBeNull();
        }

        [Fact]
        public void ProcessShouldNotBeNull()
        {
            var actual = _sut.Process(0);

            actual.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(-100, 0)]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        public void ProcessShouldGenerateAccordingToExpectedSizeAndKeyMatches(int desired, int expectedSize)
        {
            bool match = true;
            int i = 0;
            var actual = _sut.Process(desired);

            actual.Count().Should().Be(expectedSize);

            foreach(var entry in actual)
            {
                if(entry.Key != ++i)
                {
                    match = false; 
                    break;
                }
            }
            match.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(-100, 0)]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        public void ProcessShouldGenerateAccordingToExpectedSizeAndValueMatches(int desired, int expectedSize)
        {
            bool match = true;
            int i = 0;
            var actual = _sut.Process(desired);

            actual.Count().Should().Be(expectedSize);

            foreach (var entry in actual)
            {
                i++;
                if(entry.Key % 3 == 0 && entry.Key % 5 == 0)
                {
                    entry.Value.Should().Be("FizzBuzz", "Divisible by 3 and 5 should hold FizzBuzz");
                }
                else if(entry.Key % 3 == 0)
                {
                    entry.Value.Should().Be("Fizz", "Divisible by 3 Should hold Fizz");
                    
                }
                else if(entry.Key % 5 == 0)
                {
                    entry.Value.Should().Be("Buzz", "Divisible by 5 should hold Buzz");
                }
                else 
                {
                    int intTmp = int.Parse(entry.Value);
                    if(intTmp != entry.Key)
                    {
                        match = false;
                        break;
                    }
                }
            }
            match.Should().BeTrue();
        }
    }
}