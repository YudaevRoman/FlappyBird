
namespace Controller
{
    /// <summary>
    /// Базовый класс контролля инструкции
    /// </summary>
    public abstract class ControllerInstruction : Controller
    {
        //Конструктор
        /// <summary>
        /// Конструктор задающий моедль и представление инструкции
        /// </summary>
        public ControllerInstruction(Model.Model model, View.View view) : base(model, view) { }
    }
}
