using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Staj.Domain
{
    public class ImageDomainModel
    {
        public int id { get; set; }
        public string imgName { get; set; }
        public byte[] imgByte { get; set; }
        public string imgPath { get; set; }
        
    }
}
