using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrganizeMyPhotos
{
    public partial class SetFolderDialog : Form
    {
        public string FolderPath
        {
            get
            {
                return uxFolderPath.Text;
            }
            set
            {
                uxFolderPath.Text = value;
            }
        }

        public SetFolderDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ActiveControl = uxFolderPath;
        }
    }
}
