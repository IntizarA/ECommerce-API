using AutoMapper;
using ECommerce.Application.Abstraction.Repositories.Customer;
using ECommerce.Application.Abstraction.Repositories.Order;
using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReadRepository _readRepository;
        private readonly IOrderWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderReadRepository readRepository, IOrderWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public bool Add(OrderDTO order)
        {
            bool result = _writeRepository.Add(_mapper.Map<Order>(order));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddAsync(OrderDTO order)
        {
            bool result = await _writeRepository.AddAsync(_mapper.Map<Order>(order));
            await _writeRepository.SaveAsync();
            return result;
        }

        public bool AddRange(List<OrderDTO> range)
        {
            bool result = _writeRepository.AddRange(_mapper.Map<List<Order>>(range));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddRangeAsync(List<OrderDTO> range)
        {
            bool result = await _writeRepository.AddRangeAsync(_mapper.Map<List<Order>>(range));
            _writeRepository.Save();
            return result;
        }

        public List<OrderDTO> GetAll(bool isTracking)
        {
            return _mapper.Map<List<OrderDTO>>(_readRepository.GetAll(isTracking));
        }

        public OrderDTO? GetById(string id, bool isTracking)
        {
            return _mapper.Map<OrderDTO>(_readRepository.GetById(id, isTracking));
        }

        public async Task<OrderDTO?> GetByIdAsync(string id, bool isTracking)
        {
            return _mapper.Map<OrderDTO>(await _readRepository.GetByIdAsync(id, isTracking));
        }

        public bool Remove(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string id)
        {
            bool result = _writeRepository.RemoveById(id);
            _writeRepository.Save();
            return result;
        }

        public bool RemoveRange(List<OrderDTO> range)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO?> Select(Expression<Func<OrderDTO, bool>> expression, bool isTracking)
        {
            var mappedExpression = _mapper.Map<Expression<Func<Order, bool>>>(expression);
            return _mapper.Map<List<OrderDTO?>>(_readRepository.Select(mappedExpression, isTracking));
        }

        public bool Update(UpdateOrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(_readRepository.GetById(orderDTO.Id, false));
            
            ICollection<OrderDetail> orderDetails = orderDTO.OrderDetails
                .Select(dto => _mapper.Map<OrderDetail>(dto))
                .ToList();

            order.OrderDetails = orderDetails;

            bool result = _writeRepository.Update(_mapper.Map<Order>(order));
            _writeRepository.Save();
            return result;
        }
    }
}
