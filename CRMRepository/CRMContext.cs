using CRMRepository.Models;
using FleetManagementRepository.Models;
using Microsoft.EntityFrameworkCore;


namespace CRMRepository
{
    public class CRMContext : DbContext
    {

        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }
        public DbSet<ApiDriver> ApiDriver { get; set; }
        public DbSet<ParentBranch> ParentBranch { get; set; }
        public DbSet<TruckType> TruckType { get; set; }
        public DbSet<TruckDetails> TruckDetails { get; set; }
        public DbSet<TruckCompartment> TruckCompartment { get; set; }
    }
}
