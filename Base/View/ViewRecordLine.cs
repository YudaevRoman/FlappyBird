
namespace View
{
    /// <summary>
    ///  Базовый класс представления линии рекорда таблицы
    /// </summary>
    public abstract class ViewRecordLine : ViewAll
    {
        //Поля
        /// <summary>
        /// Имя игрока линии рекорда таблицы перед отрисовкой
        /// </summary>
        protected string name;
        /// <summary>
        /// Счёт игрока линии рекорда таблицы перед отрисовкой
        /// </summary>
        protected string score;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления линии рекорда таблицы
        /// </summary>
        /// <param name="model"></param>
        public ViewRecordLine(Model.Model model) : base(model) { }
    }
}
