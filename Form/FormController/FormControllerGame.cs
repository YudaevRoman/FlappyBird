using View;
using Model;
using System;
using Controller;
using Model.Objects;
using System.Threading;
using Model.Objects.Enum;
using System.Windows.Forms;

namespace FormController
{
    /// <summary>
    /// Форма контроллер игры
    /// </summary>
    public class FormControllerGame : ControllerGame
    {
        //Поля
        /// <summary>
        /// Флаг продолжения игры
        /// </summary
        private bool isPlaying;
        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 150;
        /// <summary>
        /// Время спавна труб
        /// </summary>
        private const int FACTORY_TIMEOUT = 5000;

        //Потоки
        /// <summary>
        /// Поток работы фабрики
        /// </summary>
        private Thread factoryThread;
        /// <summary>
        /// Поток работы игры
        /// </summary>
        private Thread gameThread;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление формы контроллера игры
        /// </summary>
        public FormControllerGame(Model.Model model, View.View view) : base(model, view)
        {
            if (model is ModelGame modelGame) modelGame.GameOver += model_GameOver;
            factoryThread = new Thread(FactoryHandler);
            gameThread = new Thread(Game);
        }

        //Внешние методы
        /// <summary>
        /// Запуск формы игры
        /// </summary>
        public override void Start() 
        { 
            if (model is ModelGame && view is ViewThread)
            {
                isPlaying = true;
                ((ViewThread)view).Start();
                factoryThread.Start();
                gameThread.Start();
            } 
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyEventArgs key)
        {
            if (isPlaying)
            {
                switch (key.KeyCode)
                {
                    case Keys.W:
                    case Keys.Space:
                    case Keys.Up:
                        lock (((ModelGame)model).Locker) ((ModelGame)model).Bird.State = BirdState.FLIES;
                        break;
                    case Keys.Escape:
                        ((ViewThread)view).Stop();
                        isPlaying = false;
                        return;
                }
            }
        }

        //Внутренние методы
        /// <summary>
        /// Запуск игры
        /// </summary>
        private void Game()
        {
            while (isPlaying)
            {
                if (!((ModelGame)model).GameOverCheck())
                {
                    if (((ModelGame)model).PipeCrossing()) {
                        lock (((ModelGame)model).Locker) ((ModelGame)model).Score =
                                (Int32.Parse(((ModelGame)model).Score) + 1).ToString();
                    }
                    lock (((ModelGame)model).Locker) ((ModelGame)model).Bird.Move();
                    lock (((ModelGame)model).Locker) ((ModelGame)model).Pipes.ForEach(pipe => ((ModelPipe)pipe).Move());
                    lock (((ModelGame)model).Locker)
                        for (int i = 0; i < ((ModelGame)model).Pipes.Count; i++)
                            if (((ModelGame)model).Pipes[i].GetFullX() == 0)
                            {
                                ((ModelGame)model).Pipes.Remove(((ModelGame)model).Pipes[i]);
                                i--;
                            }
                }
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
            OnClose();
        }
        /// <summary>
        /// Обработчик фабрики труб
        /// </summary>
        private void FactoryHandler()
        {
            while (isPlaying)
            {
                lock (((ModelGame)model).Locker) 
                    ((ModelGame)model).Pipes.Add(((ModelGame)model).PipesFactory.CreatePipe());
                Thread.Sleep(FACTORY_TIMEOUT);
            }
        }
        /// <summary>
        /// Метод обработки завершения игры
        /// </summary>
        private void model_GameOver()
        {
            ((ModelGame)model).GameOver -= model_GameOver;
            factoryThread.Abort();
            ((ViewThread)view).Stop();
            isPlaying = false;
        }
    }
}
