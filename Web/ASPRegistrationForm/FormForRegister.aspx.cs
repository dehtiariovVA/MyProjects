using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_4
{
    public partial class FormForRegister : System.Web.UI.Page
    {
        Dictionary<string, string[]> countriesAndCities;
        TextBox fieldForNickname;
        TextBox fieldForFName;
        TextBox fieldForLName;
        TextBox email;
        TextBox dateOfBirth;
        Calendar calendar;
        DropDownList listOfCities;
        DropDownList listOfCountries;
        string[] citiesForDropdownList;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            countriesAndCities=new Dictionary<string, string[]>();
            for (int i = 0; i < 5; i++)
            {
                string[] cities = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    cities[j] = "City " + (j + 1) + " of " + "Country " + (i + 1);
                }
                countriesAndCities.Add("Country " + (i + 1), cities);
            }

            Panel panel = new Panel();
            form1.Controls.Add(panel);

            //Work with nickname
            Label field1_name = new Label();
            field1_name.Text = "Nickname<br/>";
            panel.Controls.Add(field1_name);

            fieldForNickname = new TextBox();
            fieldForNickname.ID = "fieldForNickname";
            panel.Controls.Add(fieldForNickname);

            RequiredFieldValidator nickname_checker = new RequiredFieldValidator();
            nickname_checker.ControlToValidate = fieldForNickname.ID;
            nickname_checker.ErrorMessage = "Field for nickname can't be empty";
            nickname_checker.EnableClientScript = false;
            panel.Controls.Add(nickname_checker);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with first name
            Label field2_name = new Label();
            field2_name.Text = "First name<br/>";
            panel.Controls.Add(field2_name);

            fieldForFName = new TextBox();
            fieldForFName.ID = "fieldForFName";
            panel.Controls.Add(fieldForFName);

            RequiredFieldValidator fName_checker = new RequiredFieldValidator();
            fName_checker.ControlToValidate = fieldForFName.ID;
            fName_checker.ErrorMessage = "Field for first name can't be empty";
            fName_checker.EnableClientScript = false;
            panel.Controls.Add(fName_checker);

            CompareValidator fName_comparer = new CompareValidator();
            fName_comparer.EnableClientScript = false;
            fName_comparer.ControlToValidate = fieldForFName.ID;
            fName_comparer.ControlToCompare = fieldForNickname.ID;
            fName_comparer.Operator = ValidationCompareOperator.NotEqual;
            fName_comparer.ErrorMessage = "Values of first name and nickname must be different";
            panel.Controls.Add(fName_comparer);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with last name
            Label field3_name = new Label();
            field3_name.Text = "Last name<br/>";
            panel.Controls.Add(field3_name);

            fieldForLName = new TextBox();
            fieldForLName.ID = "fieldForLName";
            panel.Controls.Add(fieldForLName);

            RequiredFieldValidator lName_checker = new RequiredFieldValidator();
            lName_checker.ControlToValidate = fieldForLName.ID;
            lName_checker.ErrorMessage = "Field for last name can't be empty";
            lName_checker.EnableClientScript = false;
            panel.Controls.Add(lName_checker);

            CompareValidator lName_comparer = new CompareValidator();
            lName_comparer.EnableClientScript = false;
            lName_comparer.ControlToValidate = fieldForLName.ID;
            lName_comparer.ControlToCompare = fieldForFName.ID;
            lName_comparer.Operator = ValidationCompareOperator.NotEqual;
            lName_comparer.ErrorMessage = "Values of last name and first must be different";
            panel.Controls.Add(lName_comparer);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with date
            Label field4_name = new Label();
            field4_name.Text = "Date of birth<br/>";
            panel.Controls.Add(field4_name);

            dateOfBirth = new TextBox();
            dateOfBirth.ID = "dateOfBirth";
            panel.Controls.Add(dateOfBirth);

            RequiredFieldValidator date_checker = new RequiredFieldValidator();
            date_checker.ControlToValidate = dateOfBirth.ID;
            date_checker.ErrorMessage = "Field for date of birth name can't be empty";
            date_checker.EnableClientScript = false;
            panel.Controls.Add(date_checker);

            RangeValidator range_of_date = new RangeValidator();
            range_of_date.EnableClientScript = false;
            range_of_date.ControlToValidate = dateOfBirth.ID;
            range_of_date.Type = ValidationDataType.Date;
            range_of_date.MinimumValue = new DateTime(1960, 12, 1).ToShortDateString();
            range_of_date.MaximumValue = DateTime.Now.ToShortDateString();
            range_of_date.ErrorMessage = "Date must be between 01.12.1960 and till this day";
            panel.Controls.Add(range_of_date);
            panel.Controls.Add(new LiteralControl("<br/><br/>"));

            //Work with calendar
            calendar = new Calendar();
            calendar.SelectionChanged += calendar_SelectionChanged;
            panel.Controls.Add(calendar);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with e-mail
            Label field5_name = new Label();
            field5_name.Text = "E-mail<br/>";
            panel.Controls.Add(field5_name);

            email = new TextBox();
            email.ID = "email";
            panel.Controls.Add(email);

            RequiredFieldValidator email_checker = new RequiredFieldValidator();
            email_checker.ControlToValidate = email.ID;
            email_checker.ErrorMessage = "Field for e-mail name can't be empty";
            email_checker.EnableClientScript = false;
            panel.Controls.Add(email_checker);

            RegularExpressionValidator email_validator = new RegularExpressionValidator();
            email_validator.EnableClientScript = false;
            email_validator.ControlToValidate = email.ID;
            email_validator.ValidationExpression = @"\S+@+\S+\.\S+";
            email_validator.ErrorMessage = "E-mail is not in a vald format";
            panel.Controls.Add(email_validator);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with countries
            Label field6_name = new Label();
            field6_name.Text = "Country<br/>";
            panel.Controls.Add(field6_name);

            listOfCountries = new DropDownList();
            listOfCountries.SelectedIndexChanged += listOfCountries_SelectedIndexChanged;
            listOfCountries.AutoPostBack = true;
            listOfCountries.Width = 173;
            listOfCountries.Height = 23;
            foreach (string country in countriesAndCities.Keys)
            {
                listOfCountries.Items.Add(country);
            }
            panel.Controls.Add(listOfCountries);
            panel.Controls.Add(new LiteralControl("<br/>"));

            //Work with cities
            Label field7_name = new Label();
            field7_name.Text = "City<br/>";
            panel.Controls.Add(field7_name);
            listOfCities = new DropDownList();
            listOfCities.Width = 173;
            listOfCities.Height = 23;
            countriesAndCities.TryGetValue("Country 1", out citiesForDropdownList);
            foreach (string city in citiesForDropdownList)
            {
                listOfCities.Items.Add(city);
            }
            panel.Controls.Add(listOfCities);
            panel.Controls.Add(new LiteralControl("<br/><br/>"));

            //Work with button for postback
            Button buttonPostBack = new Button();
            buttonPostBack.Text = "Post";
            buttonPostBack.Click += buttonPostBack_Click;
            buttonPostBack.CausesValidation = true;
            panel.Controls.Add(buttonPostBack);
            panel.Controls.Add(new LiteralControl("<br/><br/>"));

            //Work with button for cleariing fields
            Button clear = new Button();
            clear.CausesValidation = false;
            clear.Click += clear_Click;
            clear.Text = "Clear fields";
            panel.Controls.Add(clear);
            panel.Controls.Add(new LiteralControl("<br/><br/>"));

            //Work with summary validation
            Label field8_name = new Label();
            field8_name.Text = "Summary validation<br/>";
            panel.Controls.Add(field8_name);
            ValidationSummary summary_validation = new ValidationSummary();
            summary_validation.EnableClientScript = false;
            summary_validation.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            panel.Controls.Add(summary_validation);
            panel.Controls.Add(new LiteralControl("<br/>"));
        }

        void clear_Click(object sender, EventArgs e)
        {
            fieldForNickname.Text = ""; ;
            fieldForFName.Text = "";
            fieldForLName.Text = "";
            email.Text = "";
            dateOfBirth.Text = "";
        }

        void listOfCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = "Country " + (listOfCountries.SelectedIndex + 1).ToString();
            countriesAndCities.TryGetValue(country, out citiesForDropdownList);
            listOfCities.Items.Clear();
            foreach (string city in citiesForDropdownList)
            {
                listOfCities.Items.Add(city);
            }
        }

        void calendar_SelectionChanged(object sender, EventArgs e)
        {
            dateOfBirth.Text = calendar.SelectedDate.ToShortDateString();
        }

        protected void buttonPostBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateOfBirth.Text))
            {
                calendar.VisibleDate = DateTime.Today;
            }
            else
            {
                DateTime selectedDate = DateTime.Today;
                bool b = DateTime.TryParse(dateOfBirth.Text, out selectedDate);
                calendar.VisibleDate = selectedDate;
            }
            if (Page.IsValid)
            {
                Response.Write("Registration is valid");
            }
            else
            {
                Response.Write("Registration isn't valid");
            }
        }
    }
}