using View;
using Model;
using System.Drawing;
using FormView.Output;

namespace FormView
{
    /// <summary>
    /// Форма представление инструкции
    /// </summary>
    public class FormViewInstruction : ViewInstruction
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления инструкции
        /// </summary>
        public FormViewInstruction(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы инструкции
        /// </summary>
        public override void Show()
        {
            if (model is ModelInstruction modelInstruction)
            {
                FormViewOutput.DrawStringInRect(
                    modelInstruction.Text,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Near
                    },
                    modelInstruction.GetFullX(), modelInstruction.GetFullY(),
                    modelInstruction.Width, modelInstruction.Height,
                    Color.Yellow);
                FormViewOutput.ShowBuf();
            }
        }
    }
}
