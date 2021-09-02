using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMRepository;
using FleetManagementRepository.Models;

namespace FleetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public GeolocationController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [Route("GetGeoloactionDetail")]
        [HttpGet]
        public ApiResult<IEnumerable<Geolocation>> GetGeoloactionDetail()
        {
            ApiResult<IEnumerable<Geolocation>> result = new ApiResult<IEnumerable<Geolocation>> { ResponseStatus = false };
            {
                try
                {
                    result.data = _repoWrapper.Geolocation.FindAll();
                    result.ResponseStatus = true;
                    result.StatusCode = FleetManagementRepository.Models.StatusCode.Success.GetHashCode();
                    result.Message = "Data Send Successfully";
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
                return result;
            }
        }
        [Route("GetGeoloactionDetail/{Id}")]
        [HttpGet]
        public Geolocation GetGeoloactionDetail(Guid Id)
        {
            Geolocation geolocation = _repoWrapper.Geolocation.FindByCondition(x => x._Id == Id).FirstOrDefault();
            //apiDrivers.Body = _repoWrapper.ApiDriverRequestFields.FindByCondition(x => x.ApiDriverId == apiDrivers.Id).ToDictionary(dict => dict.key, dict => dict.Value);
            return geolocation;
        }
        [Route("GetApiGeolocation")]
        [HttpGet]
        public IEnumerable<Geolocation> GetApiGeolocation()
        {
            IEnumerable<Geolocation> geolocation = _repoWrapper.Geolocation.FindAll();
            return geolocation;
        }
        [Route("AddGeoloactionDetail")]
        [HttpPost]
        public Geolocation AddGeoloactionDetail(Geolocation geolocation)
        {
            geolocation = _repoWrapper.Geolocation.Create(geolocation);
            return geolocation;
        }
    }
}
