using System.IO;
using System.Runtime.CompilerServices;

namespace lab02
{
    internal class Program
    {
        public static List<Employee> EmployeeListFromFile(string path) {
            List<Employee> Employees = new List<Employee>();
            string[] EmployeeLines = File.ReadAllLines(path);
            foreach (string line in EmployeeLines)
            {
                double LastProperty;
                double PenultimateProperty;
                string[] Properties = line.Split(':');
                long sin;
                double hours;
                double rate;
                Double.TryParse(Properties[Properties.Length - 1], out hours); /* For Wage and PartTime Employees hours property will be the last in the array */
                /* If can't convert one of the last two properties to double means that type of Employee is Salaried
                 * (Because Salaried have only 1 (type Double) additional property after last common property (type String) dept)
                 */
                if (!Double​.TryParse(Properties[Properties.Length - 1], out LastProperty) || !Double​.TryParse(Properties[Properties.Length - 2], out PenultimateProperty))
                {
                    double salary;
                    long.TryParse(Properties[4], out sin);
                    Double.TryParse(Properties[7], out salary);
                    hours = 0; /* hours isn't used for Salaried Employees */

                    Employees.Add(new Salaried(id: Properties[0], name: Properties[1], adress: Properties[2], phone: Properties[3], sin: sin, dob: Properties[5], dept: Properties[6], salary: salary));
                }
                /* Otherwise is either Waged or PartTime. If hours worked > 40 Wage is assumed */
                else if (hours > 40)
                {
                    long.TryParse(Properties[4], out sin);
                    Double.TryParse(Properties[7], out rate);

                    Employees.Add(new Wages(id: Properties[0], name: Properties[1], adress: Properties[2], phone: Properties[3], sin: sin, dob: Properties[5], dept: Properties[6], rate: rate, hours: hours));
                }
                else
                {
                    long.TryParse(Properties[4], out sin);
                    Double.TryParse(Properties[7], out rate);

                    Employees.Add(new PartTime(id: Properties[0], name: Properties[1], adress: Properties[2], phone: Properties[3], sin: sin, dob: Properties[5], dept: Properties[6], rate: rate, hours: hours));
                }
            }

            return Employees;
        }

        public static double GetAverageWeeklyPay(List<Employee> Employees) {
            double AvgPay = 0;

            foreach (Employee e in Employees) {
                AvgPay += e.GetPay();
            }

            AvgPay = AvgPay / Employees.Count;

            return AvgPay;
        }

        public static string[] GetHighestPaidEmployee(List<Employee> Employees) {
            double HighestPay = Employees.First().GetPay();
            string[] HighestPayStr = new string[2];

            foreach (Employee e in Employees)
            {
                if (e.GetPay() > HighestPay)
                {
                    HighestPay = e.GetPay();
                    HighestPayStr[0] = e.GetName();
                    HighestPayStr[1] = String.Format("{0:0.##}", e.GetPay());
                }
            }

            return HighestPayStr;
        }

        public static string[] GetLowestPaidEmployee(List<Employee> Employees)
        {
            double LowestPay = Employees.First().GetPay();
            string[] LowestPayStr = new string[2];

            foreach (Employee e in Employees)
            {
                if (e.GetPay() < LowestPay)
                {
                    LowestPay = e.GetPay();
                    LowestPayStr[0] = e.GetName();
                    LowestPayStr[1] = String.Format("{0:0.##}", e.GetPay());
                }
            }

            return LowestPayStr;
        }

        public static string[] GetEmployeeCategoriesPercentage(List<Employee> Employees) {
            string[] EmpCategoryPctgs = new string[3];
            double SalariedPct = 0;
            double WagedPct = 0;
            double PartTimePct = 0;

            foreach(Employee e in Employees)
            {
                if (e is Salaried) { SalariedPct++; }
                else if (e is Wages) { WagedPct++; }
                else if (e is PartTime) { PartTimePct++; }
            }

            SalariedPct = (SalariedPct / Employees.Count)*100;
            WagedPct = (WagedPct / Employees.Count)*100;
            PartTimePct = (PartTimePct / Employees.Count)*100;

            EmpCategoryPctgs[0] = String.Format("{0:0.##}", SalariedPct);
            EmpCategoryPctgs[1] = String.Format("{0:0.##}", WagedPct);
            EmpCategoryPctgs[2] = String.Format("{0:0.##}", PartTimePct);

            return EmpCategoryPctgs;
        }

        static void Main(string[] args)
        {
            /* Get location of .txt file without using absolute path:
               -gets the current directory, removes whatever is beyond ...\lab02\
               -takes it from there to find \lab02\res\employees.txt
                (works if u have ur "res" folder in the same directory as Program.cs, Employee.cs and the other classes)
             */
            List<string> DirectoryParts = Directory.GetCurrentDirectory().Split(@"\").ToList();
            int Lab02Index = DirectoryParts.FindLastIndex(x => x == "lab02"); // or whatever u called ur Solution/Project
            DirectoryParts.RemoveAll(x => DirectoryParts.IndexOf(x) > Lab02Index);
            string path = "";
            foreach (string pathPart in DirectoryParts) {
                path += $@"{pathPart}\";
            }
            path += @"res\employees.txt";

            List<Employee> Employees = EmployeeListFromFile(path);
            string[] HighestPayed = GetHighestPaidEmployee(Employees);
            string[] LowestPayed = GetLowestPaidEmployee(Employees);
            string[] EmployeesCategoriesPercentage = GetEmployeeCategoriesPercentage(Employees);

            Console.WriteLine($"Average Weekly Pay of Employees: {String.Format("{0:0.##}", GetAverageWeeklyPay(Employees))}\n");
            Console.WriteLine($"Highest payed employee is {HighestPayed[0]} with a weekly salary of {HighestPayed[1]}\n");
            Console.WriteLine($"Lowest payed employee is {LowestPayed[0]} with a weekly salary of {LowestPayed[1]}\n");
            Console.WriteLine($"Percentage of Salaried employees: {EmployeesCategoriesPercentage[0]}%");
            Console.WriteLine($"Percentage of Waged employees: {EmployeesCategoriesPercentage[1]}%");
            Console.WriteLine($"Percentage of Part Time employees: {EmployeesCategoriesPercentage[2]}%\n");

            foreach (Employee e in Employees)
            {
                Console.WriteLine($"{e.ToString()}\n");
            }
        }
    }
}
