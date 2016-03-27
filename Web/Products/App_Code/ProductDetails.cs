using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_9
{
    [Serializable]
    public class ProductDetails
    {
        private int productId;
        private string imageUrl;
        private string productDescription;
        private string productPrice;
        
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
            }
        }

        public string ProductDescription
        {
            get
            {
                return productDescription;
            }
            set
            {
                productDescription = value;
            }
        }

        public string ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
            }
        }

        public ProductDetails(int productId, string imageUrl, string productDescription,
                                            string productPrice)
        {
            this.productId = productId;
            this.imageUrl = imageUrl;
            this.productDescription = productDescription;
            this.productPrice = productPrice;
        }

        public ProductDetails() { }
    }
}