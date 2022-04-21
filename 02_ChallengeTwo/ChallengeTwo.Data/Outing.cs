using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Outing : IOutingType
    {
        public Outing(){}

        public Outing(OutingType outingtype, int attendance, string date, double costPerPerson, double totalCost)
        {
            OutingType = outingtype;
            Attendance = attendance;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }

        public OutingType OutingType{get; set;}
        public int Attendance{get;set;}
        public string Date{get; set;}
        public double CostPerPerson{get;set;}
        public double TotalCost{get;set;}

    }