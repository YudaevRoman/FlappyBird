using Model;
using FormController;

namespace FlappyBirdForm
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelApps model = new ModelApps(0, 0, 1000, 600, null);
            FormControllerApps apps = FormControllerApps.GetInstance(model);

            apps.Start();
        }
    }
}
