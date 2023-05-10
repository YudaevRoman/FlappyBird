
namespace View
{
    /// <summary>
    /// Базовый класс представления модели игры
    /// </summary>
    public abstract class ViewGame : ViewThread
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий моель представления пункта меню
        /// </summary>
        public ViewGame(Model.Model model) : base(model) { }
    }
}
