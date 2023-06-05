using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Enums;

namespace Victory.Service.Helpers.ImageHelper
{
    public interface IImageHelper
    {

        Task<string> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);

        void Delete(string pictureUrl);
    }
}
