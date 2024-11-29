using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public class ProductService : IProductService
    {
        private readonly ProductLogic _logic;

        public ProductService()
        {
            _logic = new ProductLogic(); // Aquí puedes inyectar dependencias si es necesario.
        }

        public Products Create(Products product)
        {
            return _logic.Create(product);
        }

        public Products RetrieveByID(int id)
        {
            return _logic.RetrieveByID(id);
        }

        public List<Products> FilterByCategoryID(int categoryId)
        {
            return _logic.FilterByCategoryID(categoryId);
        }

        public bool Update(Products product)
        {
            return _logic.Update(product);
        }

        public bool Delete(int id)
        {
            return _logic.Delete(id);
        }
    }
}
