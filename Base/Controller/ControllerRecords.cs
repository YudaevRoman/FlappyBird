
namespace Controller
{
    /// <summary>
    /// Базовый контроллер таблицы рекордов
    /// </summary>
    public abstract class ControllerRecords : Controller
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление таблицы рекордов
        /// </summary>
        public ControllerRecords(Model.Model model, View.View view) : base(model, view) { }
    }
}
