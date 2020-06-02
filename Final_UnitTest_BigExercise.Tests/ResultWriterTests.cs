using Final_UnitTest_BigExercise.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace Final_UnitTest_BigExercise.Tests
{
    [TestFixture]
    public class ResultWriterTests
    {
        [Test]
        [Category("3. ResultWriterTests_WriteToFile")]
        public void WriteToFile_WhenCalled_AlwaysCreateFile()
        {
            var resultWriter = new ResultWriter();

            string path = Helpers.GetAppDirectory() + "\\WriteToFile_WhenCalled_CreateFile.txt";
            var result = new Dictionary<string, int>();

            resultWriter.WriteToFile(result, path);

            var isFileCreated = Helpers.FileExists(path);

            Assert.IsTrue(isFileCreated);
        }

        [Test]
        [Category("3. ResultWriterTests_WriteToFile")]
        public void WriteToFile_EmptyResult_CreateEmptyFile()
        {
            var resultWriter = new ResultWriter();

            string path = Helpers.GetAppDirectory() + "\\WriteToFile_EmptyResult_CreateEmptyFile.txt";
            var result = new Dictionary<string, int>();

            resultWriter.WriteToFile(result, path);

            var isEmpty = Helpers.IsEmptyFile(path);
            Assert.That(isEmpty, Is.True);
        }

        [Test]
        [Category("3. ResultWriterTests_WriteToFile")]
        public void WriteToFile_NotEmptyResult_WriteResultToFile()
        {
            var resultWriter = new ResultWriter();

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

            resultWriter.WriteToFile(result, path);

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
    }
}
