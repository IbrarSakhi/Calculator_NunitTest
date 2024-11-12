using System.Diagnostics;

namespace TestProject
{

    public class Tests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void LaunchEXETest()
        {
            // Specify the path to the executable
            string exePath = @"C:\Windows\SysWOW64\calc.exe";

            // Set up the process start info
            var startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                UseShellExecute = true,     // Ensure shell execute for GUI apps
                WindowStyle = ProcessWindowStyle.Normal  // Normal window (can also be minimized, etc.)
            };

            using (var process = Process.Start(startInfo))
            {
                // Optionally, wait for the process to complete or give it a timeout
                process.WaitForExit();

                // Assert that the process exited successfully
                Assert.AreEqual(0, process.ExitCode, "The EXE did not exit successfully.");
            }
        }

        [Test]
        [Ignore("Ignore a test")]
        public void OpenSmartInterface()
        {
            bool result = _calculator.StartTool();
            Assert.AreEqual(false, result);
        }
        [Test]
        [Ignore("Ignore a test")]
        public void Test1()
        {
            int result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }
        [Test]
        [Ignore("Ignore a test")]
        public void Subtract()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.AreEqual(1, result);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void Multiply()
        {
            int result = _calculator.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void Divide()
        {
            int result = _calculator.Multiply(15, 5);
            Assert.AreEqual(5, result);
            //Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}