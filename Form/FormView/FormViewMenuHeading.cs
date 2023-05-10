using View;
using Model;
using System.Drawing;
using FormView.Output;

namespace FormView
{
    /// <summary>
    /// Формы представление заголовка меню
    /// </summary>
    public class FormViewMenuHeading : ViewMenuHeading
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления заголовка меню
        /// </summary>
        public FormViewMenuHeading(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы заголовка меню
        /// </summary>
        public override void Show()
        {
            if (model is ModelMenuHeading modelMenuHeading)
            {
                FormViewOutput.DrawString(
                    modelMenuHeading.Text,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    },
                    modelMenuHeading.GetFullX(), modelMenuHeading.GetFullY(),
                    modelMenuHeading.Width, modelMenuHeading.Height,
                    Color.White);
            }
        }
    }
}