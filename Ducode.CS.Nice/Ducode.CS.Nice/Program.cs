using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducode.CS.Nice
{
    class Program
    {
        static void Main(string[] args)
        {
			//Set
			Person person = new Person().Set(p =>
			{
				p.FirstName = "John";
				p.LastName = "Doe";
				p.Address = "Groningen, Netherlands";
				p.DateOfBirth = new DateTime(1993, 3, 29);
			});
			Console.WriteLine(person);

			//WhereIf
			var items = new List<string>() { "aa", "ab", "ba", "bb" };
			var subItems = items.WhereIf(false, i => i.StartsWith("a")).ToList();

			//Random
			var numbers = Enumerable.Range(0, 100);
			var number = numbers.Random();
			var randomSelection = numbers.RandomSelection(10).ToList();

			//Age
			Console.WriteLine(person.DateOfBirth.GetAge());

			//Parse enum
			Console.WriteLine("Monday".ParseEnum<DayOfWeek>());

			//Enumerable null or empty
			Console.WriteLine(new List<string>() { "Duco" }.IsNullOrEmpty());

			//Join
			Console.WriteLine(randomSelection.Join(", "));

			Console.ReadKey();
		}
    }
}
