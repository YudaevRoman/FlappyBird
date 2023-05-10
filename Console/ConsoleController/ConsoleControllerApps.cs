using Model;
using Controller;
using ConsoleView;
using ConsoleController;

namespace ConsoleController
{
    /// <summary>
    /// Консольноый контроллер приложения
    /// </summary>
    public class ConsoleControllerApps : ControllerApps
    {
        //Поля
        /// <summary>
        /// Сущность контроллера
        /// </summary>
        private static ConsoleControllerApps instance;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление консольного приложения
        /// </summary>
        private ConsoleControllerApps(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск консольного приложения
        /// </summary>
        public override void Start() 
        { 
            view.Show();

            ModelMenu _model = new ModelMenu(0, 0, (int)(model.Width * 0.3) + (int)(model.Width * 0.01 * 7), model.Height - 12, model);
            _model.Heading = new ModelMenuHeading((int)(model.Width * 0.33), 2, (int)(model.Width * 0.3) + (int)(model.Width * 0.01 * 8), 10, model);
            ConsoleControllerMenu menu = ConsoleControllerMenu.GetInstance(_model);

            menu.Start();
        }
        /// <summary>
        /// Получить сущность контроллера
        /// </summary>
        public static ConsoleControllerApps GetInstance(ModelApps _model)
        {
            if (instance == null) { instance = new ConsoleControllerApps(_model, new ConsoleViewApps(_model)); }

            return instance;
        }
    }
}
