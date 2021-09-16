using System;

namespace theBankingApp
{
    class Users
    {
        
        public string FullName {get; set;}
        private int accountNumber;
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }
        }
        public string UserName {get; set;}
        public string Password {get; set;}
        private double amount;
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                if(amount >= 1000000)
                {
                    amount = 1000000;
                }
                else if (amount < 0)
                {
                    amount = 0;
                }
                else
                {
                    amount = value;
                }
            }
        }

        public DateTime Dob {get; set;}
        public string PlaceOfBirth {get; set;}
        public string StateOfOrigin {get; set;}
        public string LGA {get; set;}
        public string NextOfKin{get; set;}

        public Users()
        {

        }
        public Users(string fullName, int AcctNumber, string userName, string password, double depositing, DateTime collectedDate, string placeOfBirth, string stateOfOrigin, string lga, string nextofkin)
        {
            FullName = fullName;
            accountNumber = AcctNumber;
            UserName = userName;
            Password = password;
            amount = depositing;
            Dob = collectedDate;
            PlaceOfBirth = placeOfBirth;
            StateOfOrigin = stateOfOrigin;
            LGA = lga;
            NextOfKin = nextofkin;
        }

        public bool Profile(string name, out bool sure, out bool terminate)
        {
            terminate = false;
            bool onProfile = true;
            sure = false;
            while(onProfile)
            {

                Console.Clear();
                Console.WriteLine("Welcome to your profile, " + name + "."+ " Acct No: " + accountNumber);
                Console.WriteLine();
                Console.WriteLine("Please type one of the options below to proceed...");
                Console.WriteLine("1) Check your balance.");
                Console.WriteLine("2) Withdraw.");
                Console.WriteLine("3) Deposit.");
                Console.WriteLine("4) Delete Account.");
                Console.WriteLine("5) SignOut");
                Console.WriteLine();
                Console.WriteLine("Or type and enter \"info\" to view your personel information. ");
                Console.Write("Answer => ");

                string input = Console.ReadLine();
                input = input.ToLower();

                if (input == "1" || input.ToLower() == "balance")
                {
                    Console.Clear();
                    Console.WriteLine("Available balence: {0:C}", amount);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to your dashboard...");
                    Console.ReadKey();
                }
                else if (input == "2" || input.ToLower() == "withdraw")
                {
                    double withdraw = 0;
                    bool offWithdraw = false;
                    while(!offWithdraw)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter the amount you would like to withdraw....");
                        Console.WriteLine();
                        Console.Write("Amount => ");
                        string receive = Console.ReadLine();
                        bool received = double.TryParse(receive, out withdraw);

                        double checkedD = amount - withdraw;
                        
                        if (checkedD <= 100)
                        {
                            offWithdraw = true;
                            Console.Clear();
                            Console.WriteLine("Sorry, temporarily unable to depense cash, minimum account balance requirement ({0:C}).", 100);
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else if(received && withdraw >= 100 && checkedD >= 500)
                        {
                            
                            offWithdraw = true;
                            amount -= withdraw;
                            Console.Clear();
                            Console.WriteLine("Transation was successfull.");
                            Console.WriteLine();
                            Console.WriteLine("Avaliable Balance is now... {0:C} ", amount);
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else if(withdraw < 100 && received )
                        {
                            offWithdraw = true;
                            Console.Clear();
                            Console.WriteLine("Sorry, the amount is below minimum withdrawal requirement ({0:C}).", 100);
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error 378 (Wrong Command)");
                            Console.WriteLine();
                            Console.Write("Press any key to reset... ");
                            Console.ReadKey();
                            offWithdraw = false;
                        }
                    }
                }
                else if (input == "3" || input.ToLower() == "deposit")
                {
                    double deposit = 0;
                    bool offDeposit = false;
                    while(!offDeposit)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter the amount you would like to deposit....");
                        Console.WriteLine();
                        Console.Write("Amount => ");
                        string receive = Console.ReadLine();
                        bool received = double.TryParse(receive, out deposit);

                        double checkedD = amount + deposit;
                        
                        if (checkedD >= 1000000)
                        {
                            offDeposit = true;
                            Console.Clear();
                            Console.WriteLine("Sorry, You have reaced your maximum deposit limit.");
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else if(received && deposit >= 100)
                        {
                            
                            offDeposit = true;
                            amount += deposit;
                            Console.Clear();
                            Console.WriteLine("Transation was successfull.");
                            Console.WriteLine();
                            Console.WriteLine("Avaliable Balance is now... {0:C} ", amount);
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else if(deposit < 100 && received )
                        {
                            offDeposit = true;
                            Console.Clear();
                            Console.WriteLine("Sorry, your deposit is below minimum deposit requirement ({0:C}).", 100);
                            Console.WriteLine();
                            Console.Write("Press any key to go back to your dashboard...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error 378 (Wrong Command)");
                            Console.WriteLine();
                            Console.Write("Press any key to reset... ");
                            Console.ReadKey();
                            offDeposit = false;
                        }
                    }

                }
                else if (input == "4" || input.ToLower() == "delete")
                {
                    bool loop = false;
                    while(!loop)
                    {
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to delete your account...? e.g type (Yes/No) ");
                        Console.Write("Answer => ");
                        string command = Console.ReadLine();

                        if (command.ToLower() == "yes")
                        {
                            Console.Clear();
                            Console.WriteLine("Your account has been deleted successfully.");
                            Console.WriteLine();
                            Console.Write("Press any key to exit...");
                            Console.ReadKey();
                            terminate = true;
                            loop = true;
                            sure = true;
                        }
                        else if (command.ToLower() == "no")
                        {
                            Console.Clear();
                            Console.WriteLine("Your account was not deleted... ");
                            Console.WriteLine();
                            Console.Write("Press any key to procceed...");
                            Console.ReadKey();
                            terminate = false;
                            onProfile = true;
                            loop = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("i do not understand what you mean by " +command+ ", E.g type \"Yes\" or \"No\" to proceed.");
                            Console.WriteLine();
                            Console.Write("Press any key to go back...");
                            Console.ReadKey();
                            loop = false; 
                        }
                    }
                }
                else if (input == "5" || input.ToLower() == "signout")
                {
                    onProfile = false;
                    terminate = true;
                    break;
                }
                else if (input.ToLower() == "info")
                {
                    Console.Clear();
                    Console.WriteLine("Account Details.");
                    Console.WriteLine();
                    Console.WriteLine("FullName: "+ FullName +". \n\nAccount Number: "+ accountNumber +"\n\nBalance: {0:C} \n\nDate Of Birth: "
                    +Dob.ToLongDateString() +". \n\nPlace Of Birth: "+PlaceOfBirth 
                    +". \n\nState Of Origin: "+StateOfOrigin +". \n\nLocal Goverment Area: "+LGA +". \n\nNext Of Kin: "
                    +NextOfKin+".", amount);

                    Console.WriteLine();
                    Console.Write("Press any key to return back to the Main Menu... ");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, That's not a part of my program.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to back to your dashboard...");
                    Console.ReadKey();
                }

                if(sure)
                {
                    break;
                }

            }

            return terminate;


        }

    }
}