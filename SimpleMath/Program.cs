using System.Threading;

namespace SimpleMaths
{
    class Program
    {
        private const int TargetFrameRate = 30;
        private static Timer timer;

        static void Main(string[] args)
        {
           int frameInterval = 1000 / TargetFrameRate;
            // Create a Timer with an interval to achieve the desired frame rate
            timer = new Timer(GameLoop, null, 0, frameInterval);

            Console.ReadLine();
            // Clean up and stop the timer when your application exits
            timer.Dispose();

        }

        private static void GameLoop(object state)
        {
            EntryPoint.Run();
        }
    }
}