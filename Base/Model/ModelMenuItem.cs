namespace Model
{
    /// <summary>
    /// Модель пункта меню
    /// </summary>
    public class ModelMenuItem : Model 
    {
        //Делегаты
        /// <summary>
        /// Делегат действия пункта меню
        /// </summary>
        public delegate void dAction();

        //Свойства
        /// <summary>
        /// Установить, получить или выполнить действие пункта меню
        /// </summary>
        public dAction Action { get; set; }
        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string Text { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор с заданным текстом и действием пункта меню
        /// </summary>
        /// <param name="text">Текст пункта меню</param>
        /// <param name="action">Действие пункта меню</param>
        public ModelMenuItem(int x, int y, int width, int height, Model parent, string text, dAction action) 
            : base(x, y, width, height, parent) 
        { 
            Text = text; 
            Action = action; 
        }
    }
}
