
namespace View.Objects
{
    /// <summary>
    /// Базовый класс представления игрового объекта
    /// </summary>
    public abstract class ViewGameObject : ViewAll
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления игрового объекта
        /// </summary>
        public ViewGameObject(Model.Model model) : base(model) { }
    }
}
