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
  }
}
