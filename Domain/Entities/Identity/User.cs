using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities.Identity
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {

    }
}
