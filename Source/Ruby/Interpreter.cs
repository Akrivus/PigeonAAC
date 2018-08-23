using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PidgeonTalk.Ruby
{
    public class Interpreter
    {
        public static string Run(string file, string argument)
        {
            using (StreamWriter writer = File.CreateText(Environment.CurrentDirectory + "//Scripts//Arguments.txt"))
            {
                writer.Write(argument);
                writer.Close();
            }
            string o = "";
            using (Process p = new Process())
            {
                ProcessStartInfo info = new ProcessStartInfo("ruby");
                info.WorkingDirectory = Environment.CurrentDirectory + "//Scripts";
                info.Arguments = Environment.CurrentDirectory + "//Scripts//" + file + ".rb";
                info.RedirectStandardOutput = true;
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = info;
                p.Start();
                o = p.StandardOutput.ReadToEnd();
            }
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(o));
        }
        public static string GenerateLine(string argument)
        {
            return Run("GenerateLine", argument);
        }
        public static string GetNext(string argument)
        {
            return Run("GetNext", argument);
        }
        public static string Colorize(string argument)
        {
            return Run("GetColor", argument);
        }
    }
}
