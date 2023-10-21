
using Helper;
using MathCollection;

namespace LineRendering
{
    internal class Test
    {
        static Vector2 player = new Vector2(5,6);
        static Vector2 enemy = new Vector2(18,18);
        static Vector2 playerDir;
        static bool isRunning;
        
        static void Main(string[] args)
        {
            isRunning = true;

            while (isRunning)
            {
                ReadInput();
                Utility.LineBuilder(1, ' ');
                calculateEnemyAI();
                for (int j = 1; j < 30; j++)
                {
                    for (int i = 1; i < 30; i++)
                    {
                        Console.Write(ScreenRendering(ref i, ref j)); ;
                    }
                    Utility.LineBuilder(1, ' ');
                }
               // Console.WriteLine("enemy :"+enemy.x+ " , " + enemy.y);
               // Console.WriteLine("player : "+player.x + " , " + player.y);
               // Console.WriteLine( "enemy to player :"+playerDir.x +" , "+ playerDir.y);
                Utility.LineBuilder(13, ' ');
            }
           
        }

        // reading inputs from the user and chaing the position if needed
        private static void ReadInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            // Check for WASD keys
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    player.y -= 1;
                    // Handle 'W' key press here
                    break;
                case ConsoleKey.A:
                    player.x -= 1;
                    // Handle 'A' key press here
                    break;
                case ConsoleKey.S:
                    player.y += 1;
                    // Handle 'S' key press here
                    break;
                case ConsoleKey.D:
                    player.x += 1;
                    // Handle 'D' key press here
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
            }
        }
        

        //screen rendering
        private static String ScreenRendering(ref int i, ref int j)
        {
            
            if (i == enemy.x && j == enemy.y) 
            {
                return " E ";
            }
            else if (i == player.x && j == player.y)
            {
                return " P ";
            }
            else
            {
                return " . ";
            }
        }

        private static void calculateEnemyAI()
        {
            playerDir = (enemy - player).Normalize();
            // Round the components
            playerDir.x = (float)Math.Round(playerDir.x);
            playerDir.y = (float)Math.Round(playerDir.y);

            enemy = enemy - playerDir;
        }
    }
}
