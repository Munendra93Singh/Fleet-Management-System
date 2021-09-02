using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Models;
using CRMRepository.IRepository;
using CRMRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository;

namespace FleetManagementRepository.Repository
{
    public class GeolocationDetailsRepos : RepositoryBase<Geolocation>, IGeolocationDetailsRepos
    {
        public GeolocationDetailsRepos(CRMContext cRMContext) : base(cRMContext)
        {

        }        
    }
}
