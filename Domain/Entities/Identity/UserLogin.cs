﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
