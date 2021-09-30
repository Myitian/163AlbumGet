using System;
using System.Reflection;
using System.Windows.Forms;

namespace _163AlbumGet
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static string savedir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\",
                            tloc = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\163AlbumGet",
                            afn = "&at;", ssf = "&st;", msf = "&d;_&st;", fmt = ".mp3";
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {


                string resourceName = "_163AlbumGet." +


                new AssemblyName(args.Name).Name + ".dll";


                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    byte[] assemblyData = new byte[] { 0 };
                    if (stream != null)
                    {
                        assemblyData = new byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                    }
                    return Assembly.Load(assemblyData);
                }
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
