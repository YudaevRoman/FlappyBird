
namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта стены
    /// </summary>
    public class ModelWall : ModelGameObject 
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты и модель родителя игрового объекта стены
        /// </summary>
        public ModelWall(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
