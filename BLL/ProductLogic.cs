using System;
using DAL;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL
{
    public class ProductLogic
    {
        public Products Create(Products newProduct)
        {
            Products result = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Intentamos recuperar un producto con el mismo nombre
                Products res = r.Retrive<Products>(p => p.ProductName == newProduct.ProductName);

                if (res == null)
                {
                    // Si no existe, lo creamos
                    result = r.Create(newProduct);
                }
                else
                {
                    // Aquí podríamos lanzar una excepción o manejar el caso donde el producto ya existe
                    throw new Exception("El producto ya existe. No se puede duplicar.");
                }
            }

            return result;
        }
        public Products RetrieveByID(int ID)
        {
            Products result = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Busca un producto por su ID
                result = r.Retrive<Products>(p => p.ProductID == ID);
            }

            return result;
        }

        public bool Update(Products productToUpdate)
        {
            bool res = false;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que el nombre de producto no exista en otro registro
                Products temp = r.Retrive<Products>(p => p.ProductName == productToUpdate.ProductName && p.ProductID != productToUpdate.ProductID);

                if (temp == null)
                {
                    // Si no hay conflicto, actualiza el producto
                    res = r.Update(productToUpdate);
                }
                else
                {
                    // Podrías manejar un caso de error aquí, por ejemplo:
                    throw new Exception("El nombre del producto ya existe para otro registro.");
                }
            }

            return res;
        }
        public bool Delete(int ID)
        {
            bool res = false;
            // Buscar el producto para ver si tiene existencias
            var Products = RetrieveByID(ID);
            if (Products != null)
            {
                if (Products.UnitsInStock == 0)
                {
                    // Eliminar el producto
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        res = r.Delete(Products);
                    }
                }
                else
                {
                    // Podemos implementar alguna lógica adicional
                    // para indicar que no se pudo eliminar el producto
                }
            }
            return res;
        }
        public List<Products> FilterByCategoryID(int categoryID)
        {
            List<Products> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Products>(p => p.CategoryID == categoryID);
            }
            return Result;
        }

    }

}