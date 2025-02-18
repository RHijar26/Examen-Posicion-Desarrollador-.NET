using ExamenDesarrollador.Bussiness.Configuration.Queries;
using ExamenDesarrollador.Entitys.Shops;
using ExamenDesarrollador.Entitys.Shops.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Bussiness.Shops.GetShops
{
    public class GetShopsQuery : IQuery<List<Shop>>
    {

    }
    public class GetShopsQueryHandler : IQueryHandler<GetShopsQuery, List<Shop>>
    {
        private readonly IRepositoryShop repositoryShop;

        public GetShopsQueryHandler(IRepositoryShop repositoryShop)
        {
            this.repositoryShop = repositoryShop;
        }

        public async Task<List<Shop>> Handle(GetShopsQuery request, CancellationToken cancellationToken)
        {
            var result = await repositoryShop.GetShops();

            return result;            
        }
    }
}
