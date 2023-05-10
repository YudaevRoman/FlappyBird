using System;

namespace Model.Objects.Factories
{
    /// <summary>
    /// Модель фабрики производства труб
    /// </summary>
    public class ModelPipesFactory
    {
        //Поля
        /// <summary>
        /// Координата X позиции трубы фабрики
        /// </summary>
        private int x;
        /// <summary>
        /// Координата Y позиции трубы фабрики
        /// </summary>
        private int y;
        /// <summary>
        /// Размер экхемпляров
        /// </summary>
        private int size;
        /// <summary>
        /// Модель родителя
        /// </summary>
        private Model parent;

        //Генераторы
        /// <summary>
        /// Генератор случайной позиции пустот в трубе
        /// </summary>
        private Random rand;

        //Конструкторы
        /// <summary>
        /// Конструктор с заданными координатами
        /// </summary>
        public ModelPipesFactory(int _x, int _y, Model _parent, int _size) 
        { 
            x = _x; 
            y = _y; 
            parent = _parent;
            size = _size;
            rand = new Random(); 
        }

        //Внешние методы
        /// <summary>
        /// Метод создания труб
        /// </summary>
        public ModelPipe CreatePipe()
        {
            int countY = (int)(parent.Height / size);
            if (countY * size + size > parent.Height) countY--;
            ModelPipe pipe = new ModelPipe(
                x, y, size, (countY * size) - y * 3, parent, 
                (int)(rand.Next(y, parent.Height - y * 2) / size)
                );
            pipe.Step = size;
            return pipe;
        }
    }
}
