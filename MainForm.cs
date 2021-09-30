using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _163AlbumGet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool AlbumIDInputOnFocus = false;
        RootObject rb;
        TimeSpan ts;
        int idata0, idata1;
        string loc = Program.tloc, exp = "",
            ls1, ls2, ls3,
            sdata0, sdata1, sdata2, sdataa,
            dlerr = "";

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && AlbumIDInputOnFocus)
            {
                GET();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DLAllSong_Click(object sender, EventArgs e)
        {
            if (rb != null)
            {
                string ls5 = Conv(Program.afn, "", "", rb.rb[0].album.name, rb.rb[0].album.id.ToString(), "", "");
                Directory.CreateDirectory(SaveLoc.Text + ls5);
                ProcessB.Maximum = rb.rb.Count;
                ProcessL.Text = rb.rb.Count.ToString();
                string locx;
                int DLfailedcount = 0;
                IniFiles ini = new IniFiles(SaveLoc.Text + ls5 + @"\下载失败的文件.ini");
                for (int i=0;i< rb.rb.Count; i++)
                {
                    string ls4 = "";
                    for (int i2 = 0; i2 < rb.rb[i].artists.Count; i2++)
                    {
                        if (i2 != 0)
                        {
                            ls4 += ";";
                        }
                        ls4 += rb.rb[i].artists[i2].name;
                    }
                    string ls6 = Conv(Program.msf,
                                        i.ToString().PadLeft((rb.rb.Count - 1).ToString().Length, '0'),
                                        ls4,
                                        rb.rb[0].album.name,
                                        rb.rb[0].album.id.ToString(),
                                        rb.rb[i].name.ToString(),
                                        rb.rb[i].id.ToString());
                    locx = FileSavingSettings.PathFilter(SaveLoc.Text + ls5 + @"\" + ls6 + Program.fmt, '_');
                    if (!DownloadFile("http://music.163.com/song/media/outer/url?id=" + rb.rb[i].id.ToString() + Program.fmt, locx))
                    {
                        Error("下载失败 (" + (i + 1).ToString() + ")");
                        ini.IniWriteValue("DownloadFailed", "count", (DLfailedcount + 1).ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲编号", (i + 1).ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲名称", rb.rb[i].name.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲ID", rb.rb[i].id.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "源地址", "http://music.163.com/song/media/outer/url?id=" + rb.rb[i].id.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "保存路径", locx);
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "错误提示", dlerr);
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "可能原因", "网络问题");
                        DLfailedcount++;
                        dlerr = "";
                    }
                    using (FileStream fs = File.OpenRead(locx))
                    {
                        if (fs.ReadByte() == '<')
                        {
                        File.Delete(locx);
                        Error("下载失败，可能原因：版权限制或地区限制 (" + (i + 1).ToString() + ")");
                        ini.IniWriteValue("DownloadFailed", "count", DLfailedcount.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲编号", (i + 1).ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲名称", rb.rb[i].name.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "歌曲ID", rb.rb[i].id.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "源地址", "http://music.163.com/song/media/outer/url?id=" + rb.rb[i].id.ToString());
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "保存路径", locx);
                        ini.IniWriteValue("Error" + DLfailedcount.ToString(), "可能原因", "版权限制或地区限制");
                        DLfailedcount++;
                    }
                    }
                    ProcessB.Value = i + 1;
                }
                if (DLfailedcount != 0)
                {
                    ini.IniWriteValue("DownloadFailed", "count", DLfailedcount.ToString());
                }
                else
                {
                    Success("下载成功！位置：" + SaveLoc.Text + ls5 + @"\");
                    ProcessB.Value = 0;
                    ProcessL.Text = "0";
                }
            }
        }

        private void DLSettings_Click(object sender, EventArgs e)
        {
            FileSavingSettings f = new FileSavingSettings();
            f.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            SaveLoc.Text = Program.savedir;
        }

        private void DLSong_Click(object sender, EventArgs e)
        {
            if (SongListBox.SelectedItem != null)
            {
                string ls4 = "";
                for (int i2 = 0; i2 < rb.rb[SongListBox.SelectedIndex].artists.Count; i2++)
                {
                    if (i2 != 0) ls4 += ";";

                    ls4 += rb.rb[SongListBox.SelectedIndex].artists[i2].name;
                }
                string locx = SaveLoc.Text + 
                                Conv(Program.ssf, 
                                        "", 
                                        ls4, 
                                        rb.rb[0].album.name, 
                                        rb.rb[0].album.id.ToString(), 
                                        rb.rb[SongListBox.SelectedIndex].name, 
                                        rb.rb[SongListBox.SelectedIndex].id.ToString()) +
                                Program.fmt;
                locx = FileSavingSettings.PathFilter(locx, '_');
                Directory.CreateDirectory(SaveLoc.Text + @"\");
                if (DownloadFile("http://music.163.com/song/media/outer/url?id=" + rb.rb[SongListBox.SelectedIndex].id.ToString(), locx))
                {
                    Success("下载成功！位置：" + locx);
                }
                else
                {
                    Error("下载失败 " + dlerr);
                    dlerr = "";
                }
                using (FileStream fs = File.OpenRead(locx))
                {
                    if (fs.ReadByte() == '<')
                {
                    File.Delete(locx);
                    Error("下载失败，可能原因：版权限制或地区限制");
                }
            }
        }
        }

        private void SaveLoc_TextChanged(object sender, EventArgs e)
        {
            if (!(SaveLoc.Text.EndsWith("/") || SaveLoc.Text.EndsWith(@"\")))
            {
                SaveLoc.Text += @"\";
            }
            Program.savedir = SaveLoc.Text;
            IniFiles ini = new IniFiles(Program.tloc + @"\settings.ini");
            ini.IniWriteValue("163AlbumGet", "FileSaveDir", Program.savedir);
        }

        private void GoToPG_Click(object sender, EventArgs e)
        {
            if (SongListBox.SelectedItem != null)
            {
                System.Diagnostics.Process.Start("https://music.163.com/song?id=" + rb.rb[SongListBox.SelectedIndex].id.ToString());
            }
        }

        private void SaveDataAsINI_Click(object sender, EventArgs e)
        {
            if (rb != null)
            {
                string ls4 = Conv(Program.afn, "", "", rb.rb[0].album.name, rb.rb[0].album.id.ToString(), "", "");
                Directory.CreateDirectory(SaveLoc.Text + ls4);
                IniFiles ini = new IniFiles(SaveLoc.Text + ls4 + @"\专辑信息.ini");
                ini.IniWriteValue("AlbumInfo", "id", rb.rb[0].album.id.ToString());
                ini.IniWriteValue("AlbumInfo", "name", rb.rb[0].album.name);
                ini.IniWriteValue("AlbumInfo", "picUrl", rb.rb[0].album.picUrl);
                ini.IniWriteValue("AlbumInfo", "count", rb.rb.Count.ToString());
                for (int i = 0; i < rb.rb.Count; i++)
                {
                    ini.IniWriteValue("Song" + i.ToString(), "id", rb.rb[i].id.ToString());
                    ini.IniWriteValue("Song" + i.ToString(), "name", rb.rb[i].name);
                    ini.IniWriteValue("Song" + i.ToString(), "duration", rb.rb[i].duration.ToString());
                    ls2 = "";
                    for (int i2 = 0; i2 < rb.rb[i].artists.Count; i2++)
                    {
                        if (i2 != 0)
                        {
                            ls2 += "/";
                        }
                        ls2 += rb.rb[i].artists[i2].name;
                    }
                    ls3 = "";
                    for (int i2 = 0; i2 < rb.rb[i].artists.Count; i2++)
                    {
                        if (i2 != 0)
                        {
                            ls3 += "/";
                        }
                        ls3 += rb.rb[i].artists[i2].id.ToString();
                    }
                    ini.IniWriteValue("Song" + i.ToString(), "artistsName", ls2);
                    ini.IniWriteValue("Song" + i.ToString(), "artistsID", ls3);
                    Success("保存成功！位置：" + SaveLoc.Text + ls4 + @"\专辑信息.ini");
                }
            }
        }

        private void AlbumID_Enter(object sender, EventArgs e)
        {
            AlbumIDInputOnFocus = true;
        }

        private void AlbumID_Leave(object sender, EventArgs e)
        {
            AlbumIDInputOnFocus = false;
        }

        private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb != null && SongListBox.SelectedIndex >= 0)
            {
                ts = new TimeSpan(0, 0, 0, 0, rb.rb[SongListBox.SelectedIndex].duration);
                ls1 = ts.Seconds.ToString();
                if (ls1.Length == 1)
                {
                    ls1 = "0" + ls1;
                }
                ls2 = "";
                for(int i = 0; i < rb.rb[SongListBox.SelectedIndex].artists.Count; i++)
                {
                    if (i != 0)
                    {
                        ls2 += "/";
                    }
                    ls2 += rb.rb[SongListBox.SelectedIndex].artists[i].name;
                }
                SongID.Text = "ID： " + rb.rb[SongListBox.SelectedIndex].id.ToString();
                SongTitle.Text = rb.rb[SongListBox.SelectedIndex].name;
                SongArtists.Text = "艺术家： " + ls2;
                SongLength.Text = "时长： " + ts.Minutes + ":" + ls1;
            }
        }

        private void Error(string s)
        {
            Err.ForeColor = Color.Red;
            Err.Text = s;
        }
        private void Success(string s)
        {
            Err.ForeColor = Color.Green;
            Err.Text = s;
        }
        private void Clear()
        {
            Err.Text = "";
            AlbumTitle.Text = "";
            SongTitle.Text = "";
            SongID.Text = "ID：";
            SongLength.Text = "时长：";
            SongArtists.Text = "艺术家：";
            AlbumCoverBox.Image = null;
            SongListBox.Items.Clear();
        }

        private void GetIt_Click(object sender, EventArgs e)
        {
            GET();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(loc);
            IniFiles ini = new IniFiles(Program.tloc + @"\settings.ini");
            if (ini.IniReadValue("163AlbumGet", "FileSaveDir").Trim() != "")
            {
                Program.savedir = ini.IniReadValue("163AlbumGet", "FileSaveDir");
            }
            if (ini.IniReadValue("163AlbumGet", "AlbumFolderName").Trim() != "")
            {
                Program.afn = ini.IniReadValue("163AlbumGet", "AlbumFolderName");
            }
            if (ini.IniReadValue("163AlbumGet", "SingleSongFilename").Trim() != "")
            {
                Program.ssf = ini.IniReadValue("163AlbumGet", "SingleSongFilename");
            }
            if (ini.IniReadValue("163AlbumGet", "MultipleSongsFilename").Trim() != "")
            {
                Program.msf = ini.IniReadValue("163AlbumGet", "MultipleSongsFilename");
            }
            SaveLoc.Text = Program.savedir;
        }

        private bool DownloadFile(string URL, string filename)
        {
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(filename, FileMode.Create);
                StreamReader myStreamReader = new StreamReader(st, Encoding.UTF8);
                byte[] by = new byte[10485760];
                int osize = st.Read(by, 0, by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, by.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
                dlerr = "";
                return true;
            }
            catch (Exception ee)
            {
                dlerr = ee.Message;
                return false;
            }
        }

        public static string HttpGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = "Why U Need UA?";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        private void GET()
        {
            Err.Text = "";
            bool b = true;
            Regex rx0 = new Regex(@"((https?:)?//)?music\.163\.com/(#/)?album\?\S+", RegexOptions.Compiled);
            Regex rx1 = new Regex(@"id=\d+", RegexOptions.Compiled);
            Regex rx2 = new Regex(@"\d+", RegexOptions.Compiled);
            Match r0 = rx0.Match(AlbumID.Text);
            if (r0.Success)
            {
                Match r1 = rx1.Match(r0.Value);
                if (r1.Success)
                {
                    sdataa = rx2.Match(r1.Value).Value;
                }
                else
                {
                    Error("地址错误");
                }
            }
            else if (rx2.IsMatch(AlbumID.Text))
            {
                sdataa = AlbumID.Text;
            }
            else
            {
                Error("地址错误");
                b = false;
            }
            if (b)
            {
                try
                {
                    sdata0 = HttpGet("http://music.163.com/album?id=" + sdataa);
                }
                catch (Exception e)
                {
                    exp = e.Message;
                    MessageBox.Show("Error!\n\n" + e.Message + "\n" + e.Source + "\n" + e.TargetSite + "\n" + e.Source + "\n" + e.Data + "\n" + e.StackTrace + "\n" + e.HelpLink);
                    sdata0 = null;
                }
                if (sdata0 != null)
                {

                    idata0 = sdata0.IndexOf("song-list-pre-data") + 42;
                    if (idata0 <= 42)
                    {
                        Error("获取专辑页面失败");
                    }
                    else
                    {
                        sdata1 = sdata0.Substring(idata0);
                        idata1 = sdata1.IndexOf("</textarea>");
                        if (idata1 <= 0)
                        {
                            Error("从页面获取专辑信息失败");
                        }
                        else
                        {
                            Clear();
                            sdata2 = "{\"rb\": " + sdata1.Substring(0, idata1) + "}";
                            rb = JsonConvert.DeserializeObject<RootObject>(sdata2);
                            AlbumTitle.Text = rb.rb[0].album.name;
                            AlbumCoverBox.ImageLocation = rb.rb[0].album.picUrl + "?param=177y177.jpg";
                            for (int i = 0; i < rb.rb.Count; i++)
                            {
                                SongListBox.Items.Add((i + 1).ToString() + "	| " + rb.rb[i].name);
                            }
                        }
                    }
                }
                else
                {
                    Error(exp);
                }
            }
        }

        private string Conv(string i, string d, string sa, string at, string ai, string st, string si)
        {
            for (int ii = 0; ii < i.Length; ii++)
            {
                int a1 = i.IndexOf("&d;");
                if (!(a1 < 0))
                {
                    i = i.Substring(0, a1) + d + i.Substring(a1 + 3, i.Length - 3 - a1);
                }
                else
                {
                    int a2 = i.IndexOf("&sa;");
                    if (!(a2 < 0))
                    {
                        i = i.Substring(0, a2) + sa + i.Substring(a2 + 4, i.Length - 4 - a2);
                    }
                    else
                    {
                        int a3 = i.IndexOf("&at;");
                        if (!(a3 < 0))
                        {
                            i = i.Substring(0, a3) + at + i.Substring(a3 + 4, i.Length - 4 - a3);
                        }
                        else
                        {
                            int a4 = i.IndexOf("&ai;");
                            if (!(a4 < 0))
                            {
                                i = i.Substring(0, a4) + ai + i.Substring(a4 + 4, i.Length - 4 - a4);
                            }
                            else
                            {
                                int a5 = i.IndexOf("&st;");
                                if (!(a5 < 0))
                                {
                                    i = i.Substring(0, a5) + st + i.Substring(a5 + 4, i.Length - 4 - a5);
                                }
                                else
                                {
                                    int a6 = i.IndexOf("&si;");
                                    if (!(a6 < 0))
                                    {
                                        i = i.Substring(0, a6) + si + i.Substring(a6 + 4, i.Length - 4 - a6);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for(int ii = 0; ii < i.Length; ii++)
            {
                int a7 = i.IndexOf("&&;");
                if (!(a7 < 0))
                {
                    i = i.Substring(0, a7) + "&" + i.Substring(a7 + 3, i.Length - 3 - a7);
                }
                else
                {
                    break;
                }
            }
            return i;
        }
    }

    public class IniFiles
    {
        public string inipath;

        //声明API函数

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public IniFiles(string INIPath)
        {
            inipath = INIPath;
        }

        public IniFiles() { }

        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, inipath);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }
        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }
    }

    public class RootObject
    {
        public List<RB> rb { get; set; }
    }
    public class RB
    {
        public Album album { get; set; }
        public List<Artists> artists { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int duration { get; set; }
    }
    public class Album
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picUrl { get; set; }
    }
    public class Artists
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
