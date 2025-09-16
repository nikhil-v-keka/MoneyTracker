using AutoMapper;
using MoneyTracker.DTOs;
using MoneyTracker.Models;

namespace MoneyTracker.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();

            CreateMap<TransactionCreateDto, Transaction>();
        
        }
    }
}
