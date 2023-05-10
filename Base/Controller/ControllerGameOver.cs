
namespace Controller
{
    /// <summary>
    /// Базовый классс котроллера окончания игры
    /// </summary>
    public abstract class ControllerGameOver : Controller
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление окончания игры
        /// </summary>
        public ControllerGameOver(Model.Model model, View.View view) : base(model, view) { }
    }
}
