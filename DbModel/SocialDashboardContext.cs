using Microsoft.EntityFrameworkCore;
using Socialdashboard.Models;

namespace Socialdashboard.DbModel
{
    public class SocialDashboardContext :DbContext
    {
        public SocialDashboardContext(DbContextOptions options):base(options) 
        { 
        }

        public DbSet<UserMaster> Users { get; set; }
    }
}