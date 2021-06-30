using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Helper
{
    public static class UploaderHelper
    {
        public static string UploadFile(string _FolderPath , IFormFile _File)
        {


            try
            {

                // Get Directory
                var FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + _FolderPath;


                // Get FileName

                var FileName = Guid.NewGuid() + Path.GetFileName(_File.FileName);


                // Merge Path with FileName

                var FinalPath = Path.Combine(FolderPath, FileName);

                //Save File As A Stream

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {

                    _File.CopyTo(stream);
                };


                return FileName;

            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
         
        
        public static void RemoveFile(string FolderName, string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + FileName);
            }
        }
    }
}
