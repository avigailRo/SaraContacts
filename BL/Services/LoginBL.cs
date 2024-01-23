using AutoMapper;
using BL.Interfaces;
using DAL.Exceptions;
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
            try { 
             await loginRepository.Add(mapper.Map<Login>(item));}
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }

        public async Task Delete(int id)
        {
             await loginRepository.Delete(id);
        }

        public async Task<List<LoginDTO>> GetAll()
        {
            try { 
            List<Login>logins = await loginRepository.GetAll();
            List<LoginDTO> list = new List<LoginDTO>();
            foreach (var login in logins) { 
                list.Add(mapper.Map<LoginDTO>(login));
            }
          
            return list; }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }

        public async Task<LoginDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDTO> Update(LoginDTO item, int id)
        {
            try { 
            return mapper.Map<LoginDTO>(
                await   loginRepository.Update(mapper.Map<Login>(item), id));}
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }
    }
}
