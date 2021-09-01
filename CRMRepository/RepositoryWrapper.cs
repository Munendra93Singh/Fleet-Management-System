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