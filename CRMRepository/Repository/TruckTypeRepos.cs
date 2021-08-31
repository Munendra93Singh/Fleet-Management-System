using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Models;

namespace FleetManagementRepository.Repository
{
    
    public class TruckTypeRepos : RepositoryBase<TruckType>, ITruckTypeRepos
    {
        public TruckTypeRepos(CRMContext cRMContext) : base(cRMContext)
        {

        }
    }
}
