using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class ImageViewModel
    {
        public int id { get; set; }
        public string imgName { get; set; }
        public byte[] imgByte { get; set; }
        public string imgPath { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public string convertedImg { get; set; }
    }
}
