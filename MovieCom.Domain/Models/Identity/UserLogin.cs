﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieCom.Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
