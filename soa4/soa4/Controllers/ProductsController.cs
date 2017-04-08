using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace soa4.Controllers
{
    public class ProductsController : ApiController
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<Product> Get()
        {
            return db.Products.AsEnumerable();
        }

        public Product Get(int id)
        {
            return db.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public Product Post(string name, decimal price, string description)
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Description = description
            };

            db.Products.InsertOnSubmit(product);
            db.SubmitChanges();
            return product;
        }
        public Product Post(Product product)
        {
            Product foundProduct = db.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if (foundProduct != null)
            {
                foundProduct.Name = product.Name;
                foundProduct.Price = product.Price;
                foundProduct.Description = product.Description;
            }
            db.SubmitChanges();
            return foundProduct;
        }
        public void Delete(int id)
        {
            Product product = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                db.Products.DeleteOnSubmit(product);
            }
            db.SubmitChanges();
        }

    }
}
