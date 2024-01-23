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
    public class GroupBL : IGroupBL
    {
        IGroupRepository groupRepository;
        private IMapper mapper;

        public GroupBL(IGroupRepository groupRepository,IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public async Task Add(GroupDTO item)
        {
            try { 
             await groupRepository.Add(mapper.Map<Group>(item));}
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

             await groupRepository.Delete(id);
        }

        public async Task<List<GroupDTO>> GetAll()
        {
            try { 
            List<Group>groups = await groupRepository.GetAll();
            List<GroupDTO>groupDTOs = new List<GroupDTO>();
            foreach (Group group in groups)
            {
                groupDTOs.Add(mapper.Map<GroupDTO>(group));
            }
            return groupDTOs;
                }
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

        public async Task<GroupDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupDTO> Update(GroupDTO item, int id)
        {
            try { 
            return mapper.Map<GroupDTO>(
               await groupRepository.Update(mapper.Map<Group>(item), id));}
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
