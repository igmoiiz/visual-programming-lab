using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_02
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6, };

			var numQuery =
				from num in numbers
				where (num % 2) == 0
				select num;

			foreach (int num in numQuery)
			{
				Console.WriteLine("{0,1}", num);
			}


		}
	}
}
