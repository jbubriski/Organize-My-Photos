using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text;
using System.Security.Cryptography;

namespace OrganizeMyPhotos
{
    public partial class Form1 : Form
    {
        private string _sourceFolder;
        private string _destinationFolder;

        private Dictionary<string, string> _hashCodes = new Dictionary<string, string>();

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
            var sourceFolder = _sourceFolder;
            var desinationFolder = _destinationFolder;

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
                OrganizeByYearThenMonthThenDay(_sourceFolder, _destinationFolder);
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

        private void OrganizeByYearThenMonthThenDay(string sourceFolder, string desinationFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                //TODO: Add some UI messages about the issue.
                return;
            }

            if (!Directory.Exists(desinationFolder))
            {
                //TODO: Add some UI messages about the issue.
                return;
            }

            var deleteDuplicates = uxDeleteDuplicates.Checked;
            var debugMode = uxDebugMode.Checked;

            var photosProcessed = 0;
            var photosMoved = 0;
            var photosSkipped = 0;
            var photosDeleted = 0;
            var directoriesCreated = 0;

            var photos = FindPhotos(sourceFolder);

            Log("\r\n\r\nProcessing Files:\r\n");
            Log(string.Format("Moving files from :\r\n", sourceFolder));
            Log(string.Format("To :\r\n", desinationFolder));

            foreach (var photo in photos)
            {
                var fileInfo = new FileInfo(photo);
                var dateTaken = fileInfo.GetDateTaken();

                if (dateTaken.HasValue)
                {
                    var newFolderName = dateTaken.Value.ToString("yyyy-MM-dd");
                    var newFolderPath = Path.Combine(desinationFolder, newFolderName);
                    var newFilePath = Path.Combine(newFolderPath, fileInfo.Name);

                    // For easier to read logs:
                    var relativePath = fileInfo.FullName.Replace(sourceFolder, string.Empty);
                    var newRelativePath = Path.Combine(newFolderName, fileInfo.Name);

                    if (fileInfo.FullName == newFilePath)
                    {
                        uxLog.AppendText(string.Format("\r\nSkipping (file in correct location): {0}", relativePath));
                        photosSkipped++;
                    }
                    else if (File.Exists(newFilePath))
                    {
                        if (!_hashCodes.ContainsKey(newFilePath))
                        {
                            _hashCodes.Add(newFilePath, GetHash(newFilePath));
                        }

                        if (GetHash(fileInfo.FullName) == _hashCodes[newFilePath])
                        {
                            if (deleteDuplicates)
                            {
                                if (!debugMode)
                                {
                                    fileInfo.Delete();
                                }

                                uxLog.AppendText(string.Format("\r\nDeleted (Duplicate): {0}", relativePath));
                                photosDeleted++;
                            }
                            else
                            {
                                uxLog.AppendText(string.Format("\r\nSkipped (Duplicate): {0}", relativePath));
                                photosSkipped++;
                            }
                        }
                        else
                        {
                            uxLog.AppendText(string.Format("\r\nSkipped (File with same name): {0}", relativePath));
                            photosSkipped++;
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(newFolderPath))
                        {
                            if (!debugMode)
                            {
                                Directory.CreateDirectory(newFolderPath);
                            }

                            directoriesCreated++;
                        }

                        if (!debugMode)
                        {
                            fileInfo.MoveTo(newFilePath);
                        }

                        uxLog.AppendText(string.Format("\r\nMoved: {0}\r\n\tTo: {1}", relativePath, newRelativePath));
                        photosMoved++;
                    }
                }
                else
                {
                    uxLog.AppendText(string.Format("\r\nSkipping (no date): {0}", fileInfo.FullName));
                    // TODO: Move the photos that have no date?
                    photosSkipped++;
                }

                photosProcessed++;
            }

            var result = string.Format("Done! \r\nFound: {0} \r\nMoved: {1} \r\nSkipped: {2} \r\nDeleted: {3} \r\nDirectories Created: {4}", photosProcessed, photosMoved, photosSkipped, photosDeleted, directoriesCreated);

            Log(result);
            MessageBox.Show(result);
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

        private string GetHash(string filePath)
        {
            var stringBuilder = new StringBuilder();

            using (var md5Hasher = MD5.Create())
            using (var fileStream = File.OpenRead(filePath))
            {
                foreach (var bite in md5Hasher.ComputeHash(fileStream))
                {
                    stringBuilder.Append(bite.ToString("x2").ToLower());
                }
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
