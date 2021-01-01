using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _163AlbumGet
{
    public partial class FileSavingSettings : Form
    {
        public FileSavingSettings()
        {
            InitializeComponent();
        }
        private string FilenameFilter(string s)
        {
            string a = "";
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\x00':
                    case '\x01':
                    case '\x02':
                    case '\x03':
                    case '\x04':
                    case '\x05':
                    case '\x06':
                    case '\x07':
                    case '\x08':
                    case '\x09':
                    case '\x0a':
                    case '\x0b':
                    case '\x0c':
                    case '\x0d':
                    case '\x0e':
                    case '\x0f':
                    case '\x10':
                    case '\x11':
                    case '\x12':
                    case '\x13':
                    case '\x14':
                    case '\x15':
                    case '\x16':
                    case '\x17':
                    case '\x18':
                    case '\x19':
                    case '\x1a':
                    case '\x1b':
                    case '\x1c':
                    case '\x1d':
                    case '\x1e':
                    case '\x1f':
                    case '<':
                    case '>':
                    case '/':
                    case '\\':
                    case ':':
                    case '"':
                    case '*':
                    case '?':
                    default:
                        a += c;
                        break;
                }
            }
            return a;
        }

        private string FileDirFilter(string s)
        {
            string a = "";
            bool n = false;
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\x00':
                    case '\x01':
                    case '\x02':
                    case '\x03':
                    case '\x04':
                    case '\x05':
                    case '\x06':
                    case '\x07':
                    case '\x08':
                    case '\x09':
                    case '\x0a':
                    case '\x0b':
                    case '\x0c':
                    case '\x0d':
                    case '\x0e':
                    case '\x0f':
                    case '\x10':
                    case '\x11':
                    case '\x12':
                    case '\x13':
                    case '\x14':
                    case '\x15':
                    case '\x16':
                    case '\x17':
                    case '\x18':
                    case '\x19':
                    case '\x1a':
                    case '\x1b':
                    case '\x1c':
                    case '\x1d':
                    case '\x1e':
                    case '\x1f':
                    case '<':
                    case '>':
                    case '"':
                    case '*':
                    case '?':
                        break;
                    case ':':
                        if (!n)
                        {
                            n = true;
                            a += c;
                            break;
                        }
                        break;
                    default:
                        a += c;
                        break;
                }
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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹路径";
            string foldPath = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
            }
            FileSaveDirI.Text = foldPath;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            FileSaveDirI.Text = FileDirFilter(FileSaveDirI.Text);
            AlbumFolderNameI.Text = FilenameFilter(AlbumFolderNameI.Text);
            SingleSongFilenameI.Text = FilenameFilter(SingleSongFilenameI.Text);
            MultipleSongsFilenameI.Text = FilenameFilter(MultipleSongsFilenameI.Text);
            if (!(FileSaveDirI.Text.EndsWith("/") || FileSaveDirI.Text.EndsWith(@"\")))
            {
                FileSaveDirI.Text = FileSaveDirI.Text + @"\";
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
