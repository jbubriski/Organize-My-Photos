using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OrganizeMyPhotos
{
    public partial class Form1 : Form
    {
        private string _sourceFolder;
        private string _destinationFolder;

        public Form1()
        {
            InitializeComponent();
        }

        private void uxSelectFolder_Click(object sender, EventArgs e)
        {
            SetSourceFolder(SelectFolder(_sourceFolder));
        }

        private void uxSetFolderManually_Click(object sender, EventArgs e)
        {
            SetSourceFolder(SetFolderManually(_sourceFolder));
        }

        private void uxSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            SetDestinationFolder(SelectFolder(_destinationFolder));
        }

        private void uxSetDestinationFolderManually_Click(object sender, EventArgs e)
        {
            SetDestinationFolder(SetFolderManually(_destinationFolder));
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
            if (string.IsNullOrWhiteSpace(_sourceFolder))
            {
                return;
            }

            var selectedFolder = _sourceFolder;

            FindPhotos(selectedFolder);
        }

        private void OrganizeByYearThenMonthThenDay()
        {
            if (string.IsNullOrWhiteSpace(_sourceFolder))
            {
                return;
            }

            var sourceFolder = _sourceFolder;
            var desinationFolder = _destinationFolder;

            var photosProcessed = 0;
            var photosMoved = 0;
            var photosSkipped = 0;
            var directoriesCreated = 0;

            var photos = FindPhotos(sourceFolder);

            Log("\r\n\r\nProcessing Files:\r\n");

            foreach (var photo in photos)
            {
                var fileInfo = new FileInfo(photo);
                var dateTaken = fileInfo.GetDateTaken();

                if (dateTaken.HasValue)
                {
                    var newFolderName = dateTaken.Value.ToString("yyyy-MM-dd");
                    var newFolderPath = Path.Combine(desinationFolder, newFolderName);
                    var newFilePath = Path.Combine(newFolderPath, fileInfo.Name);

                    if ((fileInfo.FullName != newFilePath) && !File.Exists(newFilePath))
                    {
                        if (!Directory.Exists(newFolderPath))
                        {
                            if (!uxDebugMode.Checked)
                            {
                                Directory.CreateDirectory(newFolderPath);
                            }

                            directoriesCreated++;
                        }

                        uxLog.AppendText(string.Format("\r\nMoving: {0}\r\n\tTo: {1}", fileInfo.FullName, newFilePath));

                        if (!uxDebugMode.Checked)
                        {
                            fileInfo.MoveTo(newFilePath);
                            photosMoved++;
                        }

                    }
                    else
                    {
                        uxLog.AppendText(string.Format("\r\nSkipping (already exists): {0}", fileInfo.FullName));
                        photosSkipped++;
                    }
                }
                else
                {
                    uxLog.AppendText(string.Format("\r\nSkipping (no date): {0}", fileInfo.FullName));
                    // TODO: Resort the photos that have no date?
                    photosSkipped++;
                }

                photosProcessed++;
            }

            MessageBox.Show(string.Format("Done! \r\nFound: {0} \r\nMoved: {1} \r\nSkipped: {2} \r\nDirectories Created: {3}", photosProcessed, photosMoved, photosSkipped, directoriesCreated));
        }

        private void uxClearLog_Click(object sender, EventArgs e)
        {
            uxLog.Text = string.Empty;
        }

        #region Private Parts

        private IEnumerable<string> FindPhotos(string selectedFolder)
        {
            var photos = Directory.GetFiles(selectedFolder, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                        || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                        || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                        || s.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                        || s.EndsWith(".raw", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(p => p);

            Log("\r\n\r\nFiles found:\r\n");
            Log(string.Join("\r\n", photos));

            return photos;
        }

        private void Log(string text)
        {
            uxLog.Text += text;
        }

        private string SelectFolder(string currentFolder)
        {
            if (!string.IsNullOrEmpty(currentFolder))
            {
                uxFolderBrowserDialog.SelectedPath = currentFolder;
            }

            var result = uxFolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var selectedFolder = uxFolderBrowserDialog.SelectedPath;

                if (!string.IsNullOrWhiteSpace(selectedFolder))
                {
                    return selectedFolder;
                }
            }

            return null;
        }

        private string SetFolderManually(string currentFolder)
        {
            using (var dialog = new SetFolderDialog())
            {
                if (!string.IsNullOrEmpty(_sourceFolder))
                {
                    dialog.FolderPath = _sourceFolder;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(dialog.FolderPath))
                    {
                        return dialog.FolderPath;
                    }
                }
            }

            return null;
        }

        private void SetSourceFolder(string folderPath)
        {
            uxSourceFolder.Text = folderPath;
            _sourceFolder = folderPath;
        }

        private void SetDestinationFolder(string folderPath)
        {
            uxDestinationFolder.Text = folderPath;
            _destinationFolder = folderPath;
        }

        #endregion
    }
}
