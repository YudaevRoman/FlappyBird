
namespace View
{
    /// <summary>
    /// Базовый класс представления таблицы рекордов
    /// </summary>
    public abstract class ViewRecords : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления таблицы рекордов
        /// </summary>
        public ViewRecords(Model.Model model) : base(model) { }

    }
}
