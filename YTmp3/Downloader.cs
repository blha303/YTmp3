using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YTmp3
{
    public partial class Downloader : Form
    {
        private List<Process> plist = new List<Process>();
        public Downloader()
        {
            InitializeComponent();
            // Defined here because, when included in Designer class, WYSIWYG editor expands USERPROFILE variable into C:\Users\Username for some reason
            this.pathBox.Text = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Music");
            Console.SetOut(new Writers.TextBoxWriter(this.outputBox));
            Application.ApplicationExit += new System.EventHandler(this.cancelBtn_Click);
        }

        public enum DLOptions
        {
            MP3,
            M4A,
            BESTVIDEO,
            MP4
        }

        // If ffmpeg is not included in path, intermediate files such as .webm or DASH-format .m4a may be produced by this function
        public static Process Download(string url, DLOptions quality, string path)
        {
            string arguments = string.Format("{0} --ffmpeg-location \"{1}\" --no-progress --continue --no-overwrites -o \"%(title)s.%(ext)s\" ", url, Application.StartupPath);
            switch (quality) {
                case DLOptions.MP3:
                    arguments += "--extract-audio --audio-format mp3";
                    break;
                case DLOptions.M4A:
                    arguments += "-f 'bestaudio[ext=m4a]'";
                    break;
                case DLOptions.MP4:
                    arguments += "--recode-video mp4";
                    break;
                case DLOptions.BESTVIDEO:
                    break;
            }

            Process p = new Process();
            p.StartInfo.FileName = "youtube-dl";
            p.StartInfo.Arguments = arguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WorkingDirectory = path;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            p.ErrorDataReceived += (sender, args) => Console.WriteLine(args.Data);
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            return p;
        }

        private void folderPickerBtn_Click(object sender, EventArgs e)
        {
            DialogResult folderPickerBtn_Click = folderBrowserDialog1.ShowDialog();
            if (folderPickerBtn_Click == DialogResult.OK)
            {
                pathBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            foreach (string line in urlBox.Text.Split('\n'))
            {
                plist.Add(Download(line, (DLOptions)comboBox1.SelectedValue, this.pathBox.Text));
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            foreach (Process p in plist)
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
            }
        }
    }
}
