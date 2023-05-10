
namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта пустоты трубы
    /// </summary>
    public class ModelPipeVoid : ModelGameObject 
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты и модель родителя игрового объекта пустоты трубы
        /// </summary>
        public ModelPipeVoid(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
