
namespace View
{
    /// <summary>
    /// Базовый класс представления приложения
    /// </summary>
    public abstract class ViewApps : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления приложения
        /// </summary>
        public ViewApps(Model.Model model) : base(model) { }
    }
}
