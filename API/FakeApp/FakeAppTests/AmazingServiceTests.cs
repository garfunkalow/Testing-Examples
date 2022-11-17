using AutoFixture;
using FakeApp;
using Moq;
using NUnit.Framework;

namespace FakeAppTests
{
    [TestFixture]
    public class AmazingServiceTests
    {
        private Mock<IMath> _math;
        private Mock<IFile> _file;
        private AmazingService _amazingService;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            MockBehavior behavior = MockBehavior.Strict;
            _math = new Mock<IMath>(behavior);
            _file = new Mock<IFile>(behavior);
            _amazingService = new AmazingService(_file.Object, _math.Object);

            _fixture = new Fixture();
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_IsAny()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAdd);
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_Is()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAdd);
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
        }
        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_WithCallBack()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAdd);
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
        }
    }
}