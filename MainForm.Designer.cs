namespace _163AlbumGet
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.L0 = new System.Windows.Forms.Label();
            this.AlbumID = new System.Windows.Forms.TextBox();
            this.GetIt = new System.Windows.Forms.Button();
            this.SongListBox = new System.Windows.Forms.ListBox();
            this.AlbumTitle = new System.Windows.Forms.Label();
            this.SongTitle = new System.Windows.Forms.TextBox();
            this.AlbumCoverBox = new System.Windows.Forms.PictureBox();
            this.L1 = new System.Windows.Forms.Label();
            this.Err = new System.Windows.Forms.Label();
            this.SongLength = new System.Windows.Forms.Label();
            this.SongArtists = new System.Windows.Forms.Label();
            this.SongID = new System.Windows.Forms.Label();
            this.DLSong = new System.Windows.Forms.Button();
            this.DLAllSong = new System.Windows.Forms.Button();
            this.SaveDataAsINI = new System.Windows.Forms.Button();
            this.SaveLoc = new System.Windows.Forms.TextBox();
            this.LSaveLoc = new System.Windows.Forms.Label();
            this.DLSettings = new System.Windows.Forms.Button();
            this.GoToPG = new System.Windows.Forms.Button();
            this.ProcessB = new System.Windows.Forms.ProgressBar();
            this.ProcessL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCoverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // L0
            // 
            this.L0.AutoSize = true;
            this.L0.Font = new System.Drawing.Font("宋体", 10F);
            this.L0.Location = new System.Drawing.Point(12, 17);
            this.L0.Name = "L0";
            this.L0.Size = new System.Drawing.Size(77, 14);
            this.L0.TabIndex = 1;
            this.L0.Text = "专辑号/URL";
            // 
            // AlbumID
            // 
            this.AlbumID.Font = new System.Drawing.Font("宋体", 11F);
            this.AlbumID.Location = new System.Drawing.Point(95, 12);
            this.AlbumID.Name = "AlbumID";
            this.AlbumID.Size = new System.Drawing.Size(357, 24);
            this.AlbumID.TabIndex = 2;
            this.AlbumID.Enter += new System.EventHandler(this.AlbumID_Enter);
            this.AlbumID.Leave += new System.EventHandler(this.AlbumID_Leave);
            // 
            // GetIt
            // 
            this.GetIt.Font = new System.Drawing.Font("宋体", 10F);
            this.GetIt.Location = new System.Drawing.Point(458, 11);
            this.GetIt.Name = "GetIt";
            this.GetIt.Size = new System.Drawing.Size(75, 26);
            this.GetIt.TabIndex = 3;
            this.GetIt.Text = "获取";
            this.GetIt.UseVisualStyleBackColor = true;
            this.GetIt.Click += new System.EventHandler(this.GetIt_Click);
            // 
            // SongListBox
            // 
            this.SongListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SongListBox.Font = new System.Drawing.Font("宋体", 10F);
            this.SongListBox.FormattingEnabled = true;
            this.SongListBox.Location = new System.Drawing.Point(12, 83);
            this.SongListBox.Name = "SongListBox";
            this.SongListBox.Size = new System.Drawing.Size(521, 355);
            this.SongListBox.TabIndex = 4;
            this.SongListBox.SelectedIndexChanged += new System.EventHandler(this.SongListBox_SelectedIndexChanged);
            // 
            // AlbumTitle
            // 
            this.AlbumTitle.AutoSize = true;
            this.AlbumTitle.Font = new System.Drawing.Font("宋体", 12F);
            this.AlbumTitle.Location = new System.Drawing.Point(12, 49);
            this.AlbumTitle.Name = "AlbumTitle";
            this.AlbumTitle.Size = new System.Drawing.Size(0, 16);
            this.AlbumTitle.TabIndex = 7;
            // 
            // SongTitle
            // 
            this.SongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongTitle.Font = new System.Drawing.Font("宋体", 11F);
            this.SongTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SongTitle.Location = new System.Drawing.Point(539, 195);
            this.SongTitle.Multiline = true;
            this.SongTitle.Name = "SongTitle";
            this.SongTitle.ReadOnly = true;
            this.SongTitle.Size = new System.Drawing.Size(177, 36);
            this.SongTitle.TabIndex = 8;
            // 
            // AlbumCoverBox
            // 
            this.AlbumCoverBox.Location = new System.Drawing.Point(539, 12);
            this.AlbumCoverBox.Name = "AlbumCoverBox";
            this.AlbumCoverBox.Size = new System.Drawing.Size(177, 177);
            this.AlbumCoverBox.TabIndex = 9;
            this.AlbumCoverBox.TabStop = false;
            // 
            // L1
            // 
            this.L1.AutoSize = true;
            this.L1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L1.Location = new System.Drawing.Point(14, 70);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(119, 12);
            this.L1.TabIndex = 10;
            this.L1.Text = "序号     | 歌曲标题";
            // 
            // Err
            // 
            this.Err.AutoSize = true;
            this.Err.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Err.ForeColor = System.Drawing.Color.Red;
            this.Err.Location = new System.Drawing.Point(251, 70);
            this.Err.Name = "Err";
            this.Err.Size = new System.Drawing.Size(0, 12);
            this.Err.TabIndex = 11;
            // 
            // SongLength
            // 
            this.SongLength.AutoSize = true;
            this.SongLength.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SongLength.Location = new System.Drawing.Point(539, 262);
            this.SongLength.Name = "SongLength";
            this.SongLength.Size = new System.Drawing.Size(41, 12);
            this.SongLength.TabIndex = 12;
            this.SongLength.Text = "时长：";
            // 
            // SongArtists
            // 
            this.SongArtists.AutoSize = true;
            this.SongArtists.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SongArtists.Location = new System.Drawing.Point(539, 248);
            this.SongArtists.Name = "SongArtists";
            this.SongArtists.Size = new System.Drawing.Size(53, 12);
            this.SongArtists.TabIndex = 13;
            this.SongArtists.Text = "艺术家：";
            // 
            // SongID
            // 
            this.SongID.AutoSize = true;
            this.SongID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SongID.Location = new System.Drawing.Point(539, 234);
            this.SongID.Name = "SongID";
            this.SongID.Size = new System.Drawing.Size(29, 12);
            this.SongID.TabIndex = 14;
            this.SongID.Text = "ID：";
            // 
            // DLSong
            // 
            this.DLSong.Location = new System.Drawing.Point(628, 277);
            this.DLSong.Name = "DLSong";
            this.DLSong.Size = new System.Drawing.Size(89, 22);
            this.DLSong.TabIndex = 16;
            this.DLSong.Text = "下载该歌曲";
            this.DLSong.UseVisualStyleBackColor = true;
            this.DLSong.Click += new System.EventHandler(this.DLSong_Click);
            // 
            // DLAllSong
            // 
            this.DLAllSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DLAllSong.Location = new System.Drawing.Point(539, 411);
            this.DLAllSong.Name = "DLAllSong";
            this.DLAllSong.Size = new System.Drawing.Size(178, 28);
            this.DLAllSong.TabIndex = 17;
            this.DLAllSong.Text = "下载专辑内所有歌曲";
            this.DLAllSong.UseVisualStyleBackColor = true;
            this.DLAllSong.Click += new System.EventHandler(this.DLAllSong_Click);
            // 
            // SaveDataAsINI
            // 
            this.SaveDataAsINI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDataAsINI.Location = new System.Drawing.Point(539, 383);
            this.SaveDataAsINI.Name = "SaveDataAsINI";
            this.SaveDataAsINI.Size = new System.Drawing.Size(178, 28);
            this.SaveDataAsINI.TabIndex = 18;
            this.SaveDataAsINI.Text = "保存专辑信息";
            this.SaveDataAsINI.UseVisualStyleBackColor = true;
            this.SaveDataAsINI.Click += new System.EventHandler(this.SaveDataAsINI_Click);
            // 
            // SaveLoc
            // 
            this.SaveLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLoc.Location = new System.Drawing.Point(540, 339);
            this.SaveLoc.Name = "SaveLoc";
            this.SaveLoc.Size = new System.Drawing.Size(176, 21);
            this.SaveLoc.TabIndex = 19;
            this.SaveLoc.TextChanged += new System.EventHandler(this.SaveLoc_TextChanged);
            // 
            // LSaveLoc
            // 
            this.LSaveLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LSaveLoc.AutoSize = true;
            this.LSaveLoc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LSaveLoc.Location = new System.Drawing.Point(537, 325);
            this.LSaveLoc.Name = "LSaveLoc";
            this.LSaveLoc.Size = new System.Drawing.Size(65, 12);
            this.LSaveLoc.TabIndex = 20;
            this.LSaveLoc.Text = "保存位置：";
            // 
            // DLSettings
            // 
            this.DLSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DLSettings.Location = new System.Drawing.Point(621, 360);
            this.DLSettings.Name = "DLSettings";
            this.DLSettings.Size = new System.Drawing.Size(96, 20);
            this.DLSettings.TabIndex = 21;
            this.DLSettings.Text = "详细下载设置";
            this.DLSettings.UseVisualStyleBackColor = true;
            this.DLSettings.Click += new System.EventHandler(this.DLSettings_Click);
            // 
            // GoToPG
            // 
            this.GoToPG.Location = new System.Drawing.Point(539, 277);
            this.GoToPG.Name = "GoToPG";
            this.GoToPG.Size = new System.Drawing.Size(89, 22);
            this.GoToPG.TabIndex = 22;
            this.GoToPG.Text = "转至播放页";
            this.GoToPG.UseVisualStyleBackColor = true;
            this.GoToPG.Click += new System.EventHandler(this.GoToPG_Click);
            // 
            // ProcessB
            // 
            this.ProcessB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessB.Location = new System.Drawing.Point(539, 302);
            this.ProcessB.Name = "ProcessB";
            this.ProcessB.Size = new System.Drawing.Size(177, 17);
            this.ProcessB.TabIndex = 23;
            // 
            // ProcessL
            // 
            this.ProcessL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessL.AutoEllipsis = true;
            this.ProcessL.AutoSize = true;
            this.ProcessL.BackColor = System.Drawing.SystemColors.Control;
            this.ProcessL.Location = new System.Drawing.Point(689, 319);
            this.ProcessL.Name = "ProcessL";
            this.ProcessL.Size = new System.Drawing.Size(11, 12);
            this.ProcessL.TabIndex = 24;
            this.ProcessL.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.ProcessL);
            this.Controls.Add(this.ProcessB);
            this.Controls.Add(this.GoToPG);
            this.Controls.Add(this.DLSettings);
            this.Controls.Add(this.LSaveLoc);
            this.Controls.Add(this.SaveLoc);
            this.Controls.Add(this.SaveDataAsINI);
            this.Controls.Add(this.DLAllSong);
            this.Controls.Add(this.DLSong);
            this.Controls.Add(this.SongID);
            this.Controls.Add(this.SongArtists);
            this.Controls.Add(this.SongLength);
            this.Controls.Add(this.Err);
            this.Controls.Add(this.L1);
            this.Controls.Add(this.AlbumCoverBox);
            this.Controls.Add(this.SongTitle);
            this.Controls.Add(this.AlbumTitle);
            this.Controls.Add(this.SongListBox);
            this.Controls.Add(this.GetIt);
            this.Controls.Add(this.AlbumID);
            this.Controls.Add(this.L0);
            this.MinimumSize = new System.Drawing.Size(744, 489);
            this.Name = "MainForm";
            this.Text = "网易云音乐专辑歌曲批量下载器";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCoverBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L0;
        private System.Windows.Forms.TextBox AlbumID;
        private System.Windows.Forms.Button GetIt;
        private System.Windows.Forms.ListBox SongListBox;
        private System.Windows.Forms.Label AlbumTitle;
        private System.Windows.Forms.TextBox SongTitle;
        private System.Windows.Forms.PictureBox AlbumCoverBox;
        private System.Windows.Forms.Label L1;
        private System.Windows.Forms.Label Err;
        private System.Windows.Forms.Label SongLength;
        private System.Windows.Forms.Label SongArtists;
        private System.Windows.Forms.Label SongID;
        private System.Windows.Forms.Button DLSong;
        private System.Windows.Forms.Button DLAllSong;
        private System.Windows.Forms.Button SaveDataAsINI;
        private System.Windows.Forms.TextBox SaveLoc;
        private System.Windows.Forms.Label LSaveLoc;
        private System.Windows.Forms.Button DLSettings;
        private System.Windows.Forms.Button GoToPG;
        private System.Windows.Forms.ProgressBar ProcessB;
        private System.Windows.Forms.Label ProcessL;
    }
}

