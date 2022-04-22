using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly Customer_Repository _cRepo = new Customer_Repository();
        public void Run()
        {
            SeedData();
            RunApplication();
        }
        private void RunApplication()
        {
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("=== Customer Email ===");
            System.Console.WriteLine("Please make a selection. \n" +
            "1. View All Customers \n" +
            "2. Add a Customer \n" +
            "3. Update a Customer \n" +
            "4. Delete a Customer \n" +
            "0. Exit Application"
            );
            
            var userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                ViewAllCustomers();
                break;

                    case "2":
                    AddACustomer();
                    break;

                    case "3":
                    UpdateACustomer();
                    break;

                    case "4":
                    DeleteACustomer();
                    break;

                    case "0":
                    isRunning = CloseApplication();
                    break;

                    default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        }
        private void DeleteACustomer()
        {
            Console.Clear();
            System.Console.WriteLine("=== Delete A Customer ===");
            ShowCustomersWithID();

            System.Console.WriteLine("Enter the ID of the customer you would like to delete.");
            System.Console.WriteLine("");
            int userIDInput = int.Parse(Console.ReadLine());
            bool successfulRemoval = _cRepo.RemoveCustomer(userIDInput);

            if(successfulRemoval)
            {
                System.Console.WriteLine("Customer was deleted.");
            }
            else
            {
                System.Console.WriteLine("Customer failed to be deleted.");
            }

            PressAnyKeyToContinue();
        }
        private void ShowCustomersWithID()
        {
            Console.Clear();
            System.Console.WriteLine("=== Delete A Customer ===");
            var customers  = _cRepo.GetCustomers();

            foreach(Customers customer in customers)
            {
                System.Console.WriteLine($"ID: {customer.ID}     First Name: {customer.FirstName}     Last Name: {customer.LastName}     Type: {customer.CustomerType}");
            }
        }
        private void UpdateACustomer()
            {
                Console.Clear();
                System.Console.WriteLine("=== Update A Customer ===");
                var customers  = _cRepo.GetCustomers();

                ShowCustomersWithID();
                System.Console.WriteLine("Enter the ID of the customer you would like to update.");
                System.Console.WriteLine("");

                int userIDInput = int.Parse(Console.ReadLine());
                var selectedCustomer = _cRepo.GetCustomerByID(userIDInput);
                var newCustomer = new Customers();

                if(selectedCustomer != null)
                {
                    Console.Clear();

                    var currentCustomer = _cRepo.GetCustomers();

                    System.Console.WriteLine($"Current First Name: {selectedCustomer.FirstName}");
                    System.Console.WriteLine("Enter the customer's first name.");
                    newCustomer.FirstName = Console.ReadLine();
                    

                    System.Console.WriteLine($"Current Last Name: {selectedCustomer.LastName}");
                    System.Console.WriteLine("Enter the customer's last name.");
                    newCustomer.LastName = Console.ReadLine();

                    System.Console.WriteLine($"Current Customer Type: {selectedCustomer.CustomerType}");
                    System.Console.WriteLine("Select the type of customer. \n"+
                    "1. Potential \n"+
                    "2. Current \n"+
                    "3. Past"
                    );


                    var userInput = Console.ReadLine();
                    switch(userInput)
                    {
                        case "1":
                        newCustomer.CustomerType = CustomerType.Potential;
                        break;

                        case "2":
                        newCustomer.CustomerType = CustomerType.Current;
                        break;

                        case "3":
                        newCustomer.CustomerType = CustomerType.Past;
                        break;

                        default:
                        System.Console.WriteLine("Invalid Selection");
                        break;
                    }
                    
                    var isSuccessful = _cRepo.UpdateCustomer(selectedCustomer.ID, newCustomer);
                    if(isSuccessful)
                    {
                        System.Console.WriteLine(" Customer was updated.");
                    }
                    else
                    {
                        System.Console.WriteLine("Customer failed to be updated.");
                    }
                }
                PressAnyKeyToContinue();
            }
        private void AddACustomer()
        {
        Console.Clear();
        System.Console.WriteLine("=== Add A Customer ===");
        var newCustomer = new Customers();

        System.Console.WriteLine("Enter the customer's first name.");
        newCustomer.FirstName = Console.ReadLine();

        System.Console.WriteLine("Enter the customer's last name.");
        newCustomer.LastName = Console.ReadLine();

        System.Console.WriteLine("Select the type of customer. \n"+
        "1. Potential \n"+
        "2. Current \n"+
        "3. Past"
        );

            var userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                newCustomer.CustomerType = CustomerType.Potential;
                break;

                case "2":
                newCustomer.CustomerType = CustomerType.Current;
                break;

                case "3":
                newCustomer.CustomerType = CustomerType.Past;
                break;

                default:
                System.Console.WriteLine("Invalid Selection");
                break;
            }

            bool success = _cRepo.AddCustomer(newCustomer);
            System.Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} has been added to the database.");

            PressAnyKeyToContinue();
        
        }
        private void ViewAllCustomers()
        {
            Console.Clear();
            System.Console.WriteLine("=== All Customers ===");
            var customers  = _cRepo.GetCustomers();
            foreach(Customers customer in customers)
            {
                switch(customer.CustomerType)
                {
                    case CustomerType.Potential:
                    customer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;

                    case CustomerType.Current:
                    customer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;

                    case CustomerType.Past:
                    customer.Email = "It's been a long time since we've heard from you, we want you back.";
                    break;
                } 
                
                ShowCustomerInfo(customer);
                
            }

            PressAnyKeyToContinue();
        }
        private void ShowCustomerInfo(Customers customer)
        {
            System.Console.WriteLine($"First Name: {customer.FirstName}");
            System.Console.WriteLine($"Last Name: {customer.LastName}");
            System.Console.WriteLine($"Type: {customer.CustomerType}");
            System.Console.WriteLine($"Email: {customer.Email}");
            System.Console.WriteLine("");
        }
        private void SeedData()
        {
            var customer1 = new Customers("Alex", "Brown", CustomerType.Potential, "placeholder");
            var customer2 = new Customers("Julia", "French", CustomerType.Current, "placeholder");
            var customer3 = new Customers("Stacy", "Doe", CustomerType.Past, "placeholder");
            var customer4 = new Customers("John", "Doe", CustomerType.Potential, "placeholder");

            _cRepo.AddCustomer(customer1);
            _cRepo.AddCustomer(customer2);
            _cRepo.AddCustomer(customer3);
            _cRepo.AddCustomer(customer4);

        }
        private void PressAnyKeyToContinue()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private bool CloseApplication()
        {
            Console.Clear();
            PressAnyKeyToContinue();
            return false;
        }

}

