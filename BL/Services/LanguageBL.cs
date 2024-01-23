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
    public class LanguageBL : ILanguageBL
    {
        ILanguageRepository languageRepository;
        private IMapper mapper;

        public LanguageBL(ILanguageRepository languageRepository,IMapper mapper)
        {
            this.languageRepository = languageRepository;
            this.mapper = mapper;
        }

        public async Task Add(LanguageDTO item)
        {
            try { 
             await languageRepository.Add(mapper.Map<Language>(item));}
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
             await languageRepository.Delete(id);
        }

        public async Task<List<LanguageDTO>> GetAll()
        {
            try { 
            List<Language>languages = await languageRepository.GetAll();
            List<LanguageDTO>languageDTOs = new List<LanguageDTO>();
            foreach (Language language in languages)
            {
                languageDTOs.Add(mapper.Map<LanguageDTO>(language));    
            }
            return languageDTOs;}
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

        public async Task <LanguageDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LanguageDTO> Update(LanguageDTO item, int id)
        {
            try { 
            return mapper.Map<LanguageDTO>(
                await languageRepository.Update(mapper.Map<Language>(item), id));}
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
