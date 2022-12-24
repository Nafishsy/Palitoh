using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth
    {
        Token Authenticate(Account user);
        bool isAuthenticated(string token);
        bool Logout(string token);
    }
}
