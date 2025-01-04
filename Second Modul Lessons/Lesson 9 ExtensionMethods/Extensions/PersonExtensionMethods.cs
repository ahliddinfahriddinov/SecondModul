namespace Lesson_9_ExtensionMethods.Extensions;

public static class PersonExtensionMethods
{
    public static Person GetOldestPerson(this List<Person> human)
    {
        if (human == null)
        {
            throw new Exception("The people list empty");
        }
        var oldestPerson = human[0];
        foreach ( var person in human)
        {
            if(person.Age > oldestPerson.Age)
            {
                oldestPerson.Age = person.Age;
            }
        }
        return oldestPerson;
    }
}

