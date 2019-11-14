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

        public static string GetFullPath(string fileName, bool include_filename = false)
        {
            if (File.Exists(fileName)) {
                if (include_filename) {
                    return Path.GetFullPath(fileName);
                }
                var path = new FileInfo(fileName).Directory.Name;
                return path;
            }

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                var check = File.Exists(fullPath);
                if (check) {
                    if (include_filename) {
                        return fullPath;
                    } else {
                        return path;
                    }
                }
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
            if (!ExistsOnPath("ffmpeg.exe")) {
                alert("FFMPEG missing, opening browser. Please ensure ffmpeg and ffprobe are in the same location as YTmp3.exe and restart the program.");
                System.Diagnostics.Process.Start("http://ffmpeg.zeranoe.com/builds/");
                return;
            }
            if (!ExistsOnPath("youtube-dl.exe")) {
                alert("youtube-dl missing, opening browser. Please ensure youtube-dl is in the same location as YTmp3.exe and restart the program.");
                System.Diagnostics.Process.Start("https://yt-dl.org/downloads/latest/youtube-dl.exe");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Downloader());
        }


    }
}
