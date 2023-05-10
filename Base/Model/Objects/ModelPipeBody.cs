
namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта туловища трубы
    /// </summary>
    public class ModelPipeBody : ModelGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты игрового объекта туловища трубы
        /// </summary>
        public ModelPipeBody(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
