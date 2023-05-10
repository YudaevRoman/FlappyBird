
namespace Model
{
    /// <summary>
    /// Модель приложения
    /// </summary>
    public class ModelApps : Model 
    {
        //Конструктор
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели приложения
        /// </summary>
        public ModelApps(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
