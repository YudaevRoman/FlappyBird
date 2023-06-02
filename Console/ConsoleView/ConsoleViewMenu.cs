using View;
using Model;
using System;
using System.Threading;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление меню
    /// </summary>
    public class ConsoleViewMenu : ViewMenu
    {
        //Поля
        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления меню
        /// </summary>
        public ConsoleViewMenu(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного меню
        /// </summary>
        public override void Show()
        {
            if(model is ModelMenu modelMenu)
            {
                ConsoleViewMenuItem item = new ConsoleViewMenuItem(null);
                ConsoleViewMenuHeading heading = new ConsoleViewMenuHeading(modelMenu.Heading);
                while(isShowing)
                {
                    ConsoleViewOutput.CursorVisible(false);
                    ConsoleViewOutput.Clear();
                    heading.Show();
                    item.CurrentItem = modelMenu.CurrentItem;
                    item.ShowAll(modelMenu.Items);
                    ConsoleViewOutput.PrintOnConsole();
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }
    }
}
