using AuthServer.Core.Repository;
using AuthServer.Core.Service;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class GenericService<T, TDto> : IGenericService<T, TDto> where T : class where TDto : class
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
             var newEntity= ObjectMapper.Mapper.Map<T>(entity);

            await _repository.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return Response<TDto>.Success(newDto, 200);
        }


        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
             var products = ObjectMapper.Mapper.Map<List<TDto>>(await _repository.GetAllAsync());

            return Response<IEnumerable<TDto>>.Success(products, 200);

        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product==null)
            {
                return Response<TDto>.Fail(404, "ID not found", true);
            }

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }


        public async Task<Response<NoDataDto>> Delete(int id)
        {
            var isExist = await _repository.GetByIdAsync(id);

            if (isExist == null)
            {
                return Response<NoDataDto>.Fail(404, "ID not found", true);
            }

            _repository.Delete(isExist);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }


        public async Task<Response<NoDataDto>> Update(TDto entity, int id)
        {
            var isExist = await _repository.GetByIdAsync(id);

            if(isExist == null)
            {
                return Response<NoDataDto>.Fail(404, "ID not found", true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<T>(entity);

            _repository.Update(updateEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);

        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<T, bool>> predicate)
        {
            var list = _repository.Where(predicate);

            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()),200);
        }
    }
}
