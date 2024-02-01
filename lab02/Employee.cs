using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Employee
    {
        protected string id { get; set; }
        protected string name { get; set; }
        protected string adress { get; set; }
        protected string phone { get; set; }
        protected long sin { get; set; }
        protected string dob { get; set; }
        protected string dept { get; set; }

        public Employee() {
            this.name = "Unknown";
            this.adress = "Unknown";
            this.phone = "Unknown";
            this.dob = "Unknown";
            this.dept = "Unknown";
        }
        public Employee(string id, string name, string adress, string phone, long sin, string dob, string dept)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.phone = phone;
            this.sin = sin;
            this.dob = dob;
            this.dept = dept;
        }

        public string GetName() { return this.name; }

        public virtual double GetPay(){ return 0; }

        public override string ToString()
        {
            return $"""
                Id: {this.id}
                Name: {this.name}
                Phone: {this.phone}
                Dept: {this.dept}
                """;
        }
    }
}
