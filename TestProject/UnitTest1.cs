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
        [Ignore("Ignore a test")]
        public void LaunchEXETest()
        {
            // Specify the path to the executable
            string exePath = @"C:\Program Files (x86)\Smart Wires\SmartInterface\SmartInterface.exe";

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


        [Test]
        public void RunScriptAndOpenExeTest()
        {
            // Path to the batch script
            string scriptPath = @"LaunchApp.bat";

            // Ensure the script exists before trying to start it
            Assert.IsTrue(File.Exists(scriptPath), "Batch script not found at specified path.");

            // Set up the process start info for the batch file
            var startInfo = new ProcessStartInfo
            {
                FileName = scriptPath,
                UseShellExecute = true,
                CreateNoWindow = false,                   // Run the script without a window
                WindowStyle = ProcessWindowStyle.Normal  // Ensure it runs hidden
            };

            using (var process = Process.Start(startInfo))
            {
                Assert.IsNotNull(process, "Process could not be started.");

                // Optionally, wait for the process to complete or set a timeout
                process.WaitForExit(10000); // Wait up to 5 seconds for the script to run

                // Check the exit code if needed (0 usually indicates success)
                Assert.AreEqual(0, process.ExitCode, "The script did not execute successfully.");
            }
        }
    }
}