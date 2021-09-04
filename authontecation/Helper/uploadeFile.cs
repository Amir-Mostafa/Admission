using Microsoft.AspNetCore.Http;
using repo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Helper
{
    public class uploadeFile
    {
        public static string uploade( image img)
        {

            try
            {
                var bytes = Convert.FromBase64String(img.value);
                string filedir = Path.Combine(Directory.GetCurrentDirectory(), "images");


                if (!Directory.Exists(filedir))
                {
                    Directory.CreateDirectory(filedir);
                }
                string file = Path.Combine(filedir,img.filename);
                if (bytes.Length > 0)
                {
                    using (var stream = new FileStream(file, FileMode.Create))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                    }
                }

                return "Saved";
            }
            catch
            {
                return "not saved";
            }
        }

        public static string getBase64(string name)
        {
            
            string filedir = Path.Combine(Directory.GetCurrentDirectory(), "images");
            string file = Path.Combine(filedir,name);
            byte[] imageArray = System.IO.File.ReadAllBytes(file);
            return "data:image/jpeg;base64,"+Convert.ToBase64String(imageArray);
        }
        public static void delete(string name)
        {
            string path = Directory.GetCurrentDirectory() + "/images/files/"+ name;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
