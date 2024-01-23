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
    public class StatusBL : IStatusBL
    {
       IStatusRepository statusRepository;
        private IMapper mapper;

        public StatusBL(IStatusRepository statusRepository, IMapper mapper  )
        {
            this.statusRepository = statusRepository;
            this.mapper = mapper;   
        }

        public async Task Add(StatusDTO item)
        {
            try {
             await statusRepository.Add(mapper.Map<Status>(item)); }
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
             await statusRepository.Delete(id);
        }

        public async Task<List<StatusDTO>> GetAll()
        {
            try { 
            List<Status>statuses = await statusRepository.GetAll();
            List<StatusDTO> result = new List<StatusDTO>();
            foreach (var status in statuses)
            {
                result.Add(mapper.Map<StatusDTO>(status));
            }
            return result;}
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

        public async Task<StatusDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusDTO> Update(StatusDTO item, int id)
        {
            try { 
            return mapper.Map<StatusDTO>(
                await   statusRepository.Update(mapper.Map<Status>(item), id));}
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
