
namespace View
{
    /// <summary>
    /// Базовый класс представления счёта игры
    /// </summary>
    public abstract class ViewGameScore : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления счёта игры
        /// </summary>
        public ViewGameScore(Model.Model model) : base(model) { }
    }
}
