using PidgeonTalk.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PidgeonTalk
{
    public static class Program
    {
        public static void Main()
        {
            Speaker.Initialize();
            Begin();
        }
        public static void Begin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interface());
        }
    }
}
