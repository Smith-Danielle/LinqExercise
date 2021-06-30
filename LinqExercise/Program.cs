using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum of List: {sum}");

            var average = numbers.Average();
            Console.WriteLine($"Average of List: {average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascend = numbers.OrderBy(num => num);
            var descend = numbers.OrderByDescending(num => num);
            Console.WriteLine("Ascending Order:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in ascend)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            Console.WriteLine("Descending Order:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in descend)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");

            //Print to the console only the numbers greater than 6
            var six = numbers.Where(num => num > 6);
            Console.WriteLine("Greater than 6:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in six)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var ascend4 = numbers.OrderBy(num => num).Take(4);
            Console.WriteLine("Top 4 Ascending:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in ascend4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 29;
            Console.WriteLine("My Age at index 4:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            var age4 = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending Order With My Age:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in age4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
 
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var firstCorS = employees.Where(name => name.FirstName[0] == 'C' || name.FirstName[0] == 'S');
            Console.WriteLine("Employee First Names Starting with C and S (Fullname Printed):");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in firstCorS)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("------------------");

            //Order this in acesnding order by FirstName.
            var firstCorSORder = firstCorS.OrderBy(name => name.FirstName);
            Console.WriteLine("Employee First Names Starting with C and S Ordered (Fullname Printed):");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in firstCorSORder)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("------------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);
            Console.WriteLine("Employees Over 26 (Fullname & Age Printed):");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in over26)
            {
                Console.WriteLine($"Name:{item.FullName} | Age: {item.Age}");
            }
            Console.WriteLine("------------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var emp = employees.Where(num => num.YearsOfExperience <= 10 && num.Age > 35);
            Console.WriteLine("Sum & Average Years Experience (if YOE <= 10 & Age > 35:");
            Console.WriteLine("- - - - - - - - - ");
            Console.WriteLine($"Sum: {emp.Sum(num => num.YearsOfExperience)}");
            Console.WriteLine($"Average: {emp.Average(num => num.YearsOfExperience)}");
            Console.WriteLine("------------------");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Don", "Young", 41, 2)).ToList();
            Console.WriteLine("List With New Employee:");
            Console.WriteLine("- - - - - - - - - ");
            foreach (var item in employees)
            {
                Console.WriteLine($"Name: {item.FullName} | Age: {item.Age} | YOE: {item.YearsOfExperience}");
            }
            Console.WriteLine("------------------");



            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
