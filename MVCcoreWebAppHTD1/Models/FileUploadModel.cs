using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCcoreWebAppHTD1.Models
{
    public class FileUploadModel
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public string ContentType { get; set; }
            public byte[] Data { get; set; }
    }
}


