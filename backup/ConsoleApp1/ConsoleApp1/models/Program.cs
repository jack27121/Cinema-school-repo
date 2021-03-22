using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mandag
{
	class Program
	{
		static void Main(string[] args)
		{
			#region data
			Student[] students =
		{
				new Student { name = "Bo",
					subjectList = new List<Subject>()
					{
						new Subject(){subjectName="SQL", subjectMark=71},
						new Subject(){subjectName="DB", subjectMark=82},
						new Subject(){subjectName="C#", subjectMark=93},
						new Subject(){subjectName="Test", subjectMark=95},
					}
				},
				new Student { name = "Ib",
					subjectList = new List<Subject>()
					{
						new Subject(){subjectName="SQL", subjectMark=75},
						new Subject(){subjectName="DB", subjectMark=77},
						new Subject(){subjectName="C#", subjectMark=65},
						new Subject(){subjectName="Test", subjectMark=67},
					}
				},

				new Student { name = "Hans",
					subjectList = new List<Subject>()
					{
						new Subject(){subjectName="SQL", subjectMark=71},
						new Subject(){subjectName="DB", subjectMark=80},
						new Subject(){subjectName="C#", subjectMark=45},
						new Subject(){subjectName="Test", subjectMark=55},
					}
				},

				new Student { name = "Knud",
					subjectList = new List<Subject>()
					{
						new Subject(){subjectName="SQL", subjectMark=90},
						new Subject(){subjectName="DB", subjectMark=98},
						new Subject(){subjectName="C#", subjectMark=93},
						new Subject(){subjectName="Test", subjectMark=95},
					}
				},
				new Student { name = "Bo",
					subjectList = new List<Subject>()
					{
						new Subject(){subjectName="SQL", subjectMark=71},
						new Subject(){subjectName="DB", subjectMark=82},
						new Subject(){subjectName="C#", subjectMark=88},
						new Subject(){subjectName="Test", subjectMark=65},
					}
				},
			};

			List<Student> studentList = new List<Student>{
								 new Student {id = 1,name="Jan", age= 60},
								 new Student {id = 2,name="Bo", age= 65},
								 new Student {id = 3,name="Palle", age= 45},
								 new Student {id = 1,name="Jan", age= 60},
								 new Student {id = 3,name="Palle", age= 45},
			};
			// Note til migselv hvad er forskellen på at deklærer ovenstående med og uden ()



			// string data
			List<string> stringList = new List<string>() { "Bo", "Ib", "Skallesmækker", "The Banished Evil" };
			#endregion data

			#region LINQ start
			//gets students whose id 2
			List<Student> studentQuery1 = studentList.Where(studentObj => studentObj.id == 2).ToList();

			//gets students whose name is Jan
			List<Student> studentQuery2 = studentList.Where(studentObj => studentObj.name == "Jan").ToList();

			//gets students whose age is even numbers
			List<Student> studentQuery3 = studentList.Where(studentObj => (studentObj.age % 2) == 0).ToList();

			//gets students whose id 2, and name is Bo
			List<Student> studentQuery4 = studentList.Where(studentObj => (studentObj.id == 2 && studentObj.name == "Bo")).ToList();

			//gets students whose age is over 50, and name isn't Bo
			List<Student> studentQuery5 = studentList.Where(studentObj => (studentObj.age > 50 && studentObj.name != "Bo")).ToList();

			Console.WriteLine("gets students whose id is 2");
			listWriteLine(studentQuery1);
			Console.WriteLine();

			Console.WriteLine("gets students whose name is Jan");
			listWriteLine(studentQuery2);
			Console.WriteLine();

			Console.WriteLine("gets students whose age is even numbers");
			listWriteLine(studentQuery3);
			Console.WriteLine();

			Console.WriteLine("gets students whose id 2, and name is Bo");
			listWriteLine(studentQuery4);
			Console.WriteLine();

			Console.WriteLine("gets students whose age is over 50, and name isn't Bo");
			listWriteLine(studentQuery5);
			Console.WriteLine();

			Console.ReadKey();

			void listWriteLine(List<Student> list)
			{
				foreach (Student student in list)
				{
					Console.Write("{0} {1} {2},", student.id, student.name, student.age);
					Console.WriteLine();
				}
			}
			#endregion

			#region tirsdag
			List<Student> studentsList = new List<Student>()
			{
				new Student(){ id=1, name="S1", addressId=1},
				new Student(){ id=2, name="S2", addressId=2},
				new Student(){ id=3, name="S3", addressId=1},
				new Student(){ id=4, name="S4", addressId=3},
				new Student(){ id=5, name="S5", addressId=0},
			};
			List<Address> addressList = new List<Address>()
			{
				new Address(){ id=1, address="lækker vej 1"},
				new Address(){ id=2, address="lækker vej 2"},
				new Address(){ id=3, address="lækker vej 3"},
				new Address(){ id=4, address="lækker vej 4"},
			};
			List<Marks> marksList = new List<Marks>()
			{
				new Marks(){ id=1, studentId=1,grade=70},
				new Marks(){ id=2, studentId=5,grade=77},
				new Marks(){ id=3, studentId=4,grade=88},
			};

			//select LINQ
			var studentQuery6 = from student in studentList
							   where student.name == "Palle"
							   select student;

			var studentQuery7 = from student in studentList
							   where student.name == "Bo"
							   select new Student
							   {
								   name = student.name,
								   age = student.age
							   };
			var studentMethod = studentList.Where((student) => student.name == "bo")
				.Select(x => x.name);

			#endregion

			#region data3
			var join4 = (from s in studentsList
						 join a in addressList
						 on s.addressId equals a.id
						 where a.address == a.address
						 select new
						 {
							 studentName = s.name,
							 adr = a.address
						 }).GroupBy(x => x.adr)
						 .ToList();
			#endregion
		}
	}
}
