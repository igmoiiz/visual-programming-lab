using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12___Console_Application_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StudentClass sc = new StudentClass();
			sc.QueryHighScores(1, 90);

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

		public class StudentClass
		{
			protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };

			protected class Student
			{
				public string FirstName { get; set; }
				public string LastName { get; set; }
				public int ID { get; set; }
				public GradeLevel Year { get; set; }
				public List<int> ExamScores { get; set; }
			}

			protected static List<Student> students = new List<Student>
			{
				new Student { FirstName = "Mahad", LastName = "Ghauri", ID = 523, Year = GradeLevel.SecondYear, ExamScores = new List<int> { 99, 82, 81, 79 } },
				new Student { FirstName = "Alice", LastName = "Smith", ID = 524, Year = GradeLevel.FirstYear, ExamScores = new List<int> { 88, 90, 92, 85 } },
				new Student { FirstName = "Bob", LastName = "Johnson", ID = 525, Year = GradeLevel.ThirdYear, ExamScores = new List<int> { 75, 80, 78, 82 } },
				new Student { FirstName = "Charlie", LastName = "Brown", ID = 526, Year = GradeLevel.FourthYear, ExamScores = new List<int> { 95, 94, 96, 97 } },
				new Student { FirstName = "David", LastName = "Williams", ID = 527, Year = GradeLevel.SecondYear, ExamScores = new List<int> { 70, 72, 68, 75 } },
				new Student { FirstName = "Eva", LastName = "Davis", ID = 528, Year = GradeLevel.FirstYear, ExamScores = new List<int> { 85, 87, 89, 90 } },
				new Student { FirstName = "Frank", LastName = "Miller", ID = 529, Year = GradeLevel.ThirdYear, ExamScores = new List<int> { 80, 82, 84, 86 } },
				new Student { FirstName = "Grace", LastName = "Wilson", ID = 530, Year = GradeLevel.FourthYear, ExamScores = new List<int> { 91, 92, 93, 94 } },
				new Student { FirstName = "Henry", LastName = "Moore", ID = 531, Year = GradeLevel.SecondYear, ExamScores = new List<int> { 78, 76, 80, 82 } },
				new Student { FirstName = "Isabella", LastName = "Taylor", ID = 532, Year = GradeLevel.FirstYear, ExamScores = new List<int> { 88, 89, 90, 91 } },
				new Student { FirstName = "Jack", LastName = "Anderson", ID = 533, Year = GradeLevel.ThirdYear, ExamScores = new List<int> { 85, 87, 89, 90 } }
			};

			protected static int GetPerecentile(Student s)
			{
				double avg = s.ExamScores.Average();
				return avg > 0 ? (int)avg / 10 : 0;
			}

			public void QueryHighScores(int exams, int score)
			{
				var highScores = from student in students
								 where student.ExamScores[exams] > score
								 select new { Name = student.FirstName, Score = student.ExamScores[exams] };

				foreach (var item in highScores)
				{
					Console.WriteLine( "{0, -10}{1}" , item.Name, item.Score);
				}
			}
		}
	}
}