using System;
using Model.Objects;
using System.Collections.Generic;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Консольное предтавление трубы
    /// </summary>
    public class ConsoleViewPipe : ConsoleViewGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления трубы
        /// </summary>
        public ConsoleViewPipe(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной трубы
        /// </summary>
        public override void Show()
        {
            if(model is ModelPipe pipe)
            {
                pipe.Body.ForEach(obj => WriteObject("║", obj, ConsoleColor.Green));
                pipe.Voids.ForEach(obj => WriteObject(" ", obj, ConsoleColor.Green));
            }
        }
        /// <summary>
        /// Представление консольного списка моделей труб
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
