using System;
using System.Data.SQLite;
using System.Diagnostics;
using NationalInstruments.TestStand.Interop.API;
namespace TestProject
{

    public class Tests
    {
        private Calculator _calculator;

        static string DatabaseFile = @"C:\Users\smartwiresatm\Documents\JenkinsOTADB.sqlite";
        static string ConnectionString = $"Data Source={DatabaseFile};Version=3;";

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
        [Ignore("Ignore a test")]
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
                //process.WaitForExit(10000); // Wait up to 5 seconds for the script to run

                // Check the exit code if needed (0 usually indicates success)
                // Assert.AreEqual(0, process.ExitCode, "The script did not execute successfully.");
            }
        }
        [Test]
        public void RunOTA()
        {
            Process.Start(@"D:\OTA\OTA\bin\Debug\OTA.exe");
        }


        [Test]
        [Ignore("Ignore a test")]
        public void RunTestStandsScripts()
        {
            string sequenceFilePath = @"J:\SW-E2E\01-ATM Repository\Scripts Workspace\Scripts\01 Core APIs Scripts\OpenSmartInterface.seq";
            string sequenceName = "MainSequence"; // The sequence to execute
            SequenceFile seqFile = null;
            // Create an instance of the TestStand engine
            Engine testStandEngine = new Engine();
            try
            {
                // Load the sequence file
                seqFile = testStandEngine.GetSequenceFile(sequenceFilePath);

                // Get the sequence to execute
                Sequence sequence = seqFile.GetSequenceByName(sequenceName);

                // Create a new execution
                Execution execution = testStandEngine.NewExecution(
                    seqFile,
                    sequenceName,
                    null,      // Pass an execution client (null if not needed)
                    false,       // ProcessModelClient (null if not needed)
                     0
                );
                // Wait for execution to complete

                execution.WaitForEndEx(-1);


                // Handle execution results
                var result = execution.ResultStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing sequence: {ex.Message}");
            }
            finally
            {
                // Release the engine and clean up
                if (testStandEngine != null)
                {
                    testStandEngine.ReleaseSequenceFileEx(seqFile, 0);
                    testStandEngine.ShutDown(true);
                }
            }
        }



        [Ignore("Ignore a test")]
        [Test, Order(1)]
        public void RunBatScriptWithPsExec()
        {
            string batFilePath = @"psexec-script.bat";
            var processInfo = new ProcessStartInfo
            {
                FileName = $"{batFilePath}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };
            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                
                Assert.Pass();

                
                TestContext.WriteLine($"Output: {output}");
                TestContext.WriteLine($"Error: {error}");
            }
            System.Threading.Thread.Sleep(5000);
        }
        [Ignore("Ignore a test")]
        [Test, Order(2)]

        public void ReadCCStatus()
        {
            bool found = false;

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 60 * 15)
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM OTAStatus";
                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Error = reader["Error"];
                            if (Error.ToString() == "true")
                            {
                                Assert.Fail("CC OTA Failed.");
                                found = true;
                                break;
                            }
                            var status = reader["Status"];
                            if (status.ToString() == "CC OTA Completed")
                            {
                                Assert.Pass("CC OTA Completed.");
                                found = true;
                                break;
                            }

                        }
                    }
                }
                if (found) { break; }
            }


        }
        [Ignore("Ignore a test")]
        [Test, Order(3)]

        public void ReadSVMCStatus()
        {
            bool found = false;

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 60 * 15)
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM OTAStatus";
                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Error = reader["Error"];
                            if (Error.ToString() == "true")
                            {
                                Assert.Fail("SVMC OTA Failed.");
                                found = true;
                                break;
                            }
                            var status = reader["Status"];
                            if (status.ToString() == "SVMC OTA Completed")
                            {
                                Assert.Pass("SVMC OTA Completed.");
                                found = true;
                                break;
                            }

                        }
                    }
                }
                if (found) { break; }
            }


        }
        [Ignore("Ignore a test")]
        [Test, Order(4)]

        public void ReadPLCCStatus()
        {
            bool found = false;

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 60 * 15)
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    string selectQuery = "SELECT * FROM OTAStatus";
                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Error = reader["Error"];
                            if (Error.ToString() == "true")
                            {
                                Assert.Fail("PLC OTA Failed.");
                                found = true;
                                break;
                            }
                            var status = reader["Status"];
                            if (status.ToString() == "PLC OTA Completed")
                            {
                                Assert.Pass("PLC OTA Completed.");
                                found = true;
                                break;
                            }

                        }
                    }
                }
                if (found) { break; }
            }


        }
    }
}