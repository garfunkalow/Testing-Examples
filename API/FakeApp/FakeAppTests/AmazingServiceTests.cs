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
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAdd);

            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //Since we're only caring about if CallsAdd happened and we are not returning the result of CallsAdd
            //We need to verify the call did happen
            _math.VerifyAll();
        }



        [Test]
        public void DoAllTheThings_CallsAdd_Is_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();

            _math.Setup(x => x.Add(It.Is<int>(y => y == valueOne), It.Is<int>(y => y == valueTwo))).Returns(expectedAdd);

            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //Since we're only caring about if CallsAdd happened and we are not returning the result of CallsAdd
            //We need to verify the call did happen
            _math.VerifyAll();
        }

        [Test]
        public void DoAllTheThings_CallsCreateFile_IsAny_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();

            string expectedFileCreated = _fixture.Create<string>();
            
            _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
        }

        [Test]
        public void DoAllTheThings_CallsCreateFile_Is_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();


            //Since we're not having any expectations on _math,
            //there isn't a way to know what's expected unless you know the details of how _math works
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y.Equals(expectedAdd.ToString())))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
        }

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_IsAny_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(valueOne, valueTwo)).Returns(expectedAdd);
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y.Equals(expectedAdd.ToString())))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
            // _math.VerifyAll();
            // _file.VerifyAll();
        }


        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_Is_Loose()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(valueOne, valueTwo)).Returns(expectedAdd);
            _file.Setup(x => x.CreateFile(It.Is<string>(y => y.Equals(expectedAdd.ToString())))).Returns(expectedFileCreated);
            //Act
            var actualFileCreated = _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            actualFileCreated.Should().Be(expectedFileCreated);
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
            // _math.VerifyAll();
            // _file.VerifyAll();
        }

        #endregion

        #region StrictTests

        [Test]
        public void DoAllTheThings_CallsAdd_CallsCreateFile_IsAny_Strict()
        {

            //Arrange
            int valueOne = _fixture.Create<int>();
            int valueTwo = _fixture.Create<int>();
            int expectedAdd = _fixture.Create<int>();
            string expectedFileCreated = _fixture.Create<string>();
            _math.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedAdd);
            // _file.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(expectedFileCreated);
            //Act
            _amazingService.DoAllTheThings(valueOne, valueTwo);

            //Assert
            //If the conditions of the setup were satisfied, why assert?
            //Did the expected interactions really take place?
            _math.VerifyAll();
            _file.VerifyAll();
        }

        #endregion


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