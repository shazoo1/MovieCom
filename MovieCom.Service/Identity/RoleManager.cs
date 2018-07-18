using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Service.Identity
{
    public class RoleManager : RoleManager<Role, Guid>
    {
        public RoleManager(IRoleStore<Role, Guid> roleStore)
            : base(roleStore) { }
    }
}
