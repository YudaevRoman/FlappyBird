using FormView.Output;
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
                FormViewOutput.DrawStringInRect(text + "\nИмя: " + Name, 
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Near
                    }, 
                    model.GetFullX(), model.GetFullY(), model.Width, model.Height, Color.Yellow);
                FormViewOutput.ShowBuf();
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyEventArgs key)
        {
            switch(key.KeyCode)
            {
                case Keys.Back:
                    if(Name.Length != 0) Name = Name.Remove(Name.Length - 1, 1);
                    break;
                default:
                    if (key.KeyValue > 0x40 && key.KeyValue < 0x5A)
                    {
                        Name = Name + ((char)key.KeyValue).ToString().ToLower();
                    }
                    break;
            }
        }
    }
}
