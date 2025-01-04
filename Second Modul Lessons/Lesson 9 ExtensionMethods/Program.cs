using Lesson_9_ExtensionMethods.Extensions;
namespace Lesson_9_ExtensionMethods;

internal class Program
{
    static void Main(string[] args)
    {
        //StringBuilder sb = new StringBuilder("SaLoM NiMA Gap");
        //var res = sb.CountUppercaseLetter();
        //Console.WriteLine(res);
        //var number = 20;
        //var result = number.IsEven();
        //Console.WriteLine(result);
        //var number = 7;
        //var result = number.IsPrime();
        //Console.WriteLine(result);

        var firstPerson = new Person()
        {
            FirstName = "Temur",
            LastName = "Uroqov",
            Age = 24
        };
        var secondPerson = new Person()
        {
            FirstName = "Akmal",
            LastName = "Rovshanov",
            Age = 33

        };
        var thirdPerson = new Person()
        {
            FirstName = "Jamshid",
            LastName = "Shamsiyev",
            Age = 31

        };
        var person = new List<Person>();
        var result = person.GetOldestPerson();
        Console.WriteLine(result);






    }
}
