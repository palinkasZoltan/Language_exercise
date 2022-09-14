using System.Windows.Media;
using Language_exercise.BL;
using Language_exercise.BL.BL.Model;
using Language_exercise.ViewModels.Exercises;
using Moq;

namespace Language_exercise.Test.ViewModelTest.UnitTests
{
    [TestFixture]
    internal class ReadyMadeExerciseViewModelTests
    {
        ReadyMadeVocabularyExerciseViewModel viewModel;

        private const string redColor = "#FFFF0000";

        private const string lightGreenColor = "#FF90EE90";

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(
            "Test1",
            "Good job!",
            lightGreenColor)]
        [TestCase(
            "WrongAnswer",
            "Too bad!",
            redColor)]
        public void Given_CorrectAnswer_When_ExecutingSubmitCommand_Then_UiShowesTheCorrectResultMessage(string givenAnswer, object expectedMessage, string expectedColor)
        {
            // Arrange
            CreateViewModel();
            viewModel.ResultText = givenAnswer;

            // Act
            viewModel.SubmitCommand.Execute(null);
            double expectedProgressbarValue = 100 / viewModel.WordsToExercise.Count;

            // Assert
            Assert.That(viewModel.ResultMessage, Is.EqualTo(expectedMessage));
            Assert.That(viewModel.ResultBackground.ToString(), Is.EqualTo(expectedColor));
            Assert.That(viewModel.ProgressbarValue, Is.EqualTo(expectedProgressbarValue));
        }

        private void CreateViewModel()
        {
            Mock<IExerciseLogic> exerciseLogicMock = new Mock<IExerciseLogic>();
            Mock<IStatisticsLogic> statisticsLogicMock = new Mock<IStatisticsLogic>();
            Mock<Exercise> exerciseMock = new Mock<Exercise>();

            Dictionary<string, string> wordPairs = new Dictionary<string, string>
            {
                ["Test1"] = "TranslatedTest1",
                ["Test2"] = "TranslatedTest2",
            };
            exerciseMock.Setup(mock => mock.WordsToExercise).Returns(wordPairs);
            exerciseLogicMock.Setup(mock => mock.ConstructNewExercise()).Returns(exerciseMock.Object);
            viewModel = new ReadyMadeVocabularyExerciseViewModel(exerciseLogicMock.Object, statisticsLogicMock.Object);
        }

    }
}
