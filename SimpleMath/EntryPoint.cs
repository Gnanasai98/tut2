using System;
using Helper;
using MathCollection;
namespace SimpleMaths
{
    internal class EntryPoint
    {
        static Vector2 position;
        static Vector2 velocity;

        static EntryPoint() {
            Console.WriteLine( "printed");
            position = new Vector2(7,0);
            velocity = new Vector2(-1,1);
        }

        public static void Run() 
        {
            EntryPoint entryPoint = new EntryPoint();
            // Check if the ball hits the window boundaries
            position = position + velocity;

            if (position.x <= 0 || position.x >= 20)
            {
                    velocity = new Vector2(-velocity.x, velocity.y);
            }
            if (position.y <= 0 || position.y >= 20)
            {   
                velocity = new Vector2(velocity.x, -velocity.y);
            }

            entryPoint.CreateMatrix(20,20, position);
        }

        private void CreateMatrix(int x,int y,Vector2 objPos)
        {
            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++) 
                {
                    if (objPos.x == i && objPos.y == j) {
                        Console.Write("  O  ");
                    }
                    else
                    Console.Write("  .  ");
                }
                Utility.LineBuilder(2, ' ');
            }
            Utility.LineBuilder(4,' ');

        }
    }
}
