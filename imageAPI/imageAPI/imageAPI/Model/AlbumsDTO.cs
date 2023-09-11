using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
    public class AlbumsDTO
    {
        public int albumID { get; set; }
        public string albumName { get; set; }
        public FileContentResult albumImagePath { get; set; }
        public string albumImageContentType { get; set; }
    }
    public class AlbumsImagesDTO
    {
        public int imageID { get; set; }
        public int albumID { get; set; }
        public string imageName { get; set; }
        public FileContentResult imagePath { get; set; }
        public string imageContentType { get; set; }

    }

}