using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Business.Validators;
using ECommerce.Core.Aspects.CacheAspect;
using ECommerce.Core.Aspects.Validation;
using ECommerce.Core.Extensions;
using ECommerce.Core.Helpers;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Concrete
{
    [ValidationAspect(typeof(AccountValidator))]
    public class AccountService : ServiceRepository<Account, AccountDto>, IAccountService
    {
        private readonly IRepository<Account> _repository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<Account> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<AccountsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Include(x => x.Gender)
                .Include(x => x.UserGroup)
                .Include(x => x.Role)
                .Filter(filter)
                .ToPagedList<Account, AccountsDto>(filter, _mapper));
        }

        [RemoveCacheAspect]
        public override async Task<int> InsertAsync(AccountDto dto)
        {
            var entity = _mapper.Map<Account>(dto);
            HashingHelper.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            await _repository.InsertAsync(entity);
            return entity.Id;
        }
        
        [RemoveCacheAspect]
        public override async Task UpdateAsync(int id, AccountDto dto)
        {
            var entity = _mapper.Map<Account>(dto);
            var oldEntity = await _repository.GetAsync(id);

            entity.Id = id;
            entity.PasswordHash = oldEntity.PasswordHash;
            entity.PasswordSalt = oldEntity.PasswordSalt;

            await _repository.UpdateAsync(entity);
        }
    }
}