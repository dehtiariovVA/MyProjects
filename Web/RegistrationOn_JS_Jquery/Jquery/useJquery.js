//next------------------------------------------------------------------------------------------------
	$(function()
	{
		$("#gotoPersonalInfo").click(function(){
			$("#errors").text("");
			if(autentificationChecking())
			{
				$("#autentification").css("visibility", "hidden");
				$("#personal_info").css("visibility", "visible");
				$("#errors").text("");
			}})
	});

	$(function()
	{
		$("#gotoAddress").click(function(){
			$("#errors").text("");
			if(checkAllPersonalInfo())
			{
				$("#personal_info").css("visibility", "hidden");
				$("#address").css("visibility", "visible");
				$("#errors").text("");
			}})
	});

	$(function()
	{
		$("#gotoNotification").click(function(){
			$("#errors").text("");
			if(checkAddress())
			{
				$("#address").css("visibility", "hidden");;
				$("#notification").css("visibility", "visible");
				$("#errors").text("");
			}})
	});

	$(function()
	{
		$("#gotoChecking").click(function(){
			$("#errors").text("");
			if(notificationValidation())
			{
				$("#notification").css("visibility", "hidden");;
				$("#cheking").css("visibility", "visible");
				$("#errors").text("");
			}})
	});

	//finish registration--------------------------------------------------------------------------------------
	$(function()
	{
		$("#finish").click(function(){
			if(autentificationChecking() & checkAllPersonalInfo() & checkAddress() & notificationValidation())
			{
				$("#errors").text("");
				alert("Registration completed successfully");
			}
			})
	});

	//previous-----------------------------------------------------------------------------------------------

	$(function()
	{
		$("#backToAutentification").click(function(){
			$("#errors").text("");
			$("#personal_info").css("visibility", "hidden");
			$("#autentification").css("visibility", "visible");
			$("#subscriptions").css("visibility", "hidden");
		})
	});

	$(function()
	{
		$("#backToPersonalInfo").click(function(){
			$("#errors").text("");
			$("#address").css("visibility", "hidden");
			$("#personal_info").css("visibility", "visible");
			$("#subscriptions").css("visibility", "hidden");
		})
	});

	$(function()
	{
		$("#backToAddress").click(function(){
			$("#errors").text("");
			$("#notification").css("visibility", "hidden");
			$("#address").css("visibility", "visible");
			$("#subscriptions").css("visibility", "hidden");
		})
	});

	$(function()
	{
		$("#backToNotification").click(function(){
			$("#errors").text("");
			$("#cheking").css("visibility", "hidden");
			$("#notification").css("visibility", "visible");
			$("#subscriptions").css("visibility", "hidden");
		})
	});

	//VALIDATION--------------------------------------------------------------------------------------------------
	//--------------------------------------------------------------------	

		function checkLoginOnLettersAndDigits(login)
		{
			if(/^[a-zA-Z0-9]+$/.test(login))
			{
				return true;
			}
			else
			{
				$("#errors").append("- Login must consist only of english<br/> letters and digits<br/>");
				return false;
			}
		}

		function checkLoginOnUpperCase(login)
		{
			var characters=login.split("");
			var i;
			var inUpperCase=0;
			for(i=0;i<characters.length;i++)
			{
				if(isNaN(characters[i]))
				{
					if(characters[i]==characters[i].toUpperCase())
					{
						inUpperCase++;
					}
				}
			}
			if(inUpperCase>=1)
			{
				return true;
			}
			else
			{
				$("#errors").append("- Login must have at least one letter in<br/> upper case<br/>");
				return false;
			}
		}

		function checkLoginOnLength(login)
		{
			if(login.length>=5)
			{
				return true;
			}
			else
			{
				$("#errors").append("- Length of login must be at least 5<br/> characters<br/>");
				return false;
			}
		}	

		function checkLoginOnDigit(login)
		{
			var characters=login.split("");
			if(!isNaN(characters[characters.length-1]))
			{
				return true;
			}
			else
			{
				$("#errors").append("- In the end of login must be digit<br/>");
				return false;
			}
		}

		function checkPassword()
		{
			var correctSymbols=0;
			var password1=$("#password1").val();
			if(/[A-Z]/.test(password1))
			{
				correctSymbols++;
			}
			if(/[a-z]/.test(password1))
			{
				correctSymbols++;
			}
			if(/[0-9]/.test(password1))
			{
				correctSymbols++;
			}
			if(/[^a-zA-Z0-9]/.test(password1))
			{
				correctSymbols++;
			}
			if(correctSymbols>=3)
			{
				return true;
			}
			else
			{
				$("#errors").append("- Password is not valid.<br/>");
				$("#errors").append("It must contain three categories of next<br/> characters:<br/>"+
									"a). Upper case letters of the English<br/> alphabet<br/>"+
									"b). Lower case letters of the English<br/> alphabet<br/>"+
									"c). Decimal digits<br/>"+
									"d). non-alphanumeric characters<br/>");
				return false;
			}
		}

		function comparePasswords()
		{
			var password1=$("#password1").val();
			var password2=$("#password2").val();
			if(password1==password2)
			{
				return true;
			}
			else
			{
				$("#errors").append("- Passwords must match<br/>");
				return false;
			}
		}	

		function autentificationChecking()
		{
			var login=$("#login").val();
			var password1=$("#password1").val();
			var isInUpper=checkLoginOnUpperCase(login);
			var isEndsOnDigit=checkLoginOnDigit(login);	
			var isRightLength=checkLoginOnLength(login);
			var isRightCharacters=checkLoginOnLettersAndDigits(login);
			var isPasswordValid=checkPassword();	
			var isPasswordsMatch=comparePasswords();
			if(isInUpper & isEndsOnDigit & isRightLength & isRightCharacters & isPasswordValid & isPasswordsMatch)
			{
				$("#getLogin").text(login);
				$("#getPassword").text(password1);
				return true;
			}
		}

		//--------------------------------------------------------------------------------------------------
		function checkFullName()
		{
			var name=$("#fullName").val();
			if(/^([A-Za-z]+ )([A-Za-z]+ )([A-Za-z]+)$/.test(name))
			{
				$("#getName").text(name);
				return true;
			}
			else
			{
				$("#errors").append("- Full name can only contain characters,<br/>" +
																"and consist of 3 words, separated by<br/> a space<br/>");
				return false;
			}
		}

		function checkDateOfBirth()
		{
			var date=$("#date").val();
			var partsOfDate=date.split("/");
			if(partsOfDate.length!=3)
			{
				$("#errors").append("- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>");
				return false;
			}
			if(partsOfDate[2].length!=4)
			{

				$("#errors").append("- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>");
				return false;
			}
			var dateFormat=partsOfDate[2]+"-"+partsOfDate[1]+"-"+partsOfDate[0];
			var getDate=new Date(dateFormat);
			if(getDate!="Invalid Date")
			{
				$("#getDate").text(date);
				return countAge(getDate);
			}
			else
			{				
				$("#errors").append("- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>");
				return false;
			}
		}

		function countAge(date)
		{
			var currentDate=new Date();
			var birthDate=date;
			var age=currentDate.getFullYear()-birthDate.getFullYear();
			var isValidAge=false;
			birthDate.setFullYear(currentDate.getFullYear());
			if(currentDate<birthDate)
			{
				age--;
			}
			if(age>=12)
			{
				$("#age").text(age);
				$("#getAge").text(age);
				isValidAge=true;
			}
			else
			{
				$("#errors").append("- Registration only 12 years<br/>");
				$("#age").text("");
				$("#getAge").text("");
				isValidAge=false;
			}
			return isValidAge;
		}

		function checkAllPersonalInfo()
		{
			var isNameValid=checkFullName();
			var isDateValid=checkDateOfBirth();
			if(isNameValid & isDateValid)
			{
				return true;
			}
		}

		//--------------------------------------------------------------------------------------------------
		function checkAddress()
		{			
			var address=$("#setAddress").val();
			var city=$("#city").val();
			var regions=document.getElementById("regions");
			var selectedRegion=regions.options[regions.selectedIndex].text;
			var postcode=$("#postcode").val();
			
			if(address!="")
			{
				$("#getAddress").text(address);
			}
			else
			{
				$("#getAddress").text("Unknown");
			}
			
			if(city!="")
			{
				$("#getCity").text(city);
			}
			else
			{
				$("#getCity").text("Unknown");
			}
			$("#getRegion").text(selectedRegion);

			if((postcode.length==5) & (/^[0-9]+$/.test(postcode)))
			{
				$("#getPostcode").text(postcode);
				return true;
			}
			else
			{
				$("#errors").append("- Postcode must contain only five digits<br/>");
			}
		}

		//--------------------------------------------------------------------------------------------------------------

		function notificationValidation()
		{
			var email=$("#email").val();
			var isEmailValid=false;
			var isSubscribed=true;
			if(/\S+@+\S+\.\S+/.test(email))
			{
				isEmailValid=true;
				$("#getEmail").text(email);
			}
			else
			{
				$("#errors").append("- E-mail is not valid<br/>");
			}
			if(showSubscriptions())
			{
				isSubscribed = checkOnSubscribing();
			}
			if(!($("#newsReceiving").prop('checked')))
			{
				$("#getSubscriptions").text("");
			}
			if(isEmailValid & isSubscribed)
			{
				$("#subscriptions").css("visibility", "hidden");
				$("#finish").css("visibility", "visible");
				return true;
			}
		}

		function showSubscriptions()
		{
			var isReceiving=document.getElementById("newsReceiving");
			if(isReceiving.checked)
			{
				$("#subscriptions").css("visibility", "visible");
				return true;
			}
			else
			{
				$("#subscriptions").css("visibility", "hidden");
				return false;
			}
		}

		function checkOnSubscribing()
		{
			var isChecked=false;
			var subscription=document.getElementById("subscriptions");
			var items=subscription.getElementsByTagName("input");
			var setSubscriptions="";
			for(var i=0;i<items.length;i++)
			{
				if(items[i].checked)
				{
					isChecked=true;
					setSubscriptions+=items[i].value + "/";
				}
			}
			if(isChecked==false)
			{
				$("#errors").append("- If you want to receive more news you<br/>"+
																"must choose at least one subscription<br/>");
			}
			$("#getSubscriptions").text(setSubscriptions);
			return isChecked;
		}