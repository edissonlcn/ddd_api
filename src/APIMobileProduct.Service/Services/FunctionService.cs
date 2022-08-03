using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Function;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces;
using APIMobileProduct.Domain.Interfaces.Services.Function;
using APIMobileProduct.Domain.Models;
using AutoMapper;

namespace APIMobileProduct.Service.Services
{
    public class FunctionService : IFunctionService
    {
        private IRepository<FunctionEntity> _repository;

        private readonly IMapper _mapper;
        public FunctionService(IRepository<FunctionEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<FunctionDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<FunctionDto>(entity) ?? new FunctionDto();
        }

        public async Task<IEnumerable<FunctionDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<FunctionDto>>(listEntity);
        }

        public async Task<FunctionDtoCreateResult> Post(FunctionDtoCreate Function)
        {
            var model = _mapper.Map<FunctionModel>(Function);
            var entity = _mapper.Map<FunctionEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<FunctionDtoCreateResult>(result);
        }

        public async Task<FunctionDtoUpdateResult> Put(FunctionDtoUpdate Function)
        {

            var model = _mapper.Map<FunctionModel>(Function);
            var entity = _mapper.Map<FunctionEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<FunctionDtoUpdateResult>(result);
        }
    }
}
