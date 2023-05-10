using System.Collections.Generic;

namespace View
{
    /// <summary>
    /// Базовый класс представления списка моделей
    /// </summary>
    public abstract class ViewAll : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представлению списка моделей
        /// </summary>
        public ViewAll(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Отобразить все модели списка 
        /// </summary>
        public abstract void ShowAll(List<Model.Model> models);
    }
}
