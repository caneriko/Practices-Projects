using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entity.Enums;
using MyBlog.Entity.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadViewModel> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName=null) ;

        void Delete(string imageName);
    }
}
