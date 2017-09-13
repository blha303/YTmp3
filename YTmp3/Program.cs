using System;
using System.Windows.Forms;
using static YTmp3.Downloader;

namespace YTmp3
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                DLOptions choice = DLOptions.MP3;
                string qualityoptions = string.Join(",", Enum.GetNames(typeof(DLOptions))).ToLower();
                string path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Music");
                foreach (string arg in args)
                {
                    if (arg[0] == '/') {
                        if (arg[1] == 'h' || arg[1] == '?')
                        {
                            Console.WriteLine("YTmp3 by Steven Smith");
                            Console.WriteLine("Usage: YTmp3 <urls...> [/h] [/q{" + qualityoptions + "}]");
                            return;
                        }
                        if (arg[1] == 'q')
                        {
                            if (!Enum.TryParse(arg.Substring(2), out choice))
                            {
                                Console.WriteLine("Invalid quality option! Choices: " + qualityoptions);
                            }
                        }
                        if (arg[1] == 'p')
                        {
                            path = arg.Substring(2);
                        }
                        continue;
                    }
                    Console.WriteLine("Starting on " + arg);
                    Downloader.Download(arg, choice, path);
                }
                return;
            }

            if (Type.GetType("Mono.Runtime") != null)
            {
                Console.WriteLine("This probably won't work! Try YTmp3 /h");
            } else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Downloader());
            }
        }


    }
}
