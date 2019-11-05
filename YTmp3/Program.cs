using System;
using System.Windows.Forms;
using static YTmp3.Downloader;
using System.IO;

namespace YTmp3
{
    public static class Program
    {

        public static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
               return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }
        public static void alert(string text) {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (!ExistsOnPath("ffmpeg.exe") || !ExistsOnPath("ffprobe.exe")) {
                alert("FFMPEG missing, opening browser. Please ensure ffmpeg.exe and ffprobe.exe are in the same location as YTmp3.exe and restart the program.");
                System.Diagnostics.Process.Start("http://ffmpeg.zeranoe.com/builds/");
                return;
            }
            if (!ExistsOnPath("youtube-dl.exe")) {
                alert("youtube-dl missing, opening browser. Please ensure youtube-dl.exe is in the same location as YTmp3.exe and restart the program.");
                System.Diagnostics.Process.Start("https://yt-dl.org/downloads/latest/youtube-dl.exe");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Downloader());
        }


    }
}
