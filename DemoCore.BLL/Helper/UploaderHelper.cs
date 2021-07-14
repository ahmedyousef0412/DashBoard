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
        public static string UploadFile(string _FolderPath ,  IFormFile _File)
        {


           
            try
            {
                var FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + _FolderPath;



                var FileName = Guid.NewGuid() + Path.GetFileName(_File.FileName);


                var FinalPath = Path.Combine(FolderPath, FileName);


                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    _File.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception e)
            {

                return e.Message;
            }

         
        }

        public static void RemoveFile(string _FolderName , string _FileName)
        {

            if (File.Exists(Directory.GetCurrentDirectory() +"/wwwroot/"+ _FolderName + _FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() +"/wwwroot/"+ _FolderName + _FileName);
            }
        }
    }
}
