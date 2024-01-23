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
             await groupRepository.Add(mapper.Map<Group>(item));
        }

        public async Task Delete(int id)
        {
             await groupRepository.Delete(id);
        }

        public async Task<List<GroupDTO>> GetAll()
        {
            List<Group>groups = await groupRepository.GetAll();
            List<GroupDTO>groupDTOs = new List<GroupDTO>();
            foreach (Group group in groups)
            {
                groupDTOs.Add(mapper.Map<GroupDTO>(group));
            }
            return groupDTOs;
                }

        public async Task<GroupDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupDTO> Update(GroupDTO item, int id)
        {
            return mapper.Map<GroupDTO>(
               await groupRepository.Update(mapper.Map<Group>(item), id));
        }
    }
}
