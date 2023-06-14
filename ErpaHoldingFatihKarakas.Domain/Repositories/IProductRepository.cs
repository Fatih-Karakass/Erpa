using ErpaHoldingFatihKarakas.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IProductRepository:IGenericRepository<Product,int>
    {
    }
}
