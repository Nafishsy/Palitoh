using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Services
{
    public class AccountService
    {

        public static List<AccountDTO> GetAllAccounts()
        {
            var data = DataAccessFactory.AccountDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>());
            var mapper = new Mapper(config);
            var DTOAccounts = mapper.Map<List<AccountDTO>>(data);
            return DTOAccounts;
        }

        public static List<AccountDTO> GetAllAccountsAdmin()
        {
            var data = GetAllAccounts();
            var dt = (from d in data
                      where d.Type != "Admin"
                      select d).ToList();
            return dt;
        }

        public static List<AccountDTO> SearchIntoGetAllAccounts(string search)
        {
            var data = (from dt in GetAllAccounts()
                        orderby dt.Name
                        where dt.Name.ToLower().StartsWith(search.ToLower()) ||  dt.UserName.ToLower().StartsWith(search.ToLower())
                        select dt).ToList();
            return data;
        }
        public static AccountDTO GetAccount(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>());
            var mapper = new Mapper(config);
            var DTOAccount = mapper.Map<AccountDTO>(data);
            return DTOAccount;
        }
        public static AccountDTO AddAccount(AccountDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            var EFAccount = mapper.Map<Account>(obj);
            var result = DataAccessFactory.AccountDataAccess().Add(EFAccount);

            return mapper.Map<AccountDTO>(result);
        }
        public static AccountDTO EditAccount(AccountDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            var EFAccount = mapper.Map<Account>(obj);
            var result = DataAccessFactory.AccountDataAccess().Update(EFAccount);
            var DTOAccount = mapper.Map<AccountDTO>(obj);

            return DTOAccount;
        }
        public static AccountDTO BanAccount(AccountDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            obj.Status = "Banned";
            var EFAccount = mapper.Map<Account>(obj);
            var result = DataAccessFactory.AccountDataAccess().Update(EFAccount);
            var DTOAccount = mapper.Map<AccountDTO>(obj);

            return DTOAccount;
        }
        public static AccountDTO ActivateAccount(AccountDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            obj.Status = "Active";
            var EFAccount = mapper.Map<Account>(obj);
            var result = DataAccessFactory.AccountDataAccess().Update(EFAccount);
            var DTOAccount = mapper.Map<AccountDTO>(obj);

            return DTOAccount;
        }
        public static bool DeleteAccount(AccountDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(config);
            var EFAccount = mapper.Map<Account>(obj);
            var result = DataAccessFactory.AccountDataAccess().Delete(EFAccount);
            return result;
        }

        public static bool DeleteUser(int id)
        {
            var acc = GetAccount(id);
            bool result = DeleteAccount(acc);
            return result;
        }
        public static AccountReportsDTO AccountWithReports(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Account, AccountReportsDTO>();
                c.CreateMap<Report, ReportDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<AccountReportsDTO>(data);
        }
        public static AccountTokensDTO AccountWithTokens(int id)
        {
            var data = DataAccessFactory.AccountDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Account, AccountTokensDTO>();
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<AccountTokensDTO>(data);
        }

        public static bool UpdateAccount(AccountDTO obj)
        {
            var data = GetAccount(obj.Id);

            data.Name = obj.Name;
            data.UserName = obj.UserName;
            data.Type = obj.Type;

            if(EditAccount(data)!=null)
            {
                return true;
            }
            return false;
        }


        public static List<int> AccountsPerType()
        {
            List<int> dt = new List<int>();
            var data = GetAllAccounts();
            int customerCnt = data.Count(d => d.Type == "Customer");
            int vetCnt = data.Count(d => d.Type == "Vet");
            dt.Add(customerCnt);
            dt.Add(vetCnt);
            return dt;

        }
    }
}
