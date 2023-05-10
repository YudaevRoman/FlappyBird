
namespace Model
{
    /// <summary>
    /// Модель заголовка меню
    /// </summary>
    public class ModelMenuHeading : Model
    {
        //Свойства
        public string Text { get; } = Properties.Resources.Heading;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели заголовка меню
        /// </summary>
        public ModelMenuHeading(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
