using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMRepository;
using CRMRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRMRepository.IRepository;
using CRMRepository.Repository;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManagementRepository.Models;
using System.IO;
using System.Drawing;

namespace FleetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        //  private string webRoot = "E://ezimaxtech/FleetManagementAPI/FleetManagementAPI/Webroot/DriverProfile/";
        public DriverController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("GetDriver")]
        [HttpGet]
        public ApiResult<IEnumerable<DriverDetails>> GetDriver()
        {
            ApiResult<IEnumerable<DriverDetails>> result = new ApiResult<IEnumerable<DriverDetails>> { ResponseStatus = false };
            try
            {
                result.data = _repoWrapper.DriverDetails.FindAll();
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Send Successfully !!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }


        [Route("GetDriverById")]
        [HttpPost]
        public ApiResult<DriverDetails> GetDriverById(DriverDetails driverDetail)
        {
            ApiResult<DriverDetails> result = new ApiResult<DriverDetails> { ResponseStatus = false };
            try
            {
                DriverDetails apiDriver = _repoWrapper.DriverDetails.FindByCondition(x => x.Id == driverDetail.Id).FirstOrDefault();
                // apiDriver.ImageUrl = webRoot + apiDriver.ImageUrl;
                result.data = apiDriver;
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Send Successfully !!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }


        [Route("AddDriver")]
        [HttpPost]
        public ApiResult<DriverDetails> AddDriver(DriverDetails driverDetail)
        {
            ApiResult<DriverDetails> result = new ApiResult<DriverDetails> { ResponseStatus = false };
            try
            {

                String path = Directory.GetCurrentDirectory() + "\\Webroot\\DriverProfile\\"; //Path dont change defined into parameter when saving the same
                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                if (!string.IsNullOrEmpty(driverDetail.ImgStr))
                {
                    string exten = new FileInfo(driverDetail.ImageUrl).Extension;
                    string Filename = Guid.NewGuid().ToString() + exten;
                    string imgPath = Path.Combine(path, Filename);
                    string convert = driverDetail.ImgStr.Replace("data:image/png;base64,", string.Empty)
                        .Replace("data:image/jpg;base64,", string.Empty)
                        .Replace("data:image/jpeg;base64,", string.Empty);
                    byte[] imageBytes = Convert.FromBase64String(convert);
                    //FileContentResult fileContent=  File(imageBytes, "image/jpeg");
                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    driverDetail.ImageUrl = Filename;
                    driverDetail.ImgStr = "";
                }


                driverDetail.IsActive = true;
                driverDetail.CreatedBy = 1;
                driverDetail.CreatedDate = DateTime.Now;
                result.data = _repoWrapper.DriverDetails.Create(driverDetail);
                result.ResponseStatus = true;
                result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                result.Message = "Data Save Successfully !!";

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
