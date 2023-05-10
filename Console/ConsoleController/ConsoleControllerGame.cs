using View;
using Model;
using System;
using Controller;
using Model.Objects;
using System.Threading;
using Model.Objects.Enum;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер игры
    /// </summary>
    public class ConsoleControllerGame : ControllerGame
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
        /// Поток отслеживания ввода с клавиатуры
        /// </summary>
        private Thread keysThread;
        /// <summary>
        /// Поток работы фабрики
        /// </summary>
        private Thread factoryThread;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление консольного контроллера игры
        /// </summary>
        public ConsoleControllerGame(Model.Model model, View.View view) : base(model, view)
        {
            if(model is ModelGame modelGame) modelGame.GameOver += model_GameOver;
        }

        //Внешние методы
        /// <summary>
        /// Запуск консольной игры
        /// </summary>
        public override void Start() { if(model is ModelGame) { if (view is ViewThread) { Game(); } } }

        //Внутренние методы
        /// <summary>
        /// Запуск игры
        /// </summary>
        private void Game()
        {
            isPlaying = true;

            ((ViewThread)view).Start();
            keysThread = new Thread(KeyHandler);
            keysThread.Start();
            factoryThread = new Thread(FactoryHandler);
            factoryThread.Start();
            
            while (isPlaying)
            {
                if (!((ModelGame)model).GameOverCheck())
                {
                    if (((ModelGame)model).PipeCrossing()) lock (((ModelGame)model).Locker) ((ModelGame)model).Score = (Int32.Parse(((ModelGame)model).Score) + 1).ToString();
                    lock (((ModelGame)model).Locker) ((ModelGame)model).Bird.Move();
                    lock (((ModelGame)model).Locker) ((ModelGame)model).Pipes.ForEach(pipe => ((ModelPipe)pipe).Move());
                    lock (((ModelGame)model).Locker) 
                        for (int i = 0; i < ((ModelGame)model).Pipes.Count; i++)
                            if (((ModelGame)model).Pipes[i].X == 1)
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
        /// Обработки клавиш в потоке
        /// </summary>
        private void KeyHandler()
        {
            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.Spacebar:
                        case ConsoleKey.UpArrow:
                            lock (((ModelGame)model).Locker) ((ModelGame)model).Bird.State = BirdState.FLIES;
                            break;
                        case ConsoleKey.Escape:
                            ((ViewThread)view).Stop();
                            isPlaying = false;
                            return;
                    }
                }
            }
        }
        /// <summary>
        /// Обработчик фабрики труб
        /// </summary>
        private void FactoryHandler()
        {
            while (isPlaying)
            {
                lock (((ModelGame)model).Locker) ((ModelGame)model).Pipes.Add(((ModelGame)model).PipesFactory.CreatePipe());
                Thread.Sleep(FACTORY_TIMEOUT);
            }
        }
        /// <summary>
        /// Метод обработки завершения игры
        /// </summary>
        private void model_GameOver()
        {
            ((ModelGame)model).GameOver -= model_GameOver;
            keysThread.Abort();
            factoryThread.Abort();
            ((ViewThread)view).Stop();
            isPlaying = false;
            OnGameOver();
        }
    }
}
