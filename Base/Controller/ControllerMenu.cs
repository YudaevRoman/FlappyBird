
namespace Controller
{
    /// <summary>
    /// Базовый класс контроллера меню
    /// </summary>
    public abstract class ControllerMenu : Controller
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий меодель и представление меню
        /// </summary>
        public ControllerMenu(Model.Model model, View.View view) : base(model, view) { }
    }
}
