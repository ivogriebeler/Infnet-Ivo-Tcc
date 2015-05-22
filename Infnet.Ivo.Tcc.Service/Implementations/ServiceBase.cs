using Infnet.Ivo.Tcc.Domain.UnitOfWork;
using Infnet.Ivo.Tcc.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Service.Implementations
{
    public class ServiceBase : IServiceBase
    {
        private IUnitOfWork unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
