
using Helper;
using MathCollection;

namespace GravitySimulation;

class Program
{
    static void Main()
    {
        int screenWidth = 40;
        int screenHeight = 15;

        Vector2 objectPosition = new Vector2(screenWidth / 2, 1);
        Vector2 objectVelocity = new Vector2(0, 0); // Initial velocity
        Console.Read();
        while (true)
        {
            Console.Clear();
            // Simulate gravity
            if (objectPosition.y < screenHeight - 1)
            {
                objectVelocity.y += 0.2f; 
            }
            else
            {
                objectVelocity.y *= -0.8f;
            }

            objectPosition += objectVelocity;

            objectPosition.x = Math.Max(0, Math.Min(objectPosition.x, screenWidth - 1));
            objectPosition.y = Math.Max(0, Math.Min(objectPosition.y, screenHeight - 1));

            // Render the object and the screen
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    if (x == (int)objectPosition.x && y == (int)objectPosition.y)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Thread.Sleep(5); // 100 milliseconds
        }
    }
}
