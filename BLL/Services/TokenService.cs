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
    public class TokenService
    {
        public static List<TokenDTO> GetAllTokens()
        {
            var data = DataAccessFactory.TokenDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenDTO>());
            var mapper = new Mapper(config);
            var DTOTokens = mapper.Map<List<TokenDTO>>(data);
            return DTOTokens;
        }
        public static TokenDTO GetToken(int id)
        {
            var data = DataAccessFactory.TokenDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenDTO>());
            var mapper = new Mapper(config);
            var DTOToken = mapper.Map<TokenDTO>(data);
            return DTOToken;
        }
        public static TokenDTO AddToken(TokenDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var EFToken = mapper.Map<Token>(obj);
            var result = DataAccessFactory.TokenDataAccess().Add(EFToken);

            return mapper.Map<TokenDTO>(result);
        }
        public static TokenDTO EditToken(TokenDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var EFToken = mapper.Map<Token>(obj);
            var result = DataAccessFactory.TokenDataAccess().Update(EFToken);
            var DTOToken = mapper.Map<TokenDTO>(obj);

            return DTOToken;
        }
        public static bool DeleteToken(TokenDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var EFToken = mapper.Map<Token>(obj);
            var result = DataAccessFactory.TokenDataAccess().Delete(EFToken);
            return result;
        }
    }
}
