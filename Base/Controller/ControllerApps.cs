
namespace Controller
{
    /// <summary>
    /// Базовый класс контролля приложения
    /// </summary>
    public abstract class ControllerApps : Controller
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление приложения
        /// </summary>
        public ControllerApps(Model.Model model, View.View view) : base(model, view) { }
    }
}
