using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class PartTime: Employee
    {
        private double rate { get; set; }
        private double hours { get; set; }

        public PartTime() : base() { }

        public PartTime(string id, string name, string adress, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, adress, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetPay() { return this.rate * this.hours; }

        public override string ToString()
        {
            return $"""
                Id: {this.id}
                Name: {this.name}
                Phone: {this.phone}
                Dept: {this.dept}
                Type: PartTime
                Rate: {this.rate}
                Hours Worked: {this.hours}
                Salary: {String.Format("{0:0.##}", GetPay())}
                """;
        }
    }
}
