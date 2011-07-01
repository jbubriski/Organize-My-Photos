using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace OrganizeMyPhotos
{
    public static class FileInfoExtensions
    {
        public static DateTime? GetDateTaken(this FileInfo fileInfo)
        {
            using (var fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var image = BitmapFrame.Create(fileStream);
                var metadata = (BitmapMetadata)image.Metadata;

                try
                {
                    return DateTime.Parse(metadata.DateTaken);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
