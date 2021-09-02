using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using FleetManagementRepository.IRepository;

namespace CRMRepository
{
    public interface IRepositoryWrapper
    {
        IDriverDetailsRepos DriverDetails { get; }
        IParentBranchRepos ParentBranch { get; }
        ITruckTypeRepos TruckType { get; }
        ITruckDetailsRepos TruckDetails { get; }
        ITruckCompartmentRepos TruckCompartment { get; }
        IGeolocationDetailsRepos Geolocation { get; }
        object GeolocationDetails { get; }

        ITruckDriverDetailsRepos TruckDriverDetails { get; }
        void Save();
    }
}