using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
