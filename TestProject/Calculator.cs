using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Calculator
    {
        public int Add(int number1, int number2)
        {
            return (number1 + number2);
        }
        public int Subtract(int number1, int number2)
        {
            return (number1 - number2);
        }
        public int Multiply(int number1, int number2)
        {
            return (number1 * number2);
        }
        public int Divide(int number1, int number2)
        {
            return (number1 / number2);
        }
        private Process ApplicationProcess;
        Process[] processArray; //Field
        public bool StartTool(string toolPath = @"C:\Program Files (x86)\Smart Wires\SmartInterface", string processName = "SmartInterface")
        {
            if (String.IsNullOrEmpty(toolPath) || String.IsNullOrEmpty(processName))
            {
                return true;
            }
            try
            {
                CloseTool(processName);
                ProcessStartInfo objCmd = new ProcessStartInfo(toolPath + "\\" + processName);
                objCmd.UseShellExecute = false;
                ApplicationProcess = Process.Start(objCmd);
                Thread.Sleep(100);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        public void CloseTool(string nameOfProcessInTaskManager)
        {
            if (String.IsNullOrEmpty(nameOfProcessInTaskManager))
            {
                return;
            }
            try
            {
                processArray = Process.GetProcessesByName(nameOfProcessInTaskManager);
                if (processArray.Length != 0)
                {
                    for (int i = 0; i < processArray.Length; i++)
                    {
                        processArray[i].Kill();
                        Thread.Sleep(100);
                    }
                    ApplicationProcess = null;
                }
            }
            catch (Exception ex)
            {
            }
            return;
        }


    }
}
