using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Web.Configuration;

namespace Web_9
{
    public class ProductsDB
    {
        string pathToDB;

        public ProductsDB()
        {
            //pathToDB = @"D:\Trainee\Web_9\Web_9\Web_9\ProductsStore.xml";
            pathToDB = @WebConfigurationManager.AppSettings["path"];
        }

        public void InsertProduct(string imageUrl, string productDescription,
                                  string productPrice)
        {
            XElement products = XElement.Load(pathToDB);
            int id = (int)products.Elements().Last().Attribute("ID");
            XElement newProduct = new XElement("Product",
                                      new XAttribute("ID", (id + 1)),
                                      new XElement("ImageUrl", imageUrl),
                                      new XElement("Description", productDescription),
                                      new XElement("Price", productPrice));
            products.Add(newProduct);
            products.Save(pathToDB);
        }

        public void DeleteProduct(int productId)
        {
            XElement products = XElement.Load(pathToDB);
            products.Descendants("Product").Where(item =>
                             (int)item.Attribute("ID") == productId).First().Remove();
            int i=1;
            foreach (var item in products.Elements())
            {
                item.Attribute("ID").SetValue(i);
                i++;
            }
            products.Save(pathToDB);
        }

        public void UpdateProduct(int productId, string imageUrl, string productDescription,
                                  string productPrice)
        {
            XElement products = XElement.Load(pathToDB);
            XElement element = products.Descendants("Product").Where(item =>
                                   (int)item.Attribute("ID") == productId).First();
            try
            {
                element.Attribute("ID").SetValue(productId);
                element.Element("ImageUrl").SetValue(imageUrl);
                element.Element("Description").SetValue(productDescription);
                element.Element("Price").SetValue(productPrice);
            }
            catch
            {
                
            }
            products.Save(pathToDB);
        }
        
        public List<ProductDetails> GetProducts()
        {
            List<ProductDetails> listOfProducts = new List<ProductDetails>();
            XElement products = XElement.Load(pathToDB);
            foreach (var product in products.Elements())
            {
                int id = (int)product.Attribute("ID");
                string imageUrl = product.Element("ImageUrl").Value;
                string description = product.Element("Description").Value;
                string price = product.Element("Price").Value;
                listOfProducts.Add(new ProductDetails(id, imageUrl, description, price));
            }
            return listOfProducts;
        }
    }
}