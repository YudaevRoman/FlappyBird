
namespace Controller
{
    /// <summary>
    /// Базовый класс контроллера игры
    /// </summary>
    public abstract class ControllerGame : Controller
    {

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление игры
        /// </summary>
        public ControllerGame(Model.Model model, View.View view) : base(model, view) { }
    }
}
