namespace OrganizeMyPhotos
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryHelper
    {
        public void DeleteEmptyDirectories(string path)
        {
            var directories = Directory.GetDirectories(path);

            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);

                var hasFiles = directoryInfo.GetFiles().Length > 0;
                var hasDirectories = directoryInfo.GetDirectories().Length > 0;

                if (!hasFiles && !hasDirectories)
                {
                    Directory.Delete(directory);
                }
            }
        }
    }
}