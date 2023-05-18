using AkademiPlus.DataAccessLayer.Abstract;
using AkademiPlus.DataAccessLayer.Concrete;
using AkademiPlus.DataAccessLayer.Repositories;
using AkademiPlus.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public EfCustomerDal(Context context) : base(context)
        {

        }
    }
}
