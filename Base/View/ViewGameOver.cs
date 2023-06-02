using Model;

namespace View
{
    /// <summary>
    /// Базовый класс представления окончания игры
    /// </summary>
    public abstract class ViewGameOver : ViewThread
    {
        //Конструкторы
        /// <summary>
        /// Конуструктор задающий модель представления окончания игры
        /// </summary>
        /// <param name="model"></param>
        public ViewGameOver(Model.Model model) : base(model)  { }
    }
}
