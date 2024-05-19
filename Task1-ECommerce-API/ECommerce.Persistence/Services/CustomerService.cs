using AutoMapper;
using ECommerce.Application.Abstraction.Repositories.Customer;
using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.DTOs.Customer;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReadRepository _readRepository;
        private readonly ICustomerWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerReadRepository readRepository, ICustomerWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public bool Add(CreateCustomerDTO customer)
        {
            bool result = _writeRepository.Add(_mapper.Map<Customer>(customer));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddAsync(CreateCustomerDTO customer)
        {
            bool result = await _writeRepository.AddAsync(_mapper.Map<Customer>(customer));
            await _writeRepository.SaveAsync();
            return result;
        }

        public bool AddRange(List<CreateCustomerDTO> range)
        {
            bool result = _writeRepository.AddRange(_mapper.Map<List<Customer>>(range));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddRangeAsync(List<CreateCustomerDTO> range)
        {
            bool result = await _writeRepository.AddRangeAsync(_mapper.Map<List<Customer>>(range));
            _writeRepository.Save();
            return result;
        }

        public List<CustomerDTO> GetAll(bool isTracking)
        {
            return _mapper.Map<List<CustomerDTO>>(_readRepository.GetAll(isTracking));
        }

        public CustomerDTO? GetById(string id, bool isTracking)
        {
            return _mapper.Map<CustomerDTO>(_readRepository.GetById(id, isTracking));
        }

        public async Task<CustomerDTO?> GetByIdAsync(string id, bool isTracking)
        {
            return _mapper.Map<CustomerDTO>(await _readRepository.GetByIdAsync(id, isTracking));
        }

        public bool Remove(CustomerRemoveDTO customer)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string id)
        {
            bool result = _writeRepository.RemoveById(id);
            _writeRepository.Save();
            return result;
        }

        public bool RemoveRange(List<CustomerRemoveDTO> range)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDTO?> Select(Expression<Func<CreateCustomerDTO, bool>> expression, bool isTracking)
        {
            var mappedExpression = _mapper.Map<Expression<Func<Customer, bool>>>(expression);
            return _mapper.Map<List<CustomerDTO?>>(_readRepository.Select(mappedExpression, isTracking));
        }

        public async Task<CustomerDTO?> SingleOrDefaultAsync(string username, bool isTracking)
        {
            Customer? map = await _readRepository.SingleOrDefaultAsync(x=>x.UserName.Equals(username), isTracking);
            return _mapper.Map<CustomerDTO>(map);
        }


        public async Task<bool> IsUserExists(string email)
        {
            bool isExists = await _readRepository.IsExists(x => x.Email.Equals(email), false);
            return isExists;
        }
    }
}
