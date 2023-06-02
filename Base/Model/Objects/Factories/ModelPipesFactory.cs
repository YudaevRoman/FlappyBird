using System;

namespace Model.Objects.Factories
{
    /// <summary>
    /// Модель фабрики производства труб
    /// </summary>
    public class ModelPipesFactory : Model
    {
        //Поля
        /// <summary>
        /// Размер игровых объектов
        /// </summary>
        public int gameObjectsSize { get; set; }

        //Генераторы
        /// <summary>
        /// Генератор случайной позиции пустот в трубе
        /// </summary>
        private Random rand;

        //Конструкторы
        /// <summary>
        /// Конструктор с заданными координатами
        /// </summary>
        public ModelPipesFactory(int x, int y, int width, int height, Model parent, int _gameObjectsSize) : base(x, y, width, height, parent)
        {
            gameObjectsSize = _gameObjectsSize;
            rand = new Random(); 
        }

        //Внешние методы
        /// <summary>
        /// Метод создания труб
        /// </summary>
        public ModelPipe CreatePipe()
        {
            int countY = (int)(Parent.Height / gameObjectsSize);
            if (countY * gameObjectsSize + gameObjectsSize > Parent.Height) countY--;
            ModelPipe pipe = new ModelPipe(
                X, Y, gameObjectsSize, (countY * gameObjectsSize) - Y * 3, Parent, 
                (int)(rand.Next(Y, Parent.Height - Y * 2) / gameObjectsSize)
                );
            pipe.Step = gameObjectsSize;
            return pipe;
        }
    }
}
