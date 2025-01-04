namespace Lesson_9_ExtensionMethods.Extensions;

public static class IntVariableExtensionMethods
{
    public static bool IsEven(this int value)
    {
        if (value % 2 == 0)
        {
            return true;
        }

        return false;
    }
    public static bool IsPrime(this int value)
    {
        var countter = 0;
        for (var i = 1; i <= value; i++)
        {
            if (value % i == 0)
            {
                countter++;
            }
        }
        return countter == 2;
    }
}
