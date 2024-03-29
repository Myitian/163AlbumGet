﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _163AlbumGet
{
    public partial class AboutPage : Form
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void AboutPage_Load(object sender, EventArgs e)
        {
            LicenseBox.Text = Properties.Resources.LICENSE;
            LicenseOfNewtonsoftJsonBox.Text = Properties.Resources.LICENSEofNewtonsoftJson;
        }

        private void JumpToWebSite(object sender, EventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }
    }
}
