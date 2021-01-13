using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebAPI.Entities;

namespace ContactWebAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponseEntity Authenticate(AuthenticateRequestEntity model);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
    }
}
