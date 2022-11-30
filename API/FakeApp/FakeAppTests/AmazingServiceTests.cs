using AutoFixture;
using FakeApp;
using FluentAssertions;
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
            MockBehavior behavior = MockBehavior.Loose;
            _math = new Mock<IMath>(behavior);
            _file = new Mock<IFile>(behavior);
            _amazingService = new AmazingService(_file.Object, _math.Object);

            _fixture = new Fixture();
        }

        #region LooseTests

        [Test]
        public void DoAllTheThings_CallsAdd_IsAny_Loose()
        {
            //Arrange
            int expectedAddReturnValue = _fixture.Create<int>();
            _math.Setup(x => x.Add(
                It.IsAny<int>(), //  <- Syntax reads as, Expect _math.Add(Anything, Anything) always return 
                It.IsAny<int>()))
            .Returns(expectedAddReturnValue);

            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(default, default);

            //Assert
            //Since we're only caring if CallsAdd happened and we are not returning the result of CallsAdd
            //We need to verify the call did happen
            _math.VerifyAll();
            actualFileCreated.Should().BeNullOrWhiteSpace();
        }



        [Test]
        public void DoAllTheThings_CallsAdd_Is_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAddReturnValue = _fixture.Create<int>();

            _math.Setup(x => x.Add(
                It.Is<int>(y => y == valueOne), 
                It.Is<int>(y => y == valueTwo)))
            .Returns(expectedAddReturnValue);

            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //Since we're only caring about if CallsAdd happened and we are not returning the result of CallsAdd
            //We need to verify the call did happen
            _math.VerifyAll();
            actualFileCreated.Should().BeNullOrWhiteSpace();
        }

        [Test]
        public void DoAllTheThings_CallsCreateFile_IsAny_Loose()
        {
            //Arrange
            string expectedFileCreated = _fixture.Create<string>();
            
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(default, default);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //No need to call _file.VerifyAll since returned value is Asserted
        }

        [Test]
        public void DoAllTheThings_CallsCreateFile_Is_Loose()
        {
            //Arrange
            int expectedAddReturnValue = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();


            //Since we're not having any expectations on _math.Add,
            //there isn't a way to know what's expected unless you know the details of how _math.Add works
            //So now what?
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y.Equals(expectedAddReturnValue.ToString())))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(default, default);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_IsAny_Loose()
        {
            //Arrange
            int expectedAddReturnValue = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAddReturnValue);
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(default, default);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //Should we call VerifyAll on _math and _file?
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_Is_Loose()
        {
            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAddReturnValue = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.Is<int>(y => y == valueOne), It.Is<int>(y => y == valueTwo))).Returns(expectedAddReturnValue);
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y.Equals(expectedAddReturnValue.ToString())))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //If the conditions of the setup were satisfied, why VerifyAll?
        }

        #endregion

        #region StrictTests

        [Test]
        public void DoAllTheThings_CallsAdd_IsAny_Strict()
        {
            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAddReturnValue = _fixture.Create<int>();

            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAddReturnValue);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //This fails due to the nature of Strict.
            //IFile.Create is called yet no setup.
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_IsAny_Strict()
        {
            //Arrange
            int expectedAddReturnValue = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAddReturnValue);
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(default, default);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_Is_Strict()
        {
            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAddReturnValue = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.Is<int>(y => y == valueOne), It.Is<int>(y => y == valueTwo))).Returns(expectedAddReturnValue);
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y == expectedAddReturnValue.ToString()))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
            actualFileCreated.Should().Be(expectedFileCreated);
        }
        #endregion
    }
}