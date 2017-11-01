﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Enitites
{
    public class PointofInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [MaxLength(200)]
        public string Name { get; set; }
        [ForeignKey("CityId")]
        public City City  { get; set; }       
        public int CityId { get; set; }
    }
}