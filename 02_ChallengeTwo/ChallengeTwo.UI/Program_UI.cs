using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly Outing_Repository _outings = new Outing_Repository();
        private readonly Outing_Repository _golf = new Outing_Repository();
        private readonly Outing_Repository _park = new Outing_Repository();
        private readonly Outing_Repository _bowling = new Outing_Repository();
        private readonly Outing_Repository _concert = new Outing_Repository();
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
                System.Console.WriteLine("=== Komodo Company Outings ===");
                System.Console.WriteLine("Make a selection \n" +
                "1. View All Outings\n"+
                "2. Add a New Outing \n"+
                "3. View Total Outing Costs\n"+
                "0. Exit Application"
                );

                var userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                    ViewAllOutings();
                    break;

                    case "2":
                    AddOuting();
                    break;

                    case "3":
                    GetTotalCost();
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
        private void ViewAllOutings()
        {
            Console.Clear();
            System.Console.WriteLine("=== All Outings ===");
            var outings = _outings.GetOuting();

            foreach(Outing outing in outings)
            {
                DisplayOutingDetails(outing);
            }

            PressAnyKeyToContinue();
        }

        private void DisplayOutingDetails(Outing outing)
        {
            System.Console.WriteLine($"Type: {outing.OutingType} \n"+
            $"Date: {outing.Date} \n"+
            $"Attendance: {outing.Attendance} \n"+
            $"Cost Per Person: {outing.CostPerPerson} \n"+
            $"Total Cost: {outing.TotalCost} \n"
            );
        }

        private void AddOuting()
        {
            Console.Clear();
            var newOuting = new Outing();
            System.Console.WriteLine("What type of outing would you like to add? Make a selection: \n" +
            "1. Golf \n"+
            "2. Park \n"+
            "3. Bowling \n"+
            "4. Concert \n"
            );

            var userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                newOuting.OutingType = OutingType.Golf;
                break;

                case "2":
                newOuting.OutingType = OutingType.Park;
                break;

                case "3":
                newOuting.OutingType = OutingType.Bowling;
                break;

                case "4":
                newOuting.OutingType = OutingType.Concert;
                break;
            }

            System.Console.WriteLine("What is the outing's date?");
            newOuting.Date = Console.ReadLine();

            System.Console.WriteLine("How many people attended?");
            newOuting.Attendance = int.Parse(Console.ReadLine());

            System.Console.WriteLine("What was the cost per person?");
            newOuting.CostPerPerson = double.Parse(Console.ReadLine());

            newOuting.TotalCost = newOuting.CostPerPerson * newOuting.Attendance;

            bool success = _outings.AddOutingToDB(newOuting);

            System.Console.WriteLine("Outing has been added.");

            PressAnyKeyToContinue();
        }

        private bool CloseApplication()
        {
            Console.Clear();
            return false;
        }

        private void GetTotalCost()
        {
            double TotalOutingCost = 0;
            var outings = _outings.GetOuting();
            System.Console.WriteLine("=== Total Outing Costs ===");
            foreach(Outing outing in outings)
            {
                TotalOutingCost = TotalOutingCost + outing.TotalCost;
            }

            System.Console.WriteLine($"{TotalOutingCost}");
            
            System.Console.WriteLine("=== Total Outing Costs By Type ===");

            foreach(Outing outing in outings)
            {
                switch(outing.OutingType)
                {
                    case OutingType.Golf:
                    _golf.AddOutingToDB(outing);
                    break;

                    case OutingType.Park:
                    _park.AddOutingToDB(outing);
                    break;

                    case OutingType.Bowling:
                    _bowling.AddOutingToDB(outing);
                    break;

                    case OutingType.Concert:
                    _concert.AddOutingToDB(outing);
                    break;
                }
            }

            double TotalGolfCost = 0;
            var golfOutings = _golf.GetOuting();
            
            foreach(Outing outing in golfOutings)
            {
                TotalGolfCost = TotalGolfCost + outing.TotalCost;
            } 
            
            double TotalParkCost = 0;
            var parkOutings = _park.GetOuting();
            
            foreach(Outing outing in parkOutings)
            {
                TotalParkCost = TotalParkCost + outing.TotalCost;
            } 

            double TotalBowlingCost = 0;
            var bowlingOutings = _bowling.GetOuting();
            
            foreach(Outing outing in bowlingOutings)
            {
                TotalBowlingCost = TotalBowlingCost + outing.TotalCost;
            } 

            double TotalConcertCost = 0;
            var concertOutings = _concert.GetOuting();
            
            foreach(Outing outing in concertOutings)
            {
                TotalConcertCost = TotalConcertCost + outing.TotalCost;
            } 

            System.Console.WriteLine($"Golf: {TotalGolfCost} \n"+
            $"Park: {TotalParkCost} \n"+
            $"Bowling: {TotalBowlingCost} \n"+
            $"Concert: {TotalConcertCost} \n"
            );

            PressAnyKeyToContinue();
        }

        private void SeedData()
        {
            var outing1 = new Outing(OutingType.Golf, 4, "January 1st", 6.99, 4*6.99);
            var outing2 = new Outing(OutingType.Park, 10, "February 3rd", 10, 10*10);
            var outing3 = new Outing(OutingType.Park, 50, "February 16th", 5, 50*5);
            var outing4 = new Outing(OutingType.Bowling, 6, "August 8th", 10, 10*6);
            var outing5 = new Outing(OutingType.Concert, 64, "September 10th", 50, 64*50);

            _outings.AddOutingToDB(outing1);
            _outings.AddOutingToDB(outing2);
            _outings.AddOutingToDB(outing3);
            _outings.AddOutingToDB(outing4);
            _outings.AddOutingToDB(outing5);

        }

        private void PressAnyKeyToContinue()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
            
              
    
            
        

    