using AutoMapper;
using Domain.Contracts;
using Service.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ServiceManger : ISerivceMnager
    {

        private readonly Lazy<IProductService> _ProductSerive;
       // public IProductService ProductService => throw new NotImplementedException();

        private readonly IUnitOfWork _unitOfWork;
        public ServiceManger(IUnitOfWork unitOfWork,IMapper _mapper)
        {
            _ProductSerive = new Lazy<IProductService>(() => new ProductSerivce(unitOfWork, _mapper));
            _unitOfWork = unitOfWork;

        }
        public IProductService ProductService => _ProductSerive.Value;
    }
}
