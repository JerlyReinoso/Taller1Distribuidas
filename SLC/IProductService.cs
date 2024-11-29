using Entities;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SLC
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Products Create(Products product);

        [OperationContract]
        Products RetrieveByID(int id);

        [OperationContract]
        List<Products> FilterByCategoryID(int categoryId);

        [OperationContract]
        bool Update(Products product);

        [OperationContract]
        bool Delete(int id);
    }
}
