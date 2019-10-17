using Staj.Business.Interface;
using Staj.Domain;
using Staj.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj.Controllers
{
    public class HomeController : Controller
    {
        IPlayerBusiness playerBusiness;
        ITeamBusiness teamBusiness;
        IPlayerSkillBusiness playerSkillBusiness;
        IImageBusiness imageBusiness;

        public HomeController(IPlayerBusiness _playerBusiness, ITeamBusiness _teamBusiness, IPlayerSkillBusiness _playerSkillBusiness, IImageBusiness _imageBusiness)
        {
            playerBusiness = _playerBusiness;
            teamBusiness = _teamBusiness;
            playerSkillBusiness = _playerSkillBusiness;
            imageBusiness = _imageBusiness;
        }

        public ActionResult Index()
        {
            var result = GetHomeImagePaths();
            if(result != null)
            {
                ViewBag.paths = result;
            }
            else
            {
                ViewBag.paths = "https://cdn-04.independent.ie/incoming/article38472632.ece/2c741/AUTOCROP/w620h342/INT_ED5_S01-Read-Only.jpg";
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Image()
        {
            ViewBag.Images = imageBusiness.GetAllImages();
            return View();
        }
        public JsonResult ShowImages()
        {
            var temp = getImageVM();

            var result = new List<PreviewImageViewModel>();

            if(temp != null)
            {
                foreach(var item in temp)
                {
                    result.Add(new PreviewImageViewModel { id = item.id, imgName = item.imgName});
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<ImageViewModel> getImageVM()
        {
            List<ImageDomainModel> imgDM = imageBusiness.GetAllImages();
            List<ImageViewModel> imgVM = new List<ImageViewModel>();

            if(imgDM != null)
            {
                var temp = imgDM.ToArray();
                for(int i = 0; i < temp.Length; i++)
                {
                    imgVM.Add(new ImageViewModel { id = temp[i].id, imgName = temp[i].imgName, imgPath = temp[i].imgPath, convertedImg = Convert.ToBase64String(temp[i].imgByte) });

                }
            }
            return imgVM;            
        }

        public JsonResult ImageUpload(ImageViewModel model)
        {
            int result = 0;
            int imageId = 0;

            var file = model.ImageFile;

            byte[] imagebyte = null;

            if (file != null)
            {

                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));

                BinaryReader reader = new BinaryReader(file.InputStream);

                imagebyte = reader.ReadBytes(file.ContentLength);

                ImageViewModel img = new ImageViewModel();
                ImageDomainModel imgDM = new ImageDomainModel();

                img.imgName = file.FileName;
                img.imgByte = imagebyte;
                img.imgPath = "/UploadedImage/" + file.FileName;

                AutoMapper.Mapper.Map(img, imgDM);

                result = imageBusiness.AddEditImage(imgDM);

                imageId = result;

            }

            return Json(imageId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ImageRetrieve(int id)
        {
            var img = imageBusiness.GetImage(id);
            return File(img.imgByte, "image/jpg");
        }

        public ActionResult SetImgPrompt(int img, int id)
        {
            ViewBag.img = img;
            ViewBag.id = id;
            return PartialView("SetImgPartial");
        }
        public string SetImg(int img, int id)
        {
            var result = imageBusiness.SetHomeImage(img, id);
            return result;
        }
        public ActionResult DeleteImagePrompt(int id)
        {
            ViewBag.id = id;
            return PartialView("DeleteImgPartial");
        }
        public string DeleteImage(int id)
        {
            var result = imageBusiness.DeleteImage(id);
            return result;
        }
        public void GetHomeImages()
        {
            var result = imageBusiness.GetHomeImages();
            ViewBag.homeImages = result;
        }
        public List<string> GetHomeImagePaths()
        {
            var temp = imageBusiness.GetHomeImages();
            List<string> result = new List<string>();
            if(temp != null)
            {
                if(temp.Count == 0)
                {
                    result.Add("https://cdn-04.independent.ie/incoming/article38472632.ece/2c741/AUTOCROP/w620h342/INT_ED5_S01-Read-Only.jpg");
                }
                else
                {
                    foreach (var item in temp)
                    {
                        result.Add(imageBusiness.GetImage(item.imgId).imgPath);
                    }
                }
            }
            return result;
        }
    }
}