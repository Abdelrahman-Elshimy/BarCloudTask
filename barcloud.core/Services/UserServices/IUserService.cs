using barcloud.core.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcloud.core.Services.UserServices
{
    public interface IUserService
    {
        GetUserTokenDto Authenticate(UserLogin userLogin);
    }
}
