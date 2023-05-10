using Model;
using ConsoleController;

namespace FlappyBirdConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelApps model = new ModelApps(0, 0, 80, 30, null);
            ConsoleControllerApps apps = ConsoleControllerApps.GetInstance(model);

            apps.Start();
        }
    }
}
