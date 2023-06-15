using Microsoft.AspNetCore.Http;
using PizzaIdentityMvcApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIdentityMvcApp.Service.Helpers
{
    public interface IImageHelper
    {
        Task<string> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);

        void Delete(string pictureUrl);
    }
}
