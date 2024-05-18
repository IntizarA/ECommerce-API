using AutoMapper;
using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Repositories.Product;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductReadRepository readRepository, IProductWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public bool Add(ProductDTO product)
        {
            bool result = _writeRepository.Add(_mapper.Map<Product>(product));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddAsync(ProductDTO product)
        {
            bool result = await _writeRepository.AddAsync(_mapper.Map<Product>(product));
            await _writeRepository.SaveAsync();
            return result;
        }

        public bool AddRange(List<ProductDTO> range)
        {
            bool result = _writeRepository.AddRange(_mapper.Map<List<Product>>(range));
            _writeRepository.Save();
            return result;
        }

        public async Task<bool> AddRangeAsync(List<ProductDTO> range)
        {
            bool result = await _writeRepository.AddRangeAsync(_mapper.Map<List<Product>>(range));
            _writeRepository.Save();
            return result;
        }

        public List<ProductDTO> GetAll(bool isTracking)
        {
            return _mapper.Map<List<ProductDTO>>(_readRepository.GetAll(isTracking));
        }

        public ProductDTO? GetById(string id, bool isTracking)
        {
            return _mapper.Map<ProductDTO>(_readRepository.GetById(id, isTracking));
        }

        public async Task<ProductDTO?> GetByIdAsync(string id, bool isTracking)
        {
            return _mapper.Map<ProductDTO>(await _readRepository.GetByIdAsync(id, isTracking));
        }

        public bool Remove(ProductDeleteDTO product)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string id)
        {
            bool result = _writeRepository.RemoveById(id);
            _writeRepository.Save();
            return result;
        }

        public bool RemoveRange(List<ProductDeleteDTO> range)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO?> Select(Expression<Func<ProductDTO, bool>> expression, bool isTracking)
        {
            var mappedExpression = _mapper.Map<Expression<Func<Product, bool>>>(expression);
            return _mapper.Map<List<ProductDTO?>>(_readRepository.Select(mappedExpression, isTracking));
        }

        public bool Update(ProductUpdateDTO product)
        {
            bool result = _writeRepository.Update(_mapper.Map<Product>(product));
            _writeRepository.Save();
            return result;
        }
    }
}
