
namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта
    /// </summary>
    public class ModelGameObject : Model
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты и модель родителя игрового объекта
        /// </summary>
        public ModelGameObject(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }

        //Внешние методы
        /// <summary>
        /// Сравнить игровой объект с текущим игровым объектом
        /// </summary>
        public virtual bool Compare(ModelGameObject obj) { return GetFullX() == obj.GetFullX() && GetFullY() == obj.GetFullY(); }
    }
}
