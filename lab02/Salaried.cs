using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Salaried: Employee
    {
        protected double salary { get; set; }

        public Salaried(): base() { }

        public Salaried(string id, string name, string adress, string phone, long sin, string dob, string dept, double salary): base(id, name, adress, phone, sin, dob, dept) {
            this.salary = salary;
        }

        public override double GetPay()
        {
            return this.salary;
        }

        public override string ToString()
        {
            return $"""
                Id: {this.id}
                Name: {this.name}
                Phone: {this.phone}
                Dept: {this.dept}
                Type: Salaried
                Salary: {String.Format("{0:0.##}", GetPay())}
                """;
        }
    }
}
