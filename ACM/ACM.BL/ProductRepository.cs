using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrieve one product.
        /// </summary>
        public Product Retrieve(int productId)
        {
            // Create the instance of the Product class
            // Pass in the requested Id
            Product product = new Product();

            Object myObject = new Object();
            Console.WriteLine($@"Object: {myObject}");

            // Code that retrieves the defined product

            // Temporary hard coded values to return
            // a populated product
            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Size";
                product.CurrentPrice = 15.96M;
            }
            return product;
        }

        /// <summary>
        ///Saves the current product
        /// </summary>
        public bool Save(Product product)
        {
            var success = true;

            if (product.HasChanges && product.isValid)
            {
                if (product.isNew)
                {
                    // Call an Insert Stored Procedure
                }
                else
                {
                    // Call an Update Stored Procedure
                }
            }

            return success;
        }

    }
}
