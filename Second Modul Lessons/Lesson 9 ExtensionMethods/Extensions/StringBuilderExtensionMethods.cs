using System.Text;

namespace Lesson_9_ExtensionMethods.Extensions;

public static class StringBuilderExtensionMethods
{
    public static int CountUppercaseLetter(this StringBuilder sb)
    {
        var countter = 0;
        for(var i = 0; i < sb.Length; i++)
        {
            if (char.IsUpper(sb[i]))
            {
                countter++;
            }
        }
        return countter;
    }
}
