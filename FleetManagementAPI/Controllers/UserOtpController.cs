using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMRepository;
using FleetManagementRepository.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FleetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOtpController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public UserOtpController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [Route("GetUserOtpDetail")]
        [HttpGet]
        public ApiResult<IEnumerable<UserOtp>> GetUserOtpDetail()
        {
            ApiResult<IEnumerable<UserOtp>> result = new ApiResult<IEnumerable<UserOtp>> { ResponseStatus = false };
            {
                try
                {
                    result.data = _repoWrapper.UserOtp.FindAll();
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
        [Route("GetUserOtpDetail/{Id}")]
        [HttpGet]
        public UserOtp GetUserOtpDetail(Guid Id)
        {
            UserOtp userOtp = _repoWrapper.UserOtp.FindByCondition(x => x._Id == Id).FirstOrDefault();
            return userOtp;
        }
        [Route("AddUserOtpDetail")]
        [HttpPost]
        public UserOtp AddUserOtpDetail(UserOtp userOtp)
        {
            //Random r = new Random();
            //object p = Math.Floor(100000 + Math.r() * 900000);




            Random r = new Random();
            string OTP = r.Next(1000, 9999).ToString();
            userOtp.OtpCode = OTP;
            UserOtp Otp = _repoWrapper.UserOtp.Create(userOtp);
            ////// Find your Account SID and Auth Token at twilio.com/console
            ////// and set the environment variables. See https://demo.twilio.com/welcome/sms/reply/
            string accountSid = "AC462dc42d2a43c87bbc9f95c8b1b480c5"; //Environment.GetEnvironmentVariable("AC462dc42d2a43c87bbc9f95c8b1b480c5");
            string authToken = "c15bc2effe6d173db6291fad6e9611df";// Environment.GetEnvironmentVariable("c15bc2effe6d173db6291fad6e9611df");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello Your OTP is " + Otp.OtpCode,
                from: new Twilio.Types.PhoneNumber("+18183515416"),
                to: new Twilio.Types.PhoneNumber(userOtp.Mobile)

            );

            return Otp;
        }
    }
}
