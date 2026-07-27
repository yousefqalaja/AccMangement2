using System.Data;

namespace AccMangement2
{
    class SmartWallet(string id, string username, string password, string address, string phoneNumber, string accountType, string signature, decimal balance, bool status)
    {
        public string id = id;
        public string username = username;
        public string password = password;
        public string address = address;
        public string phoneNumber = phoneNumber;
        public string accountType = accountType;
        public string signature = signature;
        public decimal balance = balance;
        public bool status = status;

        //1.Get the Balance
        public static void GetBalance(List<SmartWallet> smartWallets)
        {
            Console.WriteLine("Enter you ID :");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Your Password :");
            string password = Console.ReadLine();
            bool found = false;
            foreach (SmartWallet smartWallet in smartWallets)
            {
                if (smartWallet.id == id && smartWallet.password == password)
                {
                    Console.WriteLine($"Your balance is : {smartWallet.balance}");
                    found = true;
                }

            }
            if (!found)
            {
                Console.WriteLine("invalid Id Or password");
            }


        }

        //2.Withdraw
        public bool Withdraw(decimal amount)
        {
            decimal totalAmount = amount + (amount * 0.01m);
            if (totalAmount <= balance)
            {
                balance -= amount ;
                return true;
            }
            return false;
        }

        //3.Transfer
        public bool Transfer(decimal amount, SmartWallet des)
        {
            if (amount <= balance)
            {
                balance -= amount;
                des.balance += amount;
                return true;
            }
            return false;
        }

        //4.Deposit
        public bool Deposit(decimal amount, string password)
        {
            if (password == this.password)
            {
                this.balance += amount;
                return true;
            }
            return false;

        }

        //5.Forget password
        public bool ForgetPassword(string id, string newpassword)
        {
            if (id == this.id)
            {
                this.password = newpassword;
                return true;
            }
            return false;
        }

        //6.Change password
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == this.password)
            {
                this.password = newPassword;
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<SmartWallet> smartWallets = new List<SmartWallet>()
                {

                new SmartWallet ("1","yousef","123","105 aman street", "010","smartwallet", "jone doe",100, true),
                new SmartWallet ("2","sammy","1234","105 hafez street", "011","smartwallet", "mohammed",200, true)
                };

            int selection = 0;

            do
            {
                Console.WriteLine("1. Get balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Deposit");
                Console.WriteLine("5. Forget Password");
                Console.WriteLine("6. Change Password");
                Console.WriteLine("7. Exit");

                Console.WriteLine("Enter Your selection : ");
                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        {
                            SmartWallet.GetBalance(smartWallets);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Your Id :");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter Your Password :");
                            string password = Console.ReadLine();
                            bool found = false;
                            foreach (var item in smartWallets)
                            {
                                if (item.id == id && item.password == password)
                                {
                                    Console.WriteLine("Enter the amout ");
                                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                                    if (item.Withdraw(amount))
                                    {
                                        Console.WriteLine("withdraw succesful");
                                    }
                                    else
                                    {
                                        Console.WriteLine("insufficient balance");
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Invalid ID or Password");
                            }
                            {

                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter your id :");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter Your Password :");
                            string password = Console.ReadLine();

                            SmartWallet sender = null;
                            SmartWallet receiver = null;

                            foreach (var item in smartWallets)
                            {
                                if (item.id == id && item.password == password)
                                {
                                    sender = item;
                                    break;
                                }
                            }
                            if (sender == null)
                            {
                                Console.WriteLine("invalid id or password");
                                break;
                            }
                            Console.WriteLine("Enter your receiver phone number");
                            string phone = Console.ReadLine();
                            foreach (var item in smartWallets)
                            {
                                if (item.phoneNumber == phone)
                                {
                                    receiver = item;
                                    break;
                                }
                            }
                            if (receiver == null)
                            {
                                Console.WriteLine("receiver not found");
                                break;
                            }
                            Console.WriteLine($"receiver name {receiver.username} ");
                            Console.WriteLine("Enter amount");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());

                            if (sender.Transfer(amount, receiver))
                            {
                                Console.WriteLine("transfer successful");
                                Console.WriteLine($"your balance {sender.balance}");
                            }
                            else
                            {
                                Console.WriteLine("insufficient balance");
                            }
                            break;

                        }
                    case 4:
                        {
                            Console.WriteLine("Enter your ID:");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter your password:");
                            string password = Console.ReadLine();
                            bool found = false;
                            foreach (var item in smartWallets)
                            {
                                if (item.id == id)
                                {
                                    Console.Write("Enter deposit amount: ");
                                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                                    if (item.Deposit(amount, password))
                                    {
                                        Console.WriteLine("Deposit successful.");
                                        Console.WriteLine($"Your new balance is: {item.balance}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong password.");
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter your id");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter you new password");
                            string newpassword = Console.ReadLine();

                            bool found = false;

                            foreach (var item in smartWallets)
                            {

                                if (item.id == id)
                                {
                                    if (item.ForgetPassword(id, newpassword))
                                    {
                                        Console.WriteLine("Password changed successfully.");
                                        found = true;
                                        break;
                                    }

                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Invalid ID. ");
                            }


                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Enter your id");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter Your old password");
                            string oldPassword = Console.ReadLine();
                            Console.WriteLine("Enter your new password");
                            string newpassword = Console.ReadLine();
                            bool found = false;
                            foreach (var item in smartWallets)
                            {
                                if (item.id == id)
                                {
                                    if (item.ChangePassword(oldPassword, newpassword))
                                    {
                                        Console.WriteLine("Password changed successfully.");
                                        found = true;
                                        break;
                                    }
                                }

                            }
                            if (!found)
                            {
                                Console.WriteLine("Invalid . ");
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("bye");
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            } while (selection != 7);
        }
    }
}


