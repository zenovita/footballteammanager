using Staj.Business.Interface;
using Staj.Domain;
using Staj.Repository;
using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Staj.Business
{
    public class ImageBusiness : IImageBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ImageRepository imageRepository;
        private readonly UsedImagesRepository usedImagesRepository;

        public ImageBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            imageRepository = new ImageRepository(unitOfWork);
            usedImagesRepository = new UsedImagesRepository(unitOfWork);

        }

        public int AddEditImage(ImageDomainModel img)
        {
            int result = 0;
            if (img.id > 0)
            {
                Images image = imageRepository.SingleOrDefault(x => x.id == img.id);
                
                if (image != null)
                {

                    image.imgByte = img.imgByte;
                    image.imgName = img.imgName;
                    image.imgPath = img.imgPath;

                    imageRepository.Update(image);
                    result = img.id;
                }
            }
            else // Add Player
            {
                Images image = new Images();

                image.imgByte = img.imgByte;
                image.imgName = img.imgName;
                image.imgPath = img.imgPath;

                imageRepository.Insert(image);

                result = image.id;
            }

            return result;
        }

        public string DeleteImage(int id)
        {
            imageRepository.Delete(x => x.id == id);
            return "Ok";
        }

        public List<ImageDomainModel> GetAllImages()
        {
            List<ImageDomainModel> result = new List<ImageDomainModel>();
            result = imageRepository.GetAll().Select(m => new ImageDomainModel { id = m.id, imgByte = m.imgByte, imgName = m.imgName, imgPath = m.imgPath }).ToList();

            return result;
        }

        public ImageDomainModel GetImage(int id)
        {
            var temp = imageRepository.SingleOrDefault(x => x.id == id);
            ImageDomainModel result = new ImageDomainModel();

            result.id = temp.id;
            result.imgByte = temp.imgByte;
            result.imgName = temp.imgName;
            result.imgPath = temp.imgPath;

            return result;
        }

        public string SetHomeImage(int img, int id)
        {
            UsedImages ui = new UsedImages();
            if(img == 1)
            {
                ui.id = 1;
            }else if(img == 2)
            {
                ui.id = 2;
            }
            else
            {
                ui.id = 3;
            }
            ui.imgId = id;
            ui.imgOrder = img;
            usedImagesRepository.Update(ui);
         
            return "OK";
        }

        public List<UsedImageDomainModel> GetHomeImages()
        {
            List<UsedImageDomainModel> list = usedImagesRepository.GetAll().Select(m => new UsedImageDomainModel { id = m.id, imgId = m.imgId, imgOrder = m.imgOrder}).ToList();
            List<UsedImageDomainModel> list2 = new List<UsedImageDomainModel>();
            foreach(var item in list)
            {
                var temp = imageRepository.SingleOrDefault(m => m.id == item.imgId);
                if (temp != null)
                {
                    list2.Add(new UsedImageDomainModel { id = item.id, imgId = item.imgId, imgOrder = item.imgOrder });
                }
            }
            return list2;
        }
    }
}
