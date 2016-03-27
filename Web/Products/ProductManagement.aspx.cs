using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web_9
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbInsertData_Click(object sender, EventArgs e)
        {
            string imageUrl = ((TextBox)GridView1.FooterRow.
                                                          FindControl("tbForAddingUrl")).Text;                                                                              
            string description = ((TextBox)GridView1.FooterRow.
                                                  FindControl("tbForAddingDescription")).Text;
            string price = ((TextBox)GridView1.FooterRow.
                                                        FindControl("tbForAddingPrice")).Text;
            sourceProducts.InsertParameters["imageUrl"].DefaultValue = 
                                        (String.IsNullOrEmpty(imageUrl))?"Undefined":imageUrl;
            sourceProducts.InsertParameters["productDescription"].DefaultValue =
                               (String.IsNullOrEmpty(description)) ? "Undefined" : description;
            sourceProducts.InsertParameters["productPrice"].DefaultValue =
                                           (String.IsNullOrEmpty(price)) ? "Undefined" : price;
            sourceProducts.Insert();
        }
    }
}