using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Модель меню
    /// </summary>
    public class ModelMenu : Model
    {
        //Поля
        /// <summary>
        /// Номер текущего пункта меню в списке
        /// </summary>
        private int currentItem;
        /// <summary>
        /// Заголовок меню
        /// </summary>
        private ModelMenuHeading heading;

        //Свойства
        /// <summary>
        /// Заголовок меню
        /// </summary>
        public ModelMenuHeading Heading 
        {
            get { return heading; }
            set
            {
                if (value != null)
                {
                    X = value.X;
                    Y = value.Y + value.Height + 1;
                    Parent = value.Parent;
                    heading = value;
                }
            }
        }
        /// <summary>
        /// Список пунктов меню
        /// </summary>
        public List<Model> Items { get; set; } = new List<Model>();
        /// <summary>
        /// Получить или установить номер текущего пункта меню в списке
        /// </summary>
        public int CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value < 0 ? Items.Count - 1 : value >= Items.Count ? 0 : value; }
        }

        //Конструкторы
        /// <summary>
        /// По умолчанию
        /// </summary>
        public ModelMenu(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }

        //Внешние методы
        /// <summary>
        /// Выполнить действие текущего пункта меню в спике
        /// </summary>
        public void Action() { if(Items[CurrentItem] is ModelMenuItem item) item.Action(); }
    }
}
