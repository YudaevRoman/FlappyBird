using System.Threading;

namespace View
{
    /// <summary>
    /// Базовый класс потокового представления
    /// </summary>
    public abstract class ViewThread : View
    {
        //Поля
        /// <summary>
        /// Флаг показа
        /// </summary>
        protected bool isShowing;

        //Потоки
        /// <summary>
        /// Поток представления
        /// </summary>
        protected Thread viewThread;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель потокового представления
        /// </summary>
        public ViewThread(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Запук потока представления
        /// </summary>
        public virtual void Start()
        {
            viewThread = new Thread(Show);
            viewThread.IsBackground = true;
            viewThread.Start();
            isShowing = true;
        }
        /// <summary>
        /// Остановка потока представления
        /// </summary>
        public virtual void Stop() { isShowing = false; }
        /// <summary>
        /// Дополнительный метод остановки потока представления
        /// </summary>
        public void ExtraStop()
        {
            viewThread.Abort();
            Stop();
        }
    }
}
