using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VetService
    {
<<<<<<< Updated upstream
=======
        public static List<VetDTO> GetAllVets()
        {
            var data = DataAccessFactory.VetDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vet, VetDTO>());
            var mapper = new Mapper(config);
            var DTOVets = mapper.Map<List<VetDTO>>(data);
            return DTOVets;
        }
        public static VetDTO GetVet(int id)
        {
            var data = DataAccessFactory.VetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vet, VetDTO>());
            var mapper = new Mapper(config);
            var DTOVet = mapper.Map<VetDTO>(data);
            return DTOVet;
        }
        public static VetDTO AddVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Add(EFVet);

            return mapper.Map<VetDTO>(result);
        }
        public static VetDTO EditVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Update(EFVet);
            var DTOVet = mapper.Map<VetDTO>(obj);

            return DTOVet;
        }
        public static bool DeleteVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Delete(EFVet);
            return result;
        }
        public static VetsCustomerDTO GetAllAppoinments(int id)
        {
            //Aikhane Akta Vet er jonno or shob Customer/Paitent Der info Ashbe
            var data = DataAccessFactory.VetDataAccess().Get(id);

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vet, VetsCustomerDTO>();
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<VetsCustomerDTO>(data);
        }


>>>>>>> Stashed changes
    }
}
