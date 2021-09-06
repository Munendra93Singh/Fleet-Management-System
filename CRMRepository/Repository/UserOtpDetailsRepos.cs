using CRMRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagementRepository.Repository
{
    public class UserOtpDetailsRepos : RepositoryBase<UserOtp>, IUserOtpDetailsRepos
    {
        public UserOtpDetailsRepos(CRMContext cRMContext) : base(cRMContext)
        {

        }
    }
}
