
using MathCollection;
namespace Helper;

internal class Utility
{
    public static void LineBuilder(int length,char c) {
        for (int i = 0;i<length;i++)
        Console.WriteLine( c );
    }
    /*public static Vector2 ParseVector2FromString(string input)
    {
        // Remove parentheses and split the string by the comma
        input = input.Replace("(", "").Replace(")", "");
        string[] components = input.Split(',');

        if (components.Length == 2)
        {
            float x, y;

            if (float.TryParse(components[0], out x) && float.TryParse(components[1], out y))
            {
                return new Vector2(x, y);
            }
            else
            {
                Console.WriteLine( "Failed to parse components as floats.");
            }
        }
        else
        {
            Console.WriteLine("Input string does not have two components.");
        }

        // Return a default Vector2 if parsing fails
        return Vector2.Zero();
    }*/

}



