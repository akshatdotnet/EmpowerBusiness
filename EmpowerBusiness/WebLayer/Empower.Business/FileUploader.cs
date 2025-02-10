using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Empower.Business
{
    public static class FileUploader
    {
        public static string UploadedMedia = "UploadedMedia";
        private static string MediaDirectory = "";
        public static void Configure(string mediaDirectory)
        {
            MediaDirectory = mediaDirectory;
        }

        private static string GetDirectoryPath(UploadedFileTypeEnum uploadedFileType, bool isVirtualPath = false)
        {
            var path = $"/{UploadedMedia}/";
            if (!isVirtualPath)
            {
                path = $"{MediaDirectory}/{path}";
            }
            switch (uploadedFileType)
            {
                case UploadedFileTypeEnum.Category:
                    path += "Category";
                    break;
                case UploadedFileTypeEnum.SubCategory:
                    path += "SubCategory";
                    break;
                case UploadedFileTypeEnum.Banner:
                    path += "Banner";
                    break;
                case UploadedFileTypeEnum.Product:
                    path += "Product";
                    break;
                case UploadedFileTypeEnum.Editor:
                    path += "Editor";
                    break;
                case UploadedFileTypeEnum.CountryMaster:
                    path += "CountryMaster";
                    break;
                case UploadedFileTypeEnum.ProductRatingAndReview:
                    path += "RatingAndReview";
                    break;
                default:
                    break;
            }
            return path;
        }

        public static string Save(IFormFile? file, UploadedFileTypeEnum uploadedFileType)
        {
            var savedFileName = "";
            if (file != null)
            {
                string path = GetDirectoryPath(uploadedFileType);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                string fileName = Guid.NewGuid().ToString().Replace("-", "_") + Path.GetExtension(file.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    savedFileName = fileName;
                }

            }
            return savedFileName;

        }

        public static Dictionary<string, bool> SaveMultipleFiles(List<IFormFile?> files, UploadedFileTypeEnum uploadedFileType, string primaryImage = "")
        {
            var uploadedFiles = new Dictionary<string, bool>();
            if (files != null)
            {
                string path = GetDirectoryPath(uploadedFileType);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var item in files)
                {

                    string fileName = Guid.NewGuid().ToString().Replace("-", "_") + Path.GetExtension(item?.FileName);
                    using var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                    {
                        item?.CopyTo(stream);
                        if (!string.IsNullOrEmpty(primaryImage))
                        {
                            var imageName = item?.FileName.Replace("/", "").Replace(" ", "");
                            if (primaryImage.ToLower() == imageName?.ToLower())
                            {
                                uploadedFiles.Add(fileName, true);
                            }
                            else { uploadedFiles.Add(fileName, false); }
                        }
                        else
                        {
                            uploadedFiles.Add(fileName, false);

                        }
                    }
                }

            }
            return uploadedFiles;

        }

        public static string SaveByImageOriginalName(IFormFile? file, UploadedFileTypeEnum uploadedFileType)
        {
            var savedFileName = "";
            if (file != null)
            {
                string path = GetDirectoryPath(uploadedFileType);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                string fileName = file.FileName;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    savedFileName = fileName;
                }

            }
            return savedFileName;

        }

        public static string SaveByteArrayAsImage(string base64String, UploadedFileTypeEnum uploadedFileType)
        {
            string path = GetDirectoryPath(uploadedFileType);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (base64String.StartsWith("data:image/png;base64,"))
            {
                base64String = base64String.Replace("data:image/png;base64,", "");
            }
            string fileName = Guid.NewGuid().ToString().Replace("-", "_") + ".png";
            var bytess = Convert.FromBase64String(base64String);
            using (var imageFile = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
            }
            return fileName;
        }

        public static bool Delete(string imageName, UploadedFileTypeEnum uploadedFileType)
        {
            try
            {
                string path = GetDirectoryPath(uploadedFileType) + "/" + imageName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static string Get(string? imageName, UploadedFileTypeEnum uploadedFileType)
        {
            if (imageName.IsNullOrEmpty())
            {
                return "";
            }
            return $"{GetDirectoryPath(uploadedFileType, true)}/{imageName}";

        }
        public static Dictionary<string, int> SaveRatingReviewMediaFiles(List<IFormFile?> files, UploadedFileTypeEnum uploadedFileType)
        {
            var uploadedFiles = new Dictionary<string, int>();
            if (files != null)
            {
                string path = GetDirectoryPath(uploadedFileType);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var item in files)
                {

                    string fileName = Guid.NewGuid().ToString().Replace("-", "_") + Path.GetExtension(item?.FileName);
                    using var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                    {
                        item?.CopyTo(stream);

                        var fileType = (int)MediaType.Image;
                        var contentType = item?.ContentType ?? string.Empty;
                        if (contentType.Contains("video"))
                            fileType = (int)MediaType.Video;
                        uploadedFiles.Add(fileName, fileType);
                    }
                }
            }
            return uploadedFiles;

        }


    }
}
