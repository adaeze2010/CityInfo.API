﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Enitites
{
    public class CityInfoContext :DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<City>  Cities { get; set; }
        public DbSet<PointofInterest> PointsOfInterest { get; set; }


    }
}
