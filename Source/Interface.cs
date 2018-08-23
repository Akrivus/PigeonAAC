using PidgeonTalk.Language;
using PidgeonTalk.Ruby;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PidgeonTalk
{
    public partial class Interface : Form
    {
        private string LastKey = "";
        private int Loc = 0;
        public Interface()
        {
            InitializeComponent();
        }
        private void Interface_Load(object sender, EventArgs e)
        {
            LoadUpIcons("");
        }
        private void Entry1_Click(object sender, EventArgs e)
        {
            Output.AppendText(Entry1.Text + " ");
            LoadUpIcons(Entry1.Text);
            Speaker.Beep(200);
        }
        private void Entry2_Click(object sender, EventArgs e)
        {
            Output.AppendText(Entry2.Text + " ");
            LoadUpIcons(Entry2.Text);
            Speaker.Beep(200);
        }
        private void Entry3_Click(object sender, EventArgs e)
        {
            Output.AppendText(Entry3.Text + " ");
            LoadUpIcons(Entry3.Text);
            Speaker.Beep(200);
        }
        private void Entry4_Click(object sender, EventArgs e)
        {
            Output.AppendText(Entry4.Text + " ");
            LoadUpIcons(Entry4.Text);
            Speaker.Beep(200);
        }
        private void Entry5_Click(object sender, EventArgs e)
        {
            Output.AppendText(Entry5.Text + " ");
            LoadUpIcons(Entry5.Text);
            Speaker.Beep(200);
        }
        private void EntryMore_Click(object sender, EventArgs e)
        {
            LoadUpIcons(LastKey, Loc + 5);
            Speaker.Beep(600);
        }
        private void EntryYes_Click(object sender, EventArgs e)
        {
            Speaker.Say("Yes");
        }
        private void EntryNo_Click(object sender, EventArgs e)
        {
            Speaker.Say("No");
        }
        private void EntryHello_Click(object sender, EventArgs e)
        {
            Speaker.Say("Hello!");
        }
        private void EntryGoodbye_Click(object sender, EventArgs e)
        {
            Speaker.Say("Goodbye!");
        }
        private void EntryHelp_Click(object sender, EventArgs e)
        {
            Speaker.Say("Help!");
        }
        private void Play_Click(object sender, EventArgs e)
        {
            Speaker.Say(Interpreter.GenerateLine(Output.Text));
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Output.Clear();
            Speaker.Beep(200);
            LoadUpIcons("");
        }
        private void LoadUpIcons(string key, int start = 0)
        {
            int off = 0;
            string[] icons = Interpreter.GetNext(key).Split(',');
            Entry1.BackColor = Color.Silver; Entry1.Text = "";
            Entry2.BackColor = Color.Silver; Entry2.Text = "";
            Entry3.BackColor = Color.Silver; Entry3.Text = "";
            Entry4.BackColor = Color.Silver; Entry4.Text = "";
            Entry5.BackColor = Color.Silver; Entry5.Text = "";
            if (icons.Length > 1)
            {
                for (int i = start; i < start + 5; ++i)
                {
                    if (i == start + 0)
                    {
                        if (i < icons.Length)
                        {
                            Entry1.BackColor = Color.FromName(Interpreter.Colorize(icons[i]));
                            Entry1.Text = icons[i];
                        }
                        else
                        {
                            Entry1.BackColor = Color.FromName(Interpreter.Colorize(icons[off]));
                            Entry1.Text = icons[off];
                            ++off;
                            Loc = -5;
                        }
                    }
                    if (i == start + 1)
                    {
                        if (i < icons.Length)
                        {
                            Entry2.BackColor = Color.FromName(Interpreter.Colorize(icons[i]));
                            Entry2.Text = icons[i];
                        }
                        else
                        {
                            Entry2.BackColor = Color.FromName(Interpreter.Colorize(icons[off]));
                            Entry2.Text = icons[off];
                            ++off;
                            Loc = -5;
                        }
                    }
                    if (i == start + 2)
                    {
                        if (i < icons.Length)
                        {
                            Entry3.BackColor = Color.FromName(Interpreter.Colorize(icons[i]));
                            Entry3.Text = icons[i];
                        }
                        else
                        {
                            Entry3.BackColor = Color.FromName(Interpreter.Colorize(icons[off]));
                            Entry3.Text = icons[off];
                            ++off;
                            Loc = -5;
                        }
                    }
                    if (i == start + 3)
                    {
                        if (i < icons.Length)
                        {
                            Entry4.BackColor = Color.FromName(Interpreter.Colorize(icons[i]));
                            Entry4.Text = icons[i];
                        }
                        else
                        {
                            Entry4.BackColor = Color.FromName(Interpreter.Colorize(icons[off]));
                            Entry4.Text = icons[off];
                            ++off;
                            Loc = -5;
                        }
                    }
                    if (i == start + 4)
                    {
                        if (i < icons.Length)
                        {
                            Entry5.BackColor = Color.FromName(Interpreter.Colorize(icons[i]));
                            Entry5.Text = icons[i];
                        }
                        else
                        {
                            Entry5.BackColor = Color.FromName(Interpreter.Colorize(icons[off]));
                            Entry5.Text = icons[off];
                            ++off;
                            Loc = -5;
                        }
                    }
                }
            }
            Loc = start;
            if (start == 0)
            {
                LastKey = key;
                Loc = 0;
            }
        }
    }
}
