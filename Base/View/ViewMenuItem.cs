using System;

namespace View
{
    /// <summary>
    /// Базовый класс представления пунктов меню
    /// </summary>
    public abstract class ViewMenuItem : ViewAll
    {
        //Свойства
        /// <summary>
        /// Текущий пункт меню перед отрисовкой
        /// </summary>
        public int CurrentItem { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления пунктов меню
        /// </summary>
        public ViewMenuItem(Model.Model model) : base(model) { }
    }
}
