using System;
using System.Speech.Synthesis;
using System.Threading;

namespace PidgeonTalk.Language
{
    public class Speaker
    {
        private static SpeechSynthesizer Base = new SpeechSynthesizer();
        private static bool Quiet = true;
        public static void Initialize()
        {
            Base.SetOutputToDefaultAudioDevice();
            Base.SelectVoiceByHints(VoiceGender.Female);
            Base.SpeakStarted += Base_SpeakStarted;
            Base.SpeakCompleted += Base_SpeakCompleted;
        }
        public static void Beep(int frequency)
        {
            new Thread(() =>
                {
                    Console.Beep(frequency, 128);
                }
            ).Start();
        }
        public static void Say(string line)
        {
            if (Quiet)
            {
                Base.SpeakAsync(line);
            }
            else
            {
                Beep(200);
            }
        }
        private static void Base_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            Quiet = false;
        }
        private static void Base_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            Quiet = true;
        }
    }
}
