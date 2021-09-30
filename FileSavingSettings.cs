using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace _163AlbumGet
{
    public partial class FileSavingSettings : Form
    {
        public FileSavingSettings()
        {
            InitializeComponent();
        }

        public static string FileNameFilter(string s, char? replacechar = null)
        {
            char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
            string a = "";
            foreach (char c in s)
            {
                if (InvalidFileNameChars.Contains(c))
                {
                    if (replacechar is null) continue;
                    else a += replacechar;
                }
                else a += c;
            }
            return a;
        }

        public static string PathFilter(string s, char? replacechar = null)
        {
            char[] InvalidPathChars = Path.GetInvalidPathChars().Concat(new char[] { '*', '?' }).ToArray();
            string a = "";
            bool n = false;
            foreach (char c in s)
            {
                if (c == ':')
                {
                    if (!n)
                    {
                        n = true;
                        a += c;
                    }
                    else
                    {
                        if (replacechar is null) continue;
                        else a += replacechar;
                    }
                }
                else if (InvalidPathChars.Contains(c))
                {
                    if (replacechar is null) continue;
                    else a += replacechar;
                }
                else a += c;
            }
            return a;
        }
        private bool ReplaceCHK(string i, string d)
        {
            if (!i.Contains("&"))
            {
                return true;
            }
            int a = i.IndexOf("&");
            i = i.Substring(a + 1);
            int b = i.IndexOf(";");
            if (b > 0)
            {
                i = i.Substring(0, b);
                switch (i)
                {
                    case "d":
                    case "aa":
                    case "at":
                    case "ai":
                    case "st":
                    case "si":
                    case "&":
                        break;
                    default:
                        Error("文件替换符错误，请检查是否符合替换规则！", "错误地点：" + d);
                        return false;
                }
                return true;
            }
            else
            {
                Error("文件替换符错误，请检查是否符合替换规则！", "错误地点：" + d);
                return false;
            }
        }
        private void Error(string s,string t)
        {
            Err.ForeColor = Color.Red;
            Err.Text = s;
            ErrLoc.ForeColor = Color.Red;
            ErrLoc.Text = t;
        }
        private void DefaultFSD_Click(object sender, EventArgs e)
        {
            FileSaveDirI.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
        }

        private void DefaultAFN_Click(object sender, EventArgs e)
        {
            AlbumFolderNameI.Text = "&at;";
        }

        private void DefaultSSF_Click(object sender, EventArgs e)
        {
            SingleSongFilenameI.Text = "&st;";
        }

        private void DefaultMSF_Click(object sender, EventArgs e)
        {
            MultipleSongsFilenameI.Text = "&d;_&st;";
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择文件夹路径"
            };
            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    FileSaveDirI.Text = dialog.SelectedPath;
                    break;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            FileSaveDirI.Text = PathFilter(FileSaveDirI.Text);
            AlbumFolderNameI.Text = FileNameFilter(AlbumFolderNameI.Text);
            SingleSongFilenameI.Text = FileNameFilter(SingleSongFilenameI.Text);
            MultipleSongsFilenameI.Text = FileNameFilter(MultipleSongsFilenameI.Text);
            if (!(FileSaveDirI.Text.EndsWith("/") || FileSaveDirI.Text.EndsWith(@"\")))
            {
                FileSaveDirI.Text += @"\";
            }
            if (FileSaveDirI.Text != "" ||
                AlbumFolderNameI.Text != "" ||
                SingleSongFilenameI.Text != "" ||
                MultipleSongsFilenameI.Text != "")
            {
                if (ReplaceCHK(FileSaveDirI.Text, "文件保存地址 文本框") &&
                    ReplaceCHK(AlbumFolderNameI.Text, "专辑文件夹名称 文本框") &&
                    ReplaceCHK(SingleSongFilenameI.Text, "歌曲文件名称（单个下载） 文本框") &&
                    ReplaceCHK(MultipleSongsFilenameI.Text, "歌曲文件名称（批量下载） 文本框"))
                {
                    Program.afn = AlbumFolderNameI.Text;
                    Program.ssf = SingleSongFilenameI.Text;
                    Program.msf = MultipleSongsFilenameI.Text;
                    IniFiles ini = new IniFiles(Program.tloc + @"\settings.ini");
                    ini.IniWriteValue("163AlbumGet", "AlbumFolderName", Program.afn);
                    ini.IniWriteValue("163AlbumGet", "SingleSongFilename", Program.ssf);
                    ini.IniWriteValue("163AlbumGet", "MultipleSongsFilename", Program.msf);
                    if (!Directory.Exists(FileSaveDirI.Text))//如果不存在就创建 dir 文件夹
                    {
                        DialogResult dr = MessageBox.Show("路径不存在！是否创建路径？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            Directory.CreateDirectory(FileSaveDirI.Text);
                            Program.savedir = FileSaveDirI.Text;
                            ini.IniWriteValue("163AlbumGet", "FileSaveDir", Program.savedir);
                            Close();
                        }
                        else
                        {
                            Program.savedir = FileSaveDirI.Text;
                            ini.IniWriteValue("163AlbumGet", "FileSaveDir", Program.savedir);
                            Close();
                        }
                    }
                    else
                    {
                        Program.savedir = FileSaveDirI.Text;
                        ini.IniWriteValue("163AlbumGet", "FileSaveDir", Program.savedir);
                        Close();
                    }
                }
            }
            else
            {
                Error("文件名不能为空！", "");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FileSavingSettings_Load(object sender, EventArgs e)
        {
            FileSaveDirI.Text = Program.savedir;
            AlbumFolderNameI.Text = Program.afn;
            SingleSongFilenameI.Text = Program.ssf;
            MultipleSongsFilenameI.Text = Program.msf;
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutPage f = new AboutPage();
            f.ShowDialog();
        }
    }
}
