
namespace View
{
    /// <summary>
    ///  Базовый класс представления линии рекорда таблицы
    /// </summary>
    public abstract class ViewRecordLine : ViewAll
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления линии рекорда таблицы
        /// </summary>
        /// <param name="model"></param>
        public ViewRecordLine(Model.Model model) : base(model) { }
    }
}
