//-----------------------------------------------------------------
		function next(from_page, to_page, func)
		{
			document.getElementById("errors").innerHTML="";
			var isValid=func();
			if(isValid)
			{
				document.getElementById(from_page).style.visibility="hidden";
				document.getElementById(to_page).style.visibility="visible";
			}
		}

		function previous(from_page, to_page)
		{
			document.getElementById("errors").innerHTML="";
			document.getElementById(from_page).style.visibility="hidden";
			document.getElementById(to_page).style.visibility="visible";
			document.getElementById("subscriptions").style.visibility="hidden";
		}

	//--------------------------------------------------------------------	

		function checkLoginOnLettersAndDigits(login)
		{
			if(/^[a-zA-Z0-9]+$/.test(login))
			{
				return true;
			}
			else
			{
				//alert("Login must consist only of english letters and digits");
				document.getElementById("errors").innerHTML+="- Login must consist only of english<br/> letters and digits<br/>";
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
				//alert("Login must have at least one letter in upper case");
				document.getElementById("errors").innerHTML+="- Login must have at least one letter in<br/> upper case<br/>";
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
				//alert("Length of login must be at least 5 characters");
				document.getElementById("errors").innerHTML+="- Length of login must be at least 5<br/> characters<br/>";
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
				//alert("In the end of login must be digit");
				document.getElementById("errors").innerHTML+="- In the end of login must be digit<br/>";
				return false;
			}
		}

		function checkPassword()
		{
			var correctSymbols=0;
			var password1=document.getElementById("password1").value;
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
				//alert("Password is not valid");
				document.getElementById("errors").innerHTML+="- Password is not valid<br/>";
				document.getElementById("errors").innerHTML+="It must contain three categories of next<br/> characters:<br/>"+
															"a). Upper case letters of the English<br/> alphabet<br/>"+
															"b). Lower case letters of the English<br/> alphabet<br/>"+
															"c). Decimal digits<br/>"+
															"d). non-alphanumeric characters<br/>";
				return false;
			}
		}

		function comparePasswords()
		{
			var password1=document.getElementById("password1").value;
			var password2=document.getElementById("password2").value;
			if(password1==password2)
			{
				return true;
			}
			else
			{
				//alert("Passwords must match");
				document.getElementById("errors").innerHTML+="- Passwords must match<br/>";
				return false;
			}
		}	

		function autentificationChecking()
		{
			var login=document.getElementById("login").value;
			var password1=document.getElementById("password1").value;
			var isInUpper=checkLoginOnUpperCase(login);
			var isEndsOnDigit=checkLoginOnDigit(login);	
			var isRightLength=checkLoginOnLength(login);
			var isRightCharacters=checkLoginOnLettersAndDigits(login);
			var isPasswordValid=checkPassword();	
			var isPasswordsMatch=comparePasswords();
			if(isInUpper & isEndsOnDigit & isRightLength & isRightCharacters & isPasswordValid & isPasswordsMatch)
			{
				document.getElementById("getLogin").innerHTML=login;
				document.getElementById("getPassword").innerHTML=password1;
				return true;
			}
		}

		//--------------------------------------------------------------------------------------------------
		function checkFullName()
		{
			var name=document.getElementById("fullName").value;
			if(/^([A-Za-z]+ )([A-Za-z]+ )([A-Za-z]+)$/.test(name))
			{
				document.getElementById("getName").innerHTML=name;
				return true;
			}
			else
			{
				//alert("Full name can only contain characters, and consist of 3 words, separated by a space");
				document.getElementById("errors").innerHTML+="- Full name can only contain characters,<br/>" +
																"and consist of 3 words, separated by<br/> a space<br/>";
				return false;
			}
		}

		function checkDateOfBirth()
		{
			var date=document.getElementById("date").value;
			var partsOfDate=date.split("/");
			if(partsOfDate.length!=3)
			{
				//alert("Date of birth must be a valid date in format dd/mm/yyyy");
				document.getElementById("errors").innerHTML+="- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>";
				return false;
			}
			if(partsOfDate[2].length!=4)
			{
				//alert("Date of birth must be a valid date in format dd/mm/yyyy");
				document.getElementById("errors").innerHTML+="- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>";
				return false;
			}
			var dateFormat=partsOfDate[2]+"-"+partsOfDate[1]+"-"+partsOfDate[0];
			var getDate=new Date(dateFormat);
			if(getDate!="Invalid Date")
			{
				document.getElementById("getDate").innerHTML=date;
				return countAge(getDate);
			}
			else
			{				
				//alert("Date of birth must be a valid date in format dd/mm/yyyy");
				document.getElementById("errors").innerHTML+="- Date of birth must be a valid date<br/> in format dd/mm/yyyy<br/>";
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
				document.getElementById("age").innerHTML=age;
				document.getElementById("getAge").innerHTML=age;
				isValidAge=true;
			}
			else
			{
				//alert("Registration only 12 years");
				document.getElementById("errors").innerHTML+="- Registration only 12 years<br/>";
				document.getElementById("age").innerHTML="";
				document.getElementById("getAge").innerHTML="";
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
			var address=document.getElementById("setAddress").value;
			var city=document.getElementById("city").value;
			var regions=document.getElementById("regions");
			var selectedRegion=regions.options[regions.selectedIndex].text;
			var postcode=document.getElementById("postcode").value;
			
			if(address!="")
			{
				document.getElementById("getAddress").innerHTML=address;
			}
			else
			{
				document.getElementById("getAddress").innerHTML="Unknown";
			}
			
			if(city!="")
			{
				document.getElementById("getCity").innerHTML=city;
			}
			else
			{
				document.getElementById("getCity").innerHTML="Unknown";
			}

			document.getElementById("getRegion").innerHTML=selectedRegion;

			if((postcode.length==5) & (/^[0-9]+$/.test(postcode)))
			{
				document.getElementById("getPostcode").innerHTML=postcode;
				return true;
			}
			else
			{
				//alert("Postcode must contain only five digits");
				document.getElementById("errors").innerHTML+="- Postcode must contain only five digits<br/>";
			}
		}

		//--------------------------------------------------------------------------------------------------------------

		function notificationValidation()
		{
			var isReceiving=document.getElementById("newsReceiving");
			
			email=document.getElementById("email").value;
			var isEmailValid=false;
			var isSubscribed=true;
			if(/\S+@+\S+\.\S+/.test(email))
			{
				isEmailValid=true;
				document.getElementById("getEmail").innerHTML=email;
			}
			else
			{
				//alert("E-mail is not valid");
				document.getElementById("errors").innerHTML+="- E-mail is not valid<br/>";
			}
			if(showSubscriptions())
			{
				isSubscribed = checkOnSubscribing();
			}
			if(!isReceiving.checked)
			{
				document.getElementById("getSubscriptions").innerHTML="";
			}
			if(isEmailValid & isSubscribed)
			{
				document.getElementById("subscriptions").style.visibility="hidden";
				document.getElementById("finish").style.visibility="visible";
				return true;
			}
		}

		function showSubscriptions()
		{
			var isReceiving=document.getElementById("newsReceiving");
			if(isReceiving.checked)
			{
				document.getElementById("subscriptions").style.visibility="visible";
				return true;
			}
			else
			{
				document.getElementById("subscriptions").style.visibility="hidden";
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
				//alert("If you want to receive more news " +
						//"you must choose at least one subscription");
				document.getElementById("errors").innerHTML+="- If you want to receive more news you<br/>"+
																"must choose at least one subscription<br/>";
			}
			document.getElementById("getSubscriptions").innerHTML=setSubscriptions;
			return isChecked;
		}
		//-------------------------------------------------------------------------------------------
		function finishRegistration()
		{
			isAutentificationValid=autentificationChecking();
			isPersonalInfoValid=checkAllPersonalInfo();
			isNotificationValid=notificationValidation();
			isAddressValid=checkAddress();
			if(isNotificationValid & isAddressValid & isNotificationValid & isAddressValid)
			{
				document.getElementById("errors").innerHTML="";
				alert("Registration completed successfully");
			}
		}