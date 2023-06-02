using FormView.Output;
using Model;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using View;

namespace FormView
{
    /// <summary>
    /// Форма представления окончания игры
    /// </summary>
    public class FormViewGameOver : ViewGameOver
    {
        //Поля
        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 100;

        //Свойства
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы окончания игры
        /// </summary>
        public FormViewGameOver(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы окончания игры
        /// </summary>
        public override void Show()
        {
            while (isShowing)
            {
                if (model is ModelGameOver modelGameOver)
                {
                    FormViewOutput.DrawStringInRect(modelGameOver.Text + "\nСчёт: " + modelGameOver.Score + "\nИмя : " + Name,
                        new StringFormat()
                        {
                            LineAlignment = StringAlignment.Near,
                            Alignment = StringAlignment.Near
                        },
                        model.GetFullX(), model.GetFullY(), model.Width, model.Height, Color.Yellow);
                }
                FormViewOutput.ShowBuf();
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
        }
    }
}
