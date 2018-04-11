using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityApp.Web.Security
{
    public interface IUserAuthData
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string PhotoUrl { get; }
        List<string> Roles { get; }

    }
}
