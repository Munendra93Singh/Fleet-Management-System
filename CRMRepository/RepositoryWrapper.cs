using System;
using System.Collections.Generic;
using System.Text;
using CRMRepository.IRepository;
using CRMRepository.Repository;
using FleetManagementRepository.IRepository;
using FleetManagementRepository.Repository;

namespace CRMRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CRMContext _cRMContext;
        private IDriverDetailsRepos _apiDriver;
        private IParentBranchRepos _parentBranch;
        private ITruckTypeRepos _truckType;
        private ITruckDetailsRepos _truckDetails;
        private ITruckCompartmentRepos _truckCompartment;
        private IGeolocationDetailsRepos _geolocation;
        private IUserOtpDetailsRepos _userOtp;

        public IUserOtpDetailsRepos UserOtp
        {
            get
            {
                if (_userOtp == null)
                {
                    _userOtp = new UserOtpDetailsRepos(_cRMContext);
                }
                return _userOtp;
            }
        }

        public IGeolocationDetailsRepos Geolocation
        {
            get
            {
                if (_geolocation == null)
                {
                    _geolocation = new GeolocationDetailsRepos(_cRMContext);

                }
                return _geolocation;
            }
        }

        private ITruckDriverDetailsRepos _truckDriverDetails;
        public IDriverDetailsRepos DriverDetails
        {
            get
            {
                if (_apiDriver == null)
                {
                    _apiDriver = new DriverDetailsRepos(_cRMContext);
                    
                }
                return _apiDriver;
            }
        }

        public IParentBranchRepos ParentBranch
        {
            get
            {
                if (_parentBranch == null)
                {
                    _parentBranch = new ParentBranchRepos(_cRMContext);

                }
                return _parentBranch;
            }
        }

        public ITruckTypeRepos TruckType
        {
            get
            {
                if (_truckType == null)
                {
                    _truckType = new TruckTypeRepos(_cRMContext);

                }
                return _truckType;
            }
        }
        public ITruckDetailsRepos TruckDetails
        {
            get
            {
                if (_truckDetails == null)
                {
                    _truckDetails = new TruckDetailsRepos(_cRMContext);

                }
                return _truckDetails;
            }
        }
        public ITruckCompartmentRepos TruckCompartment
        {
            get
            {
                if (_truckCompartment == null)
                {
                    _truckCompartment = new TruckCompartmentRepos(_cRMContext);

                }
                return _truckCompartment;
            }
        }
      
        public ITruckDriverDetailsRepos TruckDriverDetails
        {
            get
            {
                if (_truckDriverDetails == null)
                {
                    _truckDriverDetails = new TruckDriverDetailsRepos(_cRMContext);

                }
                return _truckDriverDetails;
            }
        }

        public RepositoryWrapper(CRMContext cRMContext)
        {
            _cRMContext = cRMContext;
        }
        public void Save()
        {
            _cRMContext.SaveChanges();
        }

    }
}