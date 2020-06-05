using FinalUnitTestBigExercise.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FinalUnitTestBigExercise.Tests
{
    [TestFixture]
    public class ResultWriterImplTests
    {
        [Test]
        [Category("3. ResultWriterImplTests_WriteToFile")]
        public void WriteToFile_WhenCalled_AlwaysCreateFile()
        {
            // Arrange
            var resultWriter = new ResultWriterImpl();

            string path = Helpers.GetAppDirectory() + "\\WriteToFile_WhenCalled_CreateFile.txt";
            var result = new Dictionary<string, int>();

            // Action
            resultWriter.WriteToFile(result, path);

            // Assert
            var isFileCreated = Helpers.FileExists(path);

            Assert.IsTrue(isFileCreated);
        }

        [Test]
        [Category("3. ResultWriterImplTests_WriteToFile")]
        public void WriteToFile_EmptyResult_CreateEmptyFile()
        {
            // Arrange
            var resultWriter = new ResultWriterImpl();

            string path = Helpers.GetAppDirectory() + "\\WriteToFile_EmptyResult_CreateEmptyFile.txt";
            var result = new Dictionary<string, int>();

            // Action
            resultWriter.WriteToFile(result, path);

            // Assert
            var isEmpty = Helpers.IsEmptyFile(path);

            Assert.That(isEmpty, Is.True);
        }

        [Test]
        [Category("3. ResultWriterImplTests_WriteToFile")]
        public void WriteToFile_NotEmptyResult_WriteResultToFile()
        {
            // Arrange
            var resultWriter = new ResultWriterImpl();

            string path = Helpers.GetAppDirectory() + "\\WriteToFile_NotEmptyResult_WriteResultToFile.txt";
            var result = Helpers.CreateFakeResult();

            // Action
            resultWriter.WriteToFile(result, path);

            // Assert
            string[] actual = Helpers.ReadFileLineByLine(path);
            string[] expected = Helpers.CreateExpectedResult();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"d:\test\test.txt")]
        [Category("3. ResultWriterImplTests_WriteToFile")]
        public void WriteToFile_NonExistPath_Throws(string path)
        {
            // Arrange
            var resultWriter = new ResultWriterImpl();

            var result = new Dictionary<string, int>();

            // Action
            var exception = Assert.Catch<Exception>(() => resultWriter.WriteToFile(result, path));

            // Assert
            StringAssert.Contains($"Could not find a part of the path '{path}'", exception.Message);
        }
    }
}
