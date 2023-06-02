using View;
using Model;
using System.Threading;
using ConsoleView.Output;
using ConsoleView.Objects;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление игры
    /// </summary>
    public class ConsoleViewGame : ViewGame
    {
        //Поля
        /// <summary>
        /// Такт обновления игры
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления игры
        /// </summary>
        public ConsoleViewGame(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной игры
        /// </summary>
        public override void Show()
        {
            if(model is ModelGame modelGame)
            {
                ConsoleViewPipe viewPipe = new ConsoleViewPipe(null);
                ConsoleViewBird viewBird = new ConsoleViewBird(modelGame.Bird);
                ConsoleViewWall viewWall = new ConsoleViewWall(null); 

                ConsoleViewGameScore viewScores = new ConsoleViewGameScore(modelGame.GetModelScore());

                while (isShowing)
                {
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                    ConsoleViewOutput.Clear();
                    lock (modelGame.Locker) viewWall.ShowAll(modelGame.Walls);
                    lock (modelGame.Locker) viewPipe.ShowAll(modelGame.Pipes);
                    viewBird.Show();
                    viewScores.Show();

                    ConsoleViewOutput.PrintOnConsole();
                }
            }
        }
    }
}
