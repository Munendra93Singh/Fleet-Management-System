using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Models;

namespace FleetManagementRepository.Repository
{
    
    public class TruckCompartmentRepos : RepositoryBase<TruckCompartment>, ITruckCompartmentRepos
    {
        public TruckCompartmentRepos(CRMContext cRMContext) : base(cRMContext)
        {

        }
    }
    
}
