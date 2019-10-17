using Staj.Domain;
using Staj.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Business.Interface
{
    public interface IImageBusiness
    {
        int AddEditImage(ImageDomainModel img);
        ImageDomainModel GetImage(int id);
        List<ImageDomainModel> GetAllImages();
        string DeleteImage(int id);
        string SetHomeImage(int img, int id);
        List<UsedImageDomainModel> GetHomeImages();
    }
}
