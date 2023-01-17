using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoDMS.Models;

namespace DemoDMS.Data
{
    public class DemoDMSContext : DbContext
    {
        public DemoDMSContext (DbContextOptions<DemoDMSContext> options) : base(options) {}

        public DbSet<DemoDMS.Models.Folder> Folder { get; set; }

        public DbSet<DemoDMS.Models.Document> Document { get; set; }
    }
}
