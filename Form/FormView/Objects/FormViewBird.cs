using System;
using System.Drawing;
using System.Collections.Generic;

namespace FormView.Objects
{
    /// <summary>
    /// Форма представление птицы
    /// </summary>
    public class FormViewBird : FormViewGameObject
    {
        //Поля
        private Image image = Properties.Resources.Bird;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель Формы представления птицы
        /// </summary>
        public FormViewBird(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы птицы
        /// </summary>
        public override void Show() { DrawObject(model, image); }

        /// <summary>
        /// Представление формы списка моделей птиц
        /// </summary>
        public override void ShowAll(List<Model.Model> models)
        {
            throw new NotImplementedException();
        }
    }
}
