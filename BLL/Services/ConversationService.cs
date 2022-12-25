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
    public class ConversationService
    {
        public static List<ConversationDTO> GetAllConversations() //Conversations inventory
        {
            var data = DataAccessFactory.ConversationDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Conversation, ConversationDTO>());
            var mapper = new Mapper(config);
            var DTOConversations = mapper.Map<List<ConversationDTO>>(data);
            return DTOConversations;
        }
        public static ConversationDTO GetConversation(int id)
        {
            var data = DataAccessFactory.ConversationDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Conversation, ConversationDTO>());
            var mapper = new Mapper(config);
            var DTOConversation = mapper.Map<ConversationDTO>(data);
            return DTOConversation;
        }

        public static List<ConversationDTO> GetConversationByID(int id)
        {
            var data = GetAllConversations();
            var dt = (from d in data
                      where d.ChatId == id
                      select d).ToList();
            return dt;
        }
        public static ConversationDTO AddConversation(ConversationDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ConversationDTO, Conversation>();
                cfg.CreateMap<Conversation, ConversationDTO>();
            });
            var mapper = new Mapper(config);
            var EFConversation = mapper.Map<Conversation>(obj);
            var result = DataAccessFactory.ConversationDataAccess().Add(EFConversation);

            return mapper.Map<ConversationDTO>(result);
        }
        public static ConversationDTO EditConversation(ConversationDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ConversationDTO, Conversation>();
                cfg.CreateMap<Conversation, ConversationDTO>();
            });
            var mapper = new Mapper(config);
            var EFConversation = mapper.Map<Conversation>(obj);
            var result = DataAccessFactory.ConversationDataAccess().Update(EFConversation);
            var DTOConversation = mapper.Map<ConversationDTO>(obj);

            return DTOConversation;
        }
        public static bool DeleteConversation(ConversationDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ConversationDTO, Conversation>();
                cfg.CreateMap<Conversation, ConversationDTO>();
            });
            var mapper = new Mapper(config);
            var EFConversation = mapper.Map<Conversation>(obj);
            var result = DataAccessFactory.ConversationDataAccess().Delete(EFConversation);
            return result;
        }
    }
}
