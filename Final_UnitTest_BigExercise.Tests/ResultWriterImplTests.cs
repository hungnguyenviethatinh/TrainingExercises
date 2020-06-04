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
            var result = new Dictionary<string, int>();
            result.Add("truong5779", 14);
            result.Add("gogomymy", 5);
            result.Add("Newboy", 2);
            result.Add("tu nhi", 1);
            result.Add("kysutach", 1);
            result.Add("data.", 1);
            result.Add("nhaquemexe", 0);
            result.Add("data1", 0);
            result.Add("accord_qng", 0);
            result.Add("TranHai", 0);
            result.Add("vixi69", 0);

            // Action
            resultWriter.WriteToFile(result, path);

            // Assert
            string[] actual = Helpers.ReadFileLineByLine(path);
            string[] expected =
            {
                "truong5779: 14",
                "gogomymy: 5",
                "Newboy: 2",
                "tu nhi: 1",
                "kysutach: 1",
                "data.: 1",
                "nhaquemexe: 0",
                "data1: 0",
                "accord_qng: 0",
                "TranHai: 0",
                "vixi69: 0"
            };

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
