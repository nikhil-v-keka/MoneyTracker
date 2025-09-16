using AutoMapper;
using MoneyTracker.DTOs;
using MoneyTracker.Models;
using MoneyTracker.Repositories;

namespace MoneyTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository trasactionRepository, IMapper mapper)
        { 
            _transactionRepository = trasactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionDto> AddTransaction(TransactionCreateDto transaction)
        {
            var transactionToAdd = _mapper.Map<Transaction>(transaction);
            var newTransaction = await _transactionRepository.AddTransaction(transactionToAdd);
            return _mapper.Map<TransactionDto>(newTransaction);
        }

        public void DeleteTransaction(int id)
        {
            _transactionRepository.DeleteTransaction(id); 
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
        {
            var allTransactions = await _transactionRepository.GetAllTransactions();
            return _mapper.Map<IEnumerable<TransactionDto>>(allTransactions);
        }

        public async Task<TransactionDto> GetTransaction(int id)
        {
            var transaction = await _transactionRepository.GetTransaction(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<TransactionDto> UpdateTransaction(TransactionDto Transaction)
        {
            var transactionToUpdate = _mapper.Map<Transaction>(Transaction);
            var updatedTrasaction = await _transactionRepository.UpdateTransaction(transactionToUpdate);
            return _mapper.Map<TransactionDto>(updatedTrasaction);
        }
    }
}
