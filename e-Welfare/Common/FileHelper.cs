using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace e_Welfare.Web.Common
{
    /// <summary>
    /// File upload utility class
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Save File
        /// </summary>
        /// <param name="content">Size of the string</param>
        /// <param name="path">If true, generate lowercase string</param>
        public static void SaveFile(byte[] content, string path)
        {
            string filePath = GetFileFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            using (FileStream str = File.Create(filePath))
            {
                str.Write(content, 0, content.Length);
            }
        }

        /// <summary>
        /// Get File Full Path
        /// </summary>
        /// <param name="path">path v</param>
        /// <returns>file Path</returns>
        public static string GetFileFullPath(string path)
        {
            string relName = path.StartsWith("~") ? path : path.StartsWith("/") ? string.Concat("~", path) : path;
            string filePath = relName.StartsWith("~") ? HostingEnvironment.MapPath(relName) : relName;
            return filePath;
        }

        /// <summary>
        /// Create Folder If Needed
        /// </summary>
        /// <param name="path">path v</param>
        /// <returns>result v</returns>
        public static bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }

            return result;
        }
    }
}