using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;

namespace OrganizeMyPhotos
{
    public partial class Form1 : Form
    {
        private string _selectedFolder;

        public Form1()
        {
            InitializeComponent();
        }

        private void uxSelectFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedFolder))
            {
                uxFolderBrowserDialog.SelectedPath = _selectedFolder;
            }

            var result = uxFolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                uxSelectedFolder.Text = uxFolderBrowserDialog.SelectedPath;
                _selectedFolder = uxFolderBrowserDialog.SelectedPath;
            }
        }

        private void uxOrganize_Click(object sender, EventArgs e)
        {
            if (uxOrganizeByDay.Checked)
            {
                // TODO: Implement this organizational structure
            }
            else if (uxOrganizeByMonth.Checked)
            {
                // TODO: Implement this organizational structure
            }
            else if (uxOrganizeByYear.Checked)
            {
                // TODO: Implement this organizational structure
            }
            else if (uxOrganizeByMonthThenDay.Checked)
            {
                // TODO: Implement this organizational structure
            }
            else if (uxOrganizeByYearThenMonthThenDay.Checked)
            {
                OrganizeByYearThenMonthThenDay();
            }
        }

        private void uxFindPhotos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedFolder))
            {
                return;
            }

            var selectedFolder = _selectedFolder;

            FindPhotos(selectedFolder);
        }

        private void OrganizeByYearThenMonthThenDay()
        {
            if (string.IsNullOrWhiteSpace(_selectedFolder))
            {
                return;
            }

            var selectedFolder = _selectedFolder;

            var photos = FindPhotos(selectedFolder);

            foreach (var photo in photos)
            {
                var fileInfo = new FileInfo(photo);
                var dateTaken = fileInfo.GetDateTaken();

                if (dateTaken.HasValue)
                {
                    var newFolderName = dateTaken.Value.ToString("yyyy-MM-dd");
                    var newFolderPath = Path.Combine(selectedFolder, newFolderName);
                    var newFilePath = Path.Combine(selectedFolder, newFolderName, fileInfo.Name);

                    if (!File.Exists(newFilePath))
                    {
                        if (!Directory.Exists(newFolderPath))
                        {
                            if (!uxDebugMode.Checked)
                            {
                                Directory.CreateDirectory(newFolderPath);
                            }
                        }

                        uxDebugOutput.AppendText(string.Format("\r\nMoving: {0}\r\n\tTo: {1}", fileInfo.FullName, newFilePath));

                        if (!uxDebugMode.Checked)
                        {
                            fileInfo.MoveTo(newFilePath);
                        }
                    }
                    else
                    {
                        uxDebugOutput.AppendText(string.Format("\r\nSkipping: {0}", fileInfo.FullName));
                    }
                }
                else
                {
                    // TODO: Resort the photos that have no date?
                }
            }
        }

        #region Private Parts

        private string[] FindPhotos(string selectedFolder)
        {
            var photos = Directory.GetFiles(selectedFolder, "*.jpg", SearchOption.AllDirectories);

            Array.Sort(photos);

            Log("Files found:\r\n");
            Log(string.Join("\r\n", photos));

            return photos;
        }

        private void Log(string text)
        {
            uxDebugOutput.Text += text;
        }

        #endregion
    }
}
