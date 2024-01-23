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
             await languageRepository.Add(mapper.Map<Language>(item));
        }

        public async Task Delete(int id)
        {
             await languageRepository.Delete(id);
        }

        public async Task<List<LanguageDTO>> GetAll()
        {
            List<Language>languages = await languageRepository.GetAll();
            List<LanguageDTO>languageDTOs = new List<LanguageDTO>();
            foreach (Language language in languages)
            {
                languageDTOs.Add(mapper.Map<LanguageDTO>(language));    
            }
            return languageDTOs;
        }

        public async Task <LanguageDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LanguageDTO> Update(LanguageDTO item, int id)
        {
            return mapper.Map<LanguageDTO>(
                await languageRepository.Update(mapper.Map<Language>(item), id));
        }
    }
}
