using View;
using Model;
using FormView.Output;
using System.Threading;
using FormView.Objects;
using View.Objects.Enum;
using FormView.Objects.Factories;

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
                FormViewGameObjectsFactory viewFactory = new FormViewGameObjectsFactory();

                FormViewPipe viewPipe = (FormViewPipe)viewFactory.CreateView(ViewType.PIPE, null);
                FormViewBird viewBird = (FormViewBird)viewFactory.CreateView(ViewType.BIRD, modelGame.Bird);
                FormViewWall viewWall = (FormViewWall)viewFactory.CreateView(ViewType.WALL, null);

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
