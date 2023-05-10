
namespace View
{
    /// <summary>
    /// Базовый класс представления заголовка меню
    /// </summary>
    public abstract class ViewMenuHeading : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления заголовка меню
        /// </summary>
        public ViewMenuHeading(Model.Model model) : base(model) { }
    }
}
