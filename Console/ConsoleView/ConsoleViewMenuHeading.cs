using View;
using Model;
using System;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление заголовка меню
    /// </summary>
    public class ConsoleViewMenuHeading : ViewMenuHeading
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления заголовка меню
        /// </summary>
        public ConsoleViewMenuHeading(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного заголовка меню
        /// </summary>
        public override void Show()
        {
            if(model is ModelMenuHeading modelMenuHeading)
            {
                ConsoleViewOutput.Write(
                    modelMenuHeading.Text,
                    modelMenuHeading.GetFullX(), modelMenuHeading.GetFullY(),
                    modelMenuHeading.Width, modelMenuHeading.Height,
                    ConsoleColor.White);
            }
        }
    }
}
