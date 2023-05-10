using View;
using Model;
using FormView.Output;
using System.Threading;

namespace FormView
{
    /// <summary>
    /// Форма представление меню
    /// </summary>
    public class FormViewMenu : ViewMenu
    {
        //Поля
        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления меню
        /// </summary>
        public FormViewMenu(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы меню
        /// </summary>
        public override void Show()
        {
            if (model is ModelMenu modelMenu)
            {
                FormViewMenuItem item = new FormViewMenuItem(null);
                FormViewMenuHeading heading = new FormViewMenuHeading(modelMenu.Heading);
                while(isShowing)
                {
                    heading.Show();
                    item.CurrentItem = modelMenu.CurrentItem;
                    item.ShowAll(modelMenu.Items);
                    FormViewOutput.ShowBuf();
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }
    }
}
