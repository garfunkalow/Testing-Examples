using FakeApp;
using FluentAssertions;
using NUnit.Framework;

namespace FakeAppTests
{
    [TestFixture]
    public class FunFileTests
    {
        private IFile _file;

        [SetUp]
        public void SetUp()
        {
            _file = new FilesAreRad();
        }
        
        [Test]
        public void LineTestFallacy_100PercentLineCoverage()
        {
            var fileLength = _file.GetFileLength("BurritosAreAwesome.txt");
            fileLength.Should().BeGreaterThan(0);
        }

        [Test]
        public void LineTestFallacy_UhOh()
        {
            var fileLength = _file.GetFileLength(string.Empty);
            fileLength.Should().Be(0);
        }

    }
}