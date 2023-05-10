
namespace View
{
    /// <summary>
    /// Базовое класс для всех представлений
    /// </summary>
    public abstract class View
    {
        //Поля
        /// <summary>
        /// Модель представления
        /// </summary>
        protected Model.Model model;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления
        /// </summary>
        public View(Model.Model _model) { model = _model; }

        //Внешние методы
        /// <summary>
        /// Отображение
        /// </summary>
        public abstract void Show();
    }
}
