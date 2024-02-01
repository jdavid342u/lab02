using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Wages : Employee
    {
        protected double rate { get; set; }
        protected double hours { get; set; }

        public Wages() : base() {}

        public Wages(string id, string name, string adress, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, adress, phone, sin, dob, dept) {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetPay() {
            double pay = 0.0;
            if (this.hours <= 40)
            {
                pay = this.rate * this.hours;
            }
            else
            {
                pay = (this.rate*40) + ( 1.5*this.rate * (this.hours - 40) );
            }

            return pay;
        }

        public override string ToString()
        {
            return $"""
                Id: {this.id}
                Name: {this.name}
                Phone: {this.phone}
                Dept: {this.dept}
                Type: Waged
                Rate: {this.rate}
                Hours Worked: {this.hours}
                Salary: {String.Format("{0:0.##}", GetPay())}
                """;
        }
    }
}
