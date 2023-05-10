using Model.Objects;
using System.Drawing;
using FormView.Output;
using System.Collections.Generic;

namespace FormView.Objects
{
    /// <summary>
    /// Консольное предтавление трубы
    /// </summary>
    public class FormViewPipe : FormViewGameObject
    {
        //Поля
        private Image image = Properties.Resources.Pipe;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления трубы
        /// </summary>
        public FormViewPipe(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы трубы
        /// </summary>
        public override void Show()
        {
            if (model is ModelPipe pipe)
            {
                pipe.Body.ForEach(objBody =>
                {
                    if (!pipe.Voids.Exists(objVoid => objVoid.GetFullY() == objBody.GetFullY()))
                        DrawObject(objBody, image);
                });
            }
        }
        /// <summary>
        /// Представление формы списка моделей труб
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
