using System.Collections.ObjectModel;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace theBankingApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            banking();

            Console.Clear();
            Console.WriteLine("Have a nice day. GoodBye!");
            Console.WriteLine();
            Console.Write("Press any key to shut down... ");
            Console.ReadKey();

        }

        public static void banking()
        {
            Random accountRan = new Random();
            string newfullName = "", newuserName = "", newpassword = "",
            newplaceOfBirth = "", newstateOfOrigin = "", newlga = "", newnextofkin = "";
            double newdepositing; DateTime newcollectedDate;
            int newAcctNumber = 0;

            Users person1 = new Users();
            Users person2 = new Users();
            Users person3 = new Users();
            Users person4 = new Users();
            Users person5 = new Users();

            person1.FullName = "Steven Ike" ;
            person1.AccountNumber = accountRan.Next(2010000000, 2100000000);
            person1.UserName = "steven123";
            person1.Password = "12345";
            person1.Amount = 10000;
            person1.Dob = DateTime.Parse("02/20/1996");
            person1.PlaceOfBirth = "Edo state";
            person1.StateOfOrigin = "Odo";
            person1.LGA = "Oredo" ;
            person1.NextOfKin = "kelvin";

            person2.FullName = "Michael Efosa" ;
            person2.AccountNumber = accountRan.Next(2010000000, 2100000000);
            person2.UserName = "michael123";
            person2.Password = "12345";
            person2.Amount = 30000;
            person2.Dob = DateTime.Parse("12/02/1978");
            person2.PlaceOfBirth = "Edo state";
            person2.StateOfOrigin = "Odo";
            person2.LGA = "Oredo" ;
            person2.NextOfKin = "Steven";

            person3.FullName = "George Peters" ;
            person3.AccountNumber = accountRan.Next(2010000000, 2100000000);
            person3.UserName = "george123";
            person3.Password = "12345";
            person3.Amount = 450000;
            person3.Dob = DateTime.Parse("07/15/1989");
            person3.PlaceOfBirth = "Edo state";
            person3.StateOfOrigin = "Odo";
            person3.LGA = "Oredo" ;
            person3.NextOfKin = "Victor";

            person4.FullName = "Lukas Decker" ;
            person4.AccountNumber = accountRan.Next(2010000000, 2100000000);
            person4.UserName = "decker123";
            person4.Password = "12345";
            person4.Amount = 660000;
            person4.Dob = DateTime.Parse("07/15/1999");
            person4.PlaceOfBirth = "Edo state";
            person4.StateOfOrigin = "Odo";
            person4.LGA = "Oredo" ;
            person4.NextOfKin = "Victor";

            person5.FullName = "Lucy Lane" ;
            person5.AccountNumber = accountRan.Next(2010000000, 2100000000);
            person5.UserName = "lane123";
            person5.Password = "12345";
            person5.Amount = 850000;
            person5.Dob = DateTime.Parse("07/15/1965");
            person5.PlaceOfBirth = "Benin City";
            person5.StateOfOrigin = "Lagos";
            person5.LGA = "Oredo" ;
            person5.NextOfKin = "Victor";

            List<Users> users = new List<Users>();
            users.Add(person1);
            users.Add(person2);
            users.Add(person3);
            users.Add(person4);
            users.Add(person5);
            
            //User interface
            bool on = true;
            while(on)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Daniel's Banking terminal.");
                Console.WriteLine();
                Console.WriteLine("Please type one of the options below to proceed...");
                Console.WriteLine("1) Customer SignIn (SignIn)\n2) Banker LogIn (Admin)\n3) Exit Application (Exit or Quit)  "
                +"\n\nOr you don't have an account, please type \"SignUp\" to create one now.");
                Console.Write("Answer => ");
                string method = Console.ReadLine();
                method = method.ToLower();

                
                //Customers sign in panel
                if (method == "customer" || method == "1" || method == "signin")
                {
                    //Customers loggin panel
                    bool loggedIN = false;
                    bool removedLOG = false;
                    bool quit = false;
                    while(!loggedIN && !quit)
                    {
                        Console.Clear();

                        Console.WriteLine("Sign-in to your account.");
                        Console.WriteLine();
                        Console.Write("UserName => ");
                        string userName = Console.ReadLine();
                        Console.Write("Password => ");
                        string password = Console.ReadLine();
                        userName = userName.ToLower();
                        bool sure = false;
                        bool terminate = false;

                        for (int i = 0; i < users.Count; i++)
                        {

                            if(userName == users[i].UserName && password == users[i].Password)
                            {
                                users[i].Profile(users[i].FullName, out sure, out terminate);

                                if(sure)
                                {
                                    users.Remove(users[i]);
                                    loggedIN = true;
                                    quit = true;
                                    break;
                                }

                                if(terminate)
                                {
                                    loggedIN = true;
                                    quit = true;
                                    break;
                                }

                                break;
                            }
                            else
                            {
                                loggedIN = false;
                                continue;
                            }

                            
                        }

                        if (!loggedIN && !removedLOG)
                        {
                            bool keepAsking = true;
                            int askingCount = 1;
                            while(keepAsking)
                            {
                                Console.Clear();
                                
                                if (askingCount == 1)
                                {
                                    Console.WriteLine("Your login credentials were invalid...");
                                    Console.WriteLine();
                                }
                                
                                Console.Write("Would you like to try signing in again...? \n\nType and enter \"Y\"(Yes) \"N\"(No) to proceed => ");
                                string answer = Console.ReadLine();
                                answer = answer.ToLower();

                                if(answer == "y")
                                {
                                    quit = false;
                                    keepAsking = false;
                                }
                                else if( answer == "n")
                                {
                                    quit = true;
                                    keepAsking = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    keepAsking = true;
                                    Console.Write("I do not understand that.\n\nPress any to proceed... ");
                                    Console.ReadKey();
                                }

                                askingCount ++;
                            }
                        }
                        else
                        {
                            break;
                        }
                
                    }

                    on = true;
                }
                //Admins viewport, the admin here is not allow to manipulate clients account.
                else if(method == "banker" || method == "2" || method == "admin")
                {
                    Console.Clear();
                    Console.WriteLine("List of all the Account holders in Daniel's Bank.");
                    Console.WriteLine();
                    int loopingon = 1;
                    
                    foreach (Users user in users)
                    {
                        
                        Console.WriteLine(loopingon +") FullName: "+user.FullName +". \n   Account Number: "+ user.AccountNumber +"\n   Balance: {0:C} \n   Date Of Birth: "
                        + user.Dob.ToLongDateString() +". \n   Place Of Birth: "+ user.PlaceOfBirth 
                        +". \n   State Of Origin: "+ user.StateOfOrigin +". \n   Local Goverment Area: "+ user.LGA +". \n   Next Of Kin: "
                        + user.NextOfKin+".", user.Amount);

                        Console.WriteLine();
                        loopingon ++;
                    }
                    Console.Write("Press any key to return back to the Main Menu... ");
                    Console.ReadKey();
                    
                    on = true;
                }
                //Quitting the application
                else if (method == "quit" || method == "3" || method == "exit")
                {
                    on = false;
                }
                //Sign up sheet for new customers
                else if(method == "signup")
                {
                    Console.Clear();
                    Console.WriteLine("Please fill the form with your correct details.");
                    Console.WriteLine();
                    Console.Write("Please enter your Full Name... => ");
                    newfullName = Console.ReadLine();
                    
                    bool invalid = true;
                    int loopNumber = 1;
                    newuserName = "";
                    newpassword = "";
                    string inputuserName = "";

                    while(invalid)
                    {
                        Console.Clear();
                        Console.WriteLine("Hi, "+ newfullName + ".");
                        int foreachTimes = 1;
                        if (loopNumber > 1)
                        {
                            Console.WriteLine("User Name already in use, please try something else...");
                        }

                        Console.WriteLine();
                        Console.Write("Please enter your UserName... => ");
                        inputuserName = Console.ReadLine();
                        newuserName = inputuserName.ToLower();

                        Console.Write("Please enter your Password... => ");
                        newpassword = Console.ReadLine();
                        

                        foreach(Users check in users)
                        {
                            if (newuserName == check.UserName)
                            {
                                newuserName = "";
                                newpassword = "";
                                invalid = true;
                            }
                            else if (newuserName != check.UserName && foreachTimes == users.Count )
                            {
                                invalid = false;
                            }
                            else
                            {
                                invalid = true;
                            }
                            
                            foreachTimes ++;
                        }

                        loopNumber ++;
                    }

                    var worked = false;
                    newcollectedDate = DateTime.MinValue;
                    
                    while(!worked)
                    {
                        Console.Clear();
                        Console.WriteLine("Hi "+ newfullName + ".");
                        Console.WriteLine();
                        Console.Write("Please enter your Date of birth... ( E.g "+ CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern +") => ");
                        string input = Console.ReadLine();
                        worked = DateTime.TryParse(input, out newcollectedDate);

                        var birth = worked == true ? newcollectedDate.Year.ToString() : "";

                        if(!worked)
                        {
                            Console.Clear();
                            Console.WriteLine("You seem to have entered the wrong format or chacracter, please use this Example as a reference...  " + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern );
                            Console.WriteLine();
                            Console.WriteLine("Press any key to retry... ");
                            Console.ReadKey();
                        }
                        else if ( int.Parse(birth) >= 2003 || int.Parse(birth) < 1900)
                        {
                            Console.Clear();
                            worked = false;
                            Console.WriteLine("Sorry! You should be 18 years or older to use this service. ");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to retry... ");
                            Console.ReadKey();
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.Clear();
                    Console.Write("Please enter your Place Of Birth... => ");
                    newplaceOfBirth = Console.ReadLine();

                    Console.Clear();
                    Console.Write("Please enter your State Of Origin... => ");
                    newstateOfOrigin = Console.ReadLine();

                    Console.Clear();
                    Console.Write("Please enter your current Local Goverment Area... => ");
                    newlga = Console.ReadLine();

                    Console.Clear();
                    Console.Write("Please enter the full name of your Next of Kin... => ");
                    newnextofkin = Console.ReadLine();

                    bool isNotGood = true;
                    var siting = false;
                    int hasNow = 0;
                    
                    while(isNotGood)
                    {
                        Console.Clear();
                        Console.Write("How much would you like to deposit... => ");
                        string depo = Console.ReadLine();
                        siting = int.TryParse(depo, out hasNow);

                        if (hasNow < 100 && siting)
                        {
                            
                            int min = 100, mas = 1000000;
                            Console.Clear();
                            Console.WriteLine("Please minimum deposit is {0:C} and Maximum deposit is {1:C}", min,mas);
                            Console.WriteLine();
                            Console.WriteLine("Press any key to go back... ");
                            Console.ReadKey();
                            isNotGood = true;
                        }
                        else if(!siting)
                        {
                            int eg = 100000;
                            Console.Clear();
                            Console.WriteLine("Error 401\n\nPlease enter a whole number without decimals... E.g {0:N} (without the comma)", eg);
                            Console.WriteLine();
                            Console.WriteLine("Press any key to go back... ");
                            Console.ReadKey();
                            isNotGood = true;
                        }
                        else
                        {
                            isNotGood = false;
                            break;
                        }

                    }

                    newdepositing = hasNow;

                    bool acctCheckInvalid = true;
                    int acctinsert = 0;
                    int counter = 0;

                    while(acctCheckInvalid)
                    {
                        acctinsert = accountRan.Next(2010000000, 2090000000);
                        
                        for(int i = 0; i < users.Count; i++)
                        {
                            if(users[i].AccountNumber == acctinsert)
                            {
                                counter ++;
                            }
                            else if(counter > 0)
                            {
                                counter = 0;
                                acctCheckInvalid = true;
                            }
                            else
                            {
                                acctCheckInvalid = false;
                            }

                        }

                    }

                    newAcctNumber = acctinsert;

                    Console.Clear();
                    Users newUser = new Users(newfullName, newAcctNumber, newuserName, newpassword, newdepositing, newcollectedDate, newplaceOfBirth, newstateOfOrigin, newlga, newnextofkin);
                    users.Add(newUser);
                    Console.WriteLine("Your registration was successful!");
                    Console.WriteLine("You now have {0:C} in your account.", newdepositing);
                    Console.WriteLine();
                    Console.WriteLine("Please take note of your information...");
                    Console.WriteLine();
                    Console.WriteLine("FullName: " +newfullName+ "\nUserName " +inputuserName+"\nPassword " +newpassword);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to proceed to your Main Menu.");
                    Console.ReadKey();

                    on = true;
                    
                }
                //in case user tries to break the application  
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Error 378 (Wrong Command)");
                    Console.WriteLine();
                    Console.Write("Press any key to reset... ");
                    Console.ReadKey();

                    on = true;
                }
            }

        }

    }

    
}
