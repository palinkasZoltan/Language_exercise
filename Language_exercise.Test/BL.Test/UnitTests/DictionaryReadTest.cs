using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language_exercise.BL;
using Language_exercise.BL.BL.Model;
using Moq;
using Repository.Interfaces;

namespace Language_exercise.Test.BL.Test.UnitTests
{
    [TestFixture]
    internal class DictionaryReadTest
    {
        List<string> testFileNames = new List<string> { "Test1.txt", "Test2.txt", "Test3.txt" };

        List<string> testFileContentForFewWordPairs = new List<string>
        {
            "Test1-TranslatedTest1", "Test2-TranslatedTest2", "Test3-TranslatedTest3",
            "Test4-TranslatedTest4", "Test5-TranslatedTest5", "Test6-TranslatedTest6",
            "Test7-TranslatedTest7",
        };

        List<string> testFileContentForMoreWordPairs = new List<string>
        {
            "Test1-TranslatedTest1", "Test2-TranslatedTest2", "Test3-TranslatedTest3",
            "Test4-TranslatedTest4", "Test5-TranslatedTest5", "Test6-TranslatedTest6",
            "Test7-TranslatedTest7", "Test8-TranslatedTest8", "Test9-TranslatedTest9",
            "Test10-TranslatedTest10", "Test11-TranslatedTest11", "Test12-TranslatedTest12",
            "Test13-TranslatedTest13", "Test14-TranslatedTest14", "Test15-TranslatedTest15",
        };

        private Dictionary<string, string> _dictionary;

        IDictionaryLogic dictLogic;

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Given_SeveralFiles_When_ReadingTheNamesOfTheFiles_Then_ReturnsTheNamesOfTheFilesWithoutFileNameExtension()
        {
            // Arrange
            Mock<IDictionaryRepository> dictRepoMock = new Mock<IDictionaryRepository>();
            dictRepoMock.Setup(mock => mock.GetExistingDatabaseFileNames()).Returns(testFileNames);
            dictLogic = new DictionaryLogic(dictRepoMock.Object);
            List<string> expectedFileNames = new List<string> { "Test1", "Test2", "Test3" };

            // Act
            List<string> result = dictLogic.GetExistingDictionaryFileNames();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(expectedFileNames.Count()));
            Assert.That(result, Is.EquivalentTo(expectedFileNames));
        }

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(7)]
        public void Given_FewerOrEqualWordPairsThanTheSpecified_When_ReadingFilesBySettings_Then_ReturnEveryWordPairInDictionary(int numberOfWords)
        {
            // Arrange
            Dictionary<string, string> expectedResult = new Dictionary<string, string>
            {
                ["Test1"] = "TranslatedTest1",
                ["Test2"] = "TranslatedTest2",
                ["Test3"] = "TranslatedTest3",
                ["Test4"] = "TranslatedTest4",
                ["Test5"] = "TranslatedTest5",
                ["Test6"] = "TranslatedTest6",
                ["Test7"] = "TranslatedTest7"
            };

            ExerciseSettings settings = ExerciseSettings.Instance;
            settings.NumberOfWords = numberOfWords;

            Mock<IDictionaryRepository> dictRepoMock = new Mock<IDictionaryRepository>();
            dictRepoMock.Setup(mock => mock.GetMultipleDictionatriesBySettings(It.IsAny<string[]>())).Returns(testFileContentForFewWordPairs);
            
            dictLogic = new DictionaryLogic(dictRepoMock.Object);

            // Act
            Dictionary<string, string> result = dictLogic.GetWordsFromMultipleDictionariesBySettings(settings);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(expectedResult.Count()), "The number of result words is not equal to the specified in the settings");
            Assert.That(result, Is.EquivalentTo(expectedResult), "The expected dictionary is not equal to the result.");
        }

        [TestCase(10)]
        [TestCase(7)]
        public void Given_MoreWordPairsThanTheSpecified_When_ReadingFilesBySettings_Then_ReturnEveryWordPairInDictionary(int numberOfWords)
        {
            // Arrange
            ExerciseSettings settings = ExerciseSettings.Instance;
            settings.NumberOfWords = numberOfWords;

            Mock<IDictionaryRepository> dictRepoMock = new Mock<IDictionaryRepository>();
            dictRepoMock.Setup(mock => mock.GetMultipleDictionatriesBySettings(It.IsAny<string[]>())).Returns(testFileContentForMoreWordPairs);

            dictLogic = new DictionaryLogic(dictRepoMock.Object);

            // Act
            Dictionary<string, string> result = dictLogic.GetWordsFromMultipleDictionariesBySettings(settings);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(numberOfWords), "The number of result words is not equal to the specified in the settings");
            Assert.That(result.Count(), Is.EqualTo(result.Distinct().Count()), "There are duplicates in the presented words.");
            for (int i = 0; i < result.Count(); i++)
            {
                string concatenatedWordPair = $"{result.ElementAt(i).Key}-{result.ElementAt(i).Value}";
                Assert.Contains(concatenatedWordPair, testFileContentForMoreWordPairs, "One of the selected wordpairs is not in the database.");
            }
        }
    }
}
