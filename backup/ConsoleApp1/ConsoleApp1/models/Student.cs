using System;
using System.Collections.Generic;
using System.Text;

namespace mandag
{
    class Student
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public int addressId { get; set; }

        public List<Subject> subjectList { get; set; }
    }
}
