using System.Drawing;
using System.Collections.Generic;

namespace FormView.Objects
{
    /// <summary>
    /// Консольное представление стен (границ)
    /// </summary>
    public class FormViewWall : FormViewGameObject
    {
        //Поля
        private Image image = Properties.Resources.Wall;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления стен (границ)
        /// </summary>
        public FormViewWall(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы стены (границы)
        /// </summary>
        public override void Show() { DrawObject(model, image); }
        /// <summary>
        /// Представление формы списка моделей стен (границ)
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
