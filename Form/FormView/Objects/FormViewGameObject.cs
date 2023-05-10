using View.Objects;
using System.Drawing;
using FormView.Output;

namespace FormView.Objects
{
    /// <summary>
    /// Базовое представление формы игрового объекта
    /// </summary>
    public abstract class FormViewGameObject : ViewGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представление игровго объекта
        /// </summary>
        public FormViewGameObject(Model.Model model) : base(model) { }

        //Внутренние  методы
        /// <summary>
        /// Занести объект в буфер формы
        /// </summary>
        protected void DrawObject(Model.Model model, Image image)
        {
            FormViewOutput.DrawImage(model.GetFullX(), model.GetFullY(), model.Width, model.Height, image);
        }
    }
}