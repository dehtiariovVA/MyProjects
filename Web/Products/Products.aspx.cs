using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_9
{
    public partial class Products : System.Web.UI.Page
    {
        int counter = 0;

        List<ProductDetails> getProducts;
        Queue<ProductDetails> products;
        static Panel mainPanel;
        UpdatePanel updatePanel;
        Button btnNext;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getProducts = (new ProductsDB()).GetProducts();
            products = new Queue<ProductDetails>();
            foreach (var product in getProducts)
            {
                products.Enqueue(product);
            }
            if (!IsPostBack)
            {
                ViewState["products"] = products;
            }

            ScriptManager sm = new ScriptManager();
            form1.Controls.Add(sm);
            mainPanel = new Panel();
            form1.Controls.Add(mainPanel);
            for (int i=0 ; i < 3; i++)
            {
                ProductDetails product = products.Dequeue();
                string imageUrl = product.ImageUrl;
                string description = product.ProductDescription;
                string price = product.ProductPrice;
                mainPanel.Controls.Add(AddProduct(imageUrl, description, price));
            }
            mainPanel.Controls.Add(new LiteralControl("<br/><br/>"));

            updatePanel = new UpdatePanel();
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = "next";
            trigger.EventName = "Click";
            updatePanel.Triggers.Add(trigger);
            form1.Controls.Add(updatePanel);

            if (ViewState["counter"] != null)
            {
                int k = (int)ViewState["counter"];
                for (int i = 0; i < k; i++)
                {
                    counter++;
                    for (int j = 0; j < 3; j++)
                    {
                        ProductDetails product = products.Dequeue();
                        string imageUrl = product.ImageUrl;
                        string description = product.ProductDescription;
                        string price = product.ProductPrice;
                        Panel prod = AddProduct(imageUrl, description, price);
                        updatePanel.ContentTemplateContainer.Controls.Add(prod);
                    }
                    updatePanel.ContentTemplateContainer.Controls.
                                                        Add(new LiteralControl("<br/><br/>"));
                    }
            }

            btnNext = new Button();
            btnNext.ID = "next";
            btnNext.Text = "Next";
            btnNext.Click += btnNext_Click;
            form1.Controls.Add(btnNext);
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            counter++;
            Queue<ProductDetails> p = (Queue<ProductDetails>)ViewState["products"];
            for (int i=0; i<3 ; i++)
            {                
                ProductDetails product = p.Dequeue();
                string imageUrl = product.ImageUrl;
                string description = product.ProductDescription;
                string price = product.ProductPrice;
                Panel prod=AddProduct(imageUrl, description, price);
                updatePanel.ContentTemplateContainer.Controls.Add(prod);
                ViewState["products"] = p;
            }
            updatePanel.ContentTemplateContainer.Controls.
                                                   Add(new LiteralControl("<br/><br/>"));
            ViewState["counter"] = counter;
            if (p.Count == 0)
            {
                btnNext.Enabled = false;
            }
        }

        static Panel AddProduct(string imageUrl, string description, string price)
        {
            Panel product = new Panel();
            product.Style.Add(HtmlTextWriterStyle.Display, "inline-block");
            product.Style.Add(HtmlTextWriterStyle.PaddingRight, "80px");

            Image imageOfProduct = new Image();
            imageOfProduct.Height = new Unit(150, UnitType.Pixel);
            imageOfProduct.Width = new Unit(200, UnitType.Pixel);
            imageOfProduct.ImageUrl = @imageUrl;
            imageOfProduct.AlternateText = "Image missing";
            product.Controls.Add(imageOfProduct);
            product.Controls.Add(new LiteralControl("<br/>"));

            Label descriptionOfProduct = new Label();
            descriptionOfProduct.Text = description;
            descriptionOfProduct.Font.Size = new FontUnit(14);
            descriptionOfProduct.ForeColor = System.Drawing.Color.Blue;
            descriptionOfProduct.Font.Underline = true;
            product.Controls.Add(descriptionOfProduct);
            product.Controls.Add(new LiteralControl("<br/>"));

            Label priceOfProduct = new Label();
            priceOfProduct.Text = price;
            priceOfProduct.BackColor = System.Drawing.Color.OldLace;
            priceOfProduct.ForeColor = System.Drawing.Color.Green;
            priceOfProduct.Font.Size = new FontUnit(18);
            product.Controls.Add(priceOfProduct);
            return product;
        }
    }
}