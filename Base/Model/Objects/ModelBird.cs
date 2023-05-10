using Model.Objects.Enum;

namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта птицы
    /// </summary>
    public class ModelBird : ModelGameObject
    {
        /// <summary>
        /// Состояния птицы
        /// </summary>
        public BirdState State { get; set; } = BirdState.FALLS;
        /// <summary>
        /// Шаг птицы
        /// </summary>
        public int Step { get; set; } = 1;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты и модель родителя игрового объекта птицы
        /// </summary>
        public ModelBird(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) 
        { 
            
        }

        //Внешние методы
        /// <summary>
        /// Метод перемещения птицы
        /// </summary>
        public void Move()
        {
            switch (State)
            {
                case BirdState.FLIES:
                    Y -= Step;
                    State = BirdState.FALLS;
                    break;
                case BirdState.FALLS:
                    Y += Step;
                    break;
            }
        }
    }
}
