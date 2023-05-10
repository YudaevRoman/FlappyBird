
namespace Controller
{
    /// <summary>
    /// Базовый класс контроллера
    /// </summary>
    public abstract class Controller
    {
        //Делегаты
        /// <summary>
        /// Делегат событий контроллера
        /// </summary>
        public delegate void dEventHandler();

        //События
        /// <summary>
        /// Событие закрытия контроллера
        /// </summary>
        public event dEventHandler Close;

        //Поля
        /// <summary>
        /// Модель контроллера
        /// </summary>
        protected Model.Model model;
        /// <summary>
        /// Представление модели контроллера
        /// </summary>
        protected View.View view;

        //Конструткоры
        /// <summary>
        /// Конструктор задающий модель и представление контроллера
        /// </summary>
        public Controller(Model.Model _model, View.View _view) { model = _model; view = _view; }

        //Внешние методы
        /// <summary>
        /// Запуск контроллера
        /// </summary>
        public abstract void Start();

        //Внутренние методы
        /// <summary>
        /// Вызов события закрытия
        /// </summary>
        protected void OnClose() { Close?.Invoke(); }
    }
}
