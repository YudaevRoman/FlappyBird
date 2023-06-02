using View;
using Model;
using FormView.Output;
using System.Threading;
using FormView.Objects;

namespace FormView
{
    /// <summary>
    /// Форма представления игры
    /// </summary>
    public class FormViewGame : ViewGame
    {
        //Поля
        /// <summary>
        /// Такт обновления игры
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы игры
        /// </summary>
        public FormViewGame(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы игры
        /// </summary>
        public override void Show()
        {
            if (model is ModelGame modelGame)
            {
                FormViewPipe viewPipe = new FormViewPipe(null);
                FormViewBird viewBird = new FormViewBird(modelGame.Bird);
                FormViewWall viewWall = new FormViewWall(null);

                FormViewGameScore viewScores = new FormViewGameScore(modelGame.GetModelScore());

                while (isShowing)
                {
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                    lock (modelGame.Locker) viewWall.ShowAll(modelGame.Walls);
                    lock (modelGame.Locker) viewPipe.ShowAll(modelGame.Pipes);
                    viewBird.Show();
                    viewScores.Show();

                    FormViewOutput.ShowBuf();
                }
            }
        }
    }
}
