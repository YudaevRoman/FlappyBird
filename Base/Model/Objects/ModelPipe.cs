using System.Collections.Generic;

namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта трубы
    /// </summary>
    public class ModelPipe : ModelGameObject
    {
        //Поля
        /// <summary>
        /// Длина пустоты трубы
        /// </summary>
        private int voidLenght = 5;
        /// <summary>
        /// Шаг трубы
        /// </summary>
        private int step = 1;

        //Свойства
        /// <summary>
        /// Компонененты туловища трубы
        /// </summary>
        public List<ModelGameObject> Body { get; set; } = new List<ModelGameObject>();
        /// <summary>
        /// Пустые компоненты трубы
        /// </summary>
        public List<ModelGameObject> Voids { get; set; } = new List<ModelGameObject>();
        /// <summary>
        /// Длина пустоты трубы
        /// </summary>
        public int VoidLength 
        { 
            get { return voidLenght; } 
            set { if (value > 0) voidLenght = value; }
        }
        /// <summary>
        /// Шаг трубы
        /// </summary>
        public int Step 
        { 
            get { return step; } 
            set { if (value > 0) step = value; }
        }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, модель родителя, позиция пустоты и длину пустоты игрового объекта трубы
        /// </summary>
        public ModelPipe(int x, int y, int width, int height, Model parent, int voidPos) : base(x, y, width, height, parent)
        {
            if(voidPos > VoidLength - 1) voidPos -= VoidLength;
            InitializationBody();
            InitializationVoids(voidPos);
        }

        //Внешние методы
        /// <summary>
        /// Перемещение трубы
        /// </summary>
        public void Move() { X -= Step; }
        /// <summary>
        /// Проверить столкновение игрового объекта и трубы
        /// </summary>
        public override bool Compare(ModelGameObject obj)
        {
            foreach (var body in Body)
            {
                if (body.GetFullX() == obj.GetFullX() && body.GetFullY() == obj.GetFullY())
                {
                    foreach (var voiD in Voids)
                    {
                        if (voiD.GetFullX() == obj.GetFullX() && voiD.GetFullY() == obj.GetFullY()) return false;
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Проверка пересечения игрового объекта и трубы
        /// </summary>
        public bool Crossing(ModelGameObject obj) { return GetFullX() == obj.GetFullX(); }

        //Внутренние методы
        /// <summary>
        /// Инициализация туловища трубы
        /// </summary>
        private void InitializationBody()
        {
            int count = (int)(Height / Width);
            for (int i = 0; i < count; i++)
            {
                Body.Add(new ModelPipeBody(0, i * Width, Width, Width, this));
            }
        }
        /// <summary>
        /// Инициализация пустот трубы
        /// </summary>
        private void InitializationVoids(int pos)
        {
            for (int i = 0; i < VoidLength; i++)
            {
                Voids.Add(new ModelPipeVoid(0, pos * Width + i * Width, Width, Width, this));
            }
        }
    }
}
