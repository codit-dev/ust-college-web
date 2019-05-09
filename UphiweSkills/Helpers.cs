using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UphiweSkills
{
    public class Helpers
    {
        public static string AddImageExtension(string imageType)
        {
            string imageExtension;

            switch(imageType)
            {
                case "image/jpg":
                    imageExtension = ".jpg";
                    break;
                case "image/jpeg":
                    imageExtension = ".jpeg";
                    break;
                case "image/png":
                    imageExtension = ".png";
                    break;
                case "image/gif":
                    imageExtension = ".gif";
                    break;
                default:
                    imageExtension = ".jpg";
                    break; 
            }

            return imageExtension;
        }
    }
}