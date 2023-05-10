using System;
using System.Collections.Generic;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Консольное представление стен (границ)
    /// </summary>
    public class ConsoleViewWall : ConsoleViewGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления стен (границ)
        /// </summary>
        public ConsoleViewWall(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной стены (границы)
        /// </summary>
        public override void Show() { WriteObject("#", model, ConsoleColor.White); }
        /// <summary>
        /// Представление консольного списка моделей стен (границ)
        /// </summary>
        public override void ShowAll(List<Model.Model> models)
        {
            models.ForEach(_model =>
            {
                model = _model;
                Show();
            });
        }
    }
}
