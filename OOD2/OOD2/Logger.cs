using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOD2
{
    class Logger
    {
        
            private static string logFileName = "_log_" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_" + DateTime.Now.ToString("yyyy-dd-M") + ".txt";
            private static string logFilePath = @"C:\\errorLogs\\";


            public static string LogFilePath
            {
                get { return logFilePath; }
            }

            public static void flush()
            {
                File.WriteAllText(Path.Combine(logFilePath, logFileName), string.Empty);
            }

            public static void CreateLogFile()
            {
                Directory.CreateDirectory(Logger.logFilePath);
            }

            public static void logwriter(string msg, string stk)
            {
                if (Directory.Exists(Logger.logFilePath))
                {
                    if (msg.Length > 0)
                    {
                        StreamWriter sw;
                        sw = File.AppendText(logFilePath + logFileName);
                        sw.WriteLine("+ {0} {1}: Message: {2} Details: {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), msg, stk);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        StreamWriter sw;
                        sw = File.AppendText(logFilePath + logFileName);
                        sw.WriteLine("+ {0} {1}: Message: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Message was not returned.");
                        sw.Flush();
                        sw.Close();

                    }
                }
                else
                {
                    CreateLogFile();
                    if (msg.Length > 0)
                    {
                        StreamWriter sw;
                        sw = File.AppendText(logFilePath + logFileName);
                        sw.WriteLine("+ {0} {1}: Message: {2} Details: {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), msg, stk);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        StreamWriter sw;
                        sw = File.AppendText(logFilePath + logFileName);
                        sw.WriteLine("+ {0} {1}: Message: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Message was not returned.");
                        sw.Flush();
                        sw.Close();
                    }
                }


            }

        
    }
}
