using View;
using Model;
using System.Drawing;
using FormView.Output;

namespace FormView
{
    /// <summary>
    /// Форма представления счёта игры
    /// </summary>
    public class FormViewGameScore : ViewGameScore
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления счёта игры
        /// </summary>
        public FormViewGameScore(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы счёта игры
        /// </summary>
        public override void Show()
        {
            if (model is ModelGameScore modelGameScore)
            {
                FormViewOutput.DrawString(
                    "Очки: " + modelGameScore.Score,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    },
                    modelGameScore.GetFullX(), modelGameScore.GetFullY(),
                    modelGameScore.Width, modelGameScore.Height,
                    Color.White);
            }
        }
    }
}