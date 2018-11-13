using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace ACM.BL
{
    public class Product : EntityBase
    {
        public Product()
        {
            
        }

        public Product(int productId)
        {
            ProductId = productId;
        }

        public Decimal? CurrentPrice { get; set; }
        public int ProductId { get; private set; }
        public string ProductDescription { get; set; }
        private String _ProductName;

        public String ProductName
        {
            get
            {
               //return StringHandler.InsertSpaces(_ProductName);
                return _ProductName.InsertSpaces();
            }
            set { _ProductName = value; }
        }



        /// <summary>
        ///Validates the product data/
        /// </summary>
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return ProductName;
        }
        public string Log()
        {
            var logString = ProductId + ": " +
                            ProductName + " " +
                            "Email: " + ProductDescription + " " +
                            "Status: " + EntityState;

            return logString;
        }

    }
}
