﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Common.Enums;

namespace MovieCom.Domain.Models.Entities
{
    public class Media : BaseEntity
    {
        public string Link { get; set; }
        public MediaType Type { get; set; }
    }
}
