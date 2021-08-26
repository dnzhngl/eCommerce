using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Business.Validators;
using ECommerce.Core.Aspects.Validation;
using ECommerce.Core.Extensions;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Repositories;

namespace ECommerce.Business.Concrete
{
    [ValidationAspect(typeof(AccountAddressValidator))]
    public class AccountAddressService : ServiceRepository<AccountAddress, AccountAddressDto>, IAccountAddressService
    {
        private readonly IRepository<AccountAddress> _repository;
        private readonly IMapper _mapper;
        public AccountAddressService(IRepository<AccountAddress> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<PagedList<AccountAddressesDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Filter(filter)
                .ToPagedList<AccountAddress, AccountAddressesDto>(filter, _mapper));
        }


    }
}