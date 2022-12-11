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
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetAllEmployees()
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var DTOEmployees = mapper.Map<List<EmployeeDTO>>(data);
            return DTOEmployees;
        }
        public static EmployeeDTO GetEmployee(int id)
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var DTOEmployee = mapper.Map<EmployeeDTO>(data);
            return DTOEmployee;
        }
        public static EmployeeDTO AddEmployee(EmployeeDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var EFEmployee = mapper.Map<Employee>(obj);
            var result = DataAccessFactory.EmployeeDataAccess().Add(EFEmployee);

            return mapper.Map<EmployeeDTO>(result);
        }
        public static EmployeeDTO EditEmployee(EmployeeDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var EFEmployee = mapper.Map<Employee>(obj);
            var result = DataAccessFactory.EmployeeDataAccess().Update(EFEmployee);
            var DTOEmployee = mapper.Map<EmployeeDTO>(obj);

            return DTOEmployee;
        }
        public static bool DeleteEmployee(EmployeeDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var EFEmployee = mapper.Map<Employee>(obj);
            var result = DataAccessFactory.EmployeeDataAccess().Delete(EFEmployee);
            return result;
        }
    }
}
