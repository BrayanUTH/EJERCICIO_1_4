using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJERCICIO_1_4.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Byte[] photo { get; set; }
    }
}
