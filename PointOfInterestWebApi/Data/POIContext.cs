using Microsoft.EntityFrameworkCore;
using PointOfInterestWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfInterestWebApi.Data
{
    public class POIContext : DbContext
    {
        public POIContext(DbContextOptions<POIContext> options) : base(options)
        {
        }


        public DbSet<PointOfInterest> POI { get; set; }
    }
}
