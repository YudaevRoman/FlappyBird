using Model;

namespace View
{
    /// <summary>
    /// Базовый класс представления окончания игры
    /// </summary>
    public abstract class ViewGameOver : ViewThread
    {
        //Поля
        /// <summary>
        /// Текст представления окончания игры
        /// </summary>
        protected string text;

        //Конструкторы
        /// <summary>
        /// Конуструктор задающий модель представления окончания игры
        /// </summary>
        /// <param name="model"></param>
        public ViewGameOver(Model.Model model) : base(model) 
        {
            if (model is ModelGameOver modelGameOver) text = modelGameOver.Text;
            else text = Properties.Resources.NotFound;
        }
    }
}
