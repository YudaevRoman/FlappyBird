
namespace Model
{
    /// <summary>
    /// Базовый класс для всех моделей
    /// </summary>
    public abstract class Model
    {
        //Свойства
        /// <summary>
        /// Возвращает или задаёт родительскую модель к текущей
        /// </summary>
        public Model Parent { get; set; }
        /// <summary>
        /// Координаты модели по X относительно родительской модели
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Координаты модели по Y относительно родительской модели
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Ширина модели
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота модели
        /// </summary>
        public int Height { get; set; }

        //Консрукторы
        public Model(int x, int y, int width, int height, Model parent)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Parent = parent;
        }

        //Внешние методы
        /// <summary>
        /// Получить координату X относительно окна приложения
        /// </summary>
        /// <returns>Координата X текущей модели относительно окна</returns>
        public int GetFullX() { return Parent == null ? X : X + Parent.GetFullX(); }
        /// <summary>
        /// Получить координату Y относительно окна приложения
        /// </summary>
        /// <returns>Координата Y текущей модели относительно окна</returns>
        public int GetFullY() { return Parent == null ? Y : Y + Parent.GetFullY(); }

    }
}
