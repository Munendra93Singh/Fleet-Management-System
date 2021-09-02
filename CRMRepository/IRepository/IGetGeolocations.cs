using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.Repository;
using FleetManagementRepository.Models;

namespace FleetManagementRepository.IRepository
{
    public interface IGetGeolocations : IRepositoryBase<IGetGeolocations>
    {
        Guid Id { get; }
        Guid _Id { get; set; }

        GetGeolocations Create(GetGeolocations getGeolocations);
    }
}
