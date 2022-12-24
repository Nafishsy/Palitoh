using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(AccountDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Account>(user);

            var result = DataAccessFactory.AuthDataAccess().Authenticate(data);

            var config2 = new MapperConfiguration(cfg => {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper2 = new Mapper(config2);
            var data2 = mapper2.Map<TokenDTO>(result);
            return data2;
        }

        public static bool isAuthenticated(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().isAuthenticated(token);
            return rs;
        }

        public static bool Logout(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().Logout(token);
            return rs;
        }
    }
}
