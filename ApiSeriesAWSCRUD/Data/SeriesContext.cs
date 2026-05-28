using ApiSeriesAWSCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSeriesAWSCRUD.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options)
            : base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}
