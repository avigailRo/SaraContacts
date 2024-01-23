using AutoMapper;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LoginBL : ILoginBL
    {
       ILoginRepository loginRepository;
        private IMapper mapper;

        public LoginBL(ILoginRepository loginRepository, IMapper mapper)
        {
            this.loginRepository = loginRepository;
            this.mapper = mapper;
        }
        public async Task Add(LoginDTO item)
        {
             await loginRepository.Add(mapper.Map<Login>(item));
        }

        public async Task Delete(int id)
        {
             await loginRepository.Delete(id);
        }

        public async Task<List<LoginDTO>> GetAll()
        {
            List<Login>logins = await loginRepository.GetAll();
            List<LoginDTO> list = new List<LoginDTO>();
            foreach (var login in logins) { 
                list.Add(mapper.Map<LoginDTO>(login));
            }
          
            return list;   
        }

        public async Task<LoginDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDTO> Update(LoginDTO item, int id)
        {
            return mapper.Map<LoginDTO>(
                await   loginRepository.Update(mapper.Map<Login>(item), id));
        }
    }
}
