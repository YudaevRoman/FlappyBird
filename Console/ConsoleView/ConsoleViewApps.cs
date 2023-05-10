using View;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление приложения
    /// </summary>
    public class ConsoleViewApps : ViewApps
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления приложения
        /// </summary>
        public ConsoleViewApps(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного приложения
        /// </summary>
        public override void Show() { ConsoleViewOutput.Initialization((short)model.Width, (short)model.Height); }
    }
}
