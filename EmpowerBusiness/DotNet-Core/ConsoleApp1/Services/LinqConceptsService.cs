using ConsoleApp1.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Services
{
    public class LinqConceptsService : ILinqConcepts
    {
        //The topics covered are
        //LINQ
        //Lambda expression
        //Filter
        //Sorting
        //First() and FirstOrDefault()
        //Last and LastOrDefault()
        //Aggregate function
        //Zip function
        //Any()
        //All()
        //skip and take in Linq


        public void LinqConceptApp()
        {
            
            //distinct numbers from list using LINQ
            var lstNumbers =new List<int>() { 1, 2, 2, 4,5,6,6};
            var disctinctNum = lstNumbers.Distinct().ToList();

            //filtering
            var lstNum = new List<int>() { 1,2, 3, 4, 5,6,7};
            var evenNum = lstNum.Where(x=> x%2==0).ToList();
            var oddNum = lstNum.Where(x=> x%2!=0).ToList();

            //sorting
            var numAsc = lstNum.OrderBy(x => x).ToList();
            var numDes = lstNum.OrderByDescending(x => x).ToList();

            //first and firstOrDefault
            var lstEmpty = new List<int> { };
            var First=lstNum.First();
            //var firstEmpty = lstEmpty.First();
            var firstEmpty = lstEmpty.LastOrDefault();


            //Any()
            var FirstList = new List<int>(){1,2,3,4,5,6,7,8,9 };
            var SecondList = new List<int>() { 3,5,7};

            var checkEven = FirstList.Any(x => x%2==0);
            var checkEven1 = SecondList.Any(y => y%2==0);
            var checkOdd = SecondList.All(y => y % 2 != 0);

            //Skip and Take

            var firstThree= FirstList.Take(3);
            var SkipfirstTwo = FirstList.Skip(2);
            //zip
            var numbers = new List<int>() { 1,2,3,4,5,6,7};
            var letters = new List<char>() { 'A','B','C'};
            var results = numbers.Zip(letters,(num,letter)=>$"{num}--{letter}");

            //aggregate
            // var sumall =numbers.Sum(x=>x);            
            //var numbersList = new List<int>() { 1, 2, 3, 4, 5, 6};
            //var sumAll = numbersList.Aggregate(accum,num )=> accum + num);

            //select many 

            var Order = new List<Order>()
            {
                new Order(){ Id=1,Product = new List<string>{"Product1","Product2"} },
                new Order(){ Id=2,Product = new List<string>{"","" } }
            };

            var ALLProdcut = Order.SelectMany(order => order.Product);

        }


        public class Order
        {
            public int Id { get; set; }

            public List<string> Product { get; set; }
        }


    }
}
