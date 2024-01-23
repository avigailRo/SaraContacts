﻿using AutoMapper;
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
    public class ContacBL : IContactBL
    {
       IContactRepository contactRepository;
        private IMapper mapper;

        public ContacBL(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper=mapper;
        }

        public async Task Add(ContactDTO item)
        {
            try { 
             await contactRepository.Add(mapper.Map<Contact>(item));}
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
             await contactRepository.Delete(id);
        }

        public async Task<List<ContactDTO>> GetAll()
        {
            try { 
            List<Contact>contacts = await contactRepository.GetAll();
            List<ContactDTO> result = new List<ContactDTO>();   
            foreach (Contact contact in contacts)
            {
                result.Add(mapper.Map<ContactDTO>(contact));    
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

        public async Task<ContactDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactDTO> Update(ContactDTO item, int id)
        {
            try { 
            return mapper.Map<ContactDTO>(
                await contactRepository.Update(mapper.Map<Contact>(item), id));}
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
