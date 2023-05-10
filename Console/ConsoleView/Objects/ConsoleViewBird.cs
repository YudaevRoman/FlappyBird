using System;
using System.Collections.Generic;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Консольное представление птицы
    /// </summary>
    public class ConsoleViewBird : ConsoleViewGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления птицы
        /// </summary>
        public ConsoleViewBird(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной птицы
        /// </summary>
        public override void Show() { WriteObject("W", model, ConsoleColor.Yellow); }
        /// <summary>
        /// Представление консольного списка моделей птиц
        /// </summary>
        public override void ShowAll(List<Model.Model> models)
        {
            throw new NotImplementedException();
        }
    }
}
