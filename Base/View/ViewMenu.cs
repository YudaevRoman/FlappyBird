
namespace View
{
    /// <summary>
    /// Базовый класс представления модели меню
    /// </summary>
    public abstract class ViewMenu : ViewThread
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления меню
        /// </summary>
        public ViewMenu(Model.Model model) : base(model) { }
    }
}
