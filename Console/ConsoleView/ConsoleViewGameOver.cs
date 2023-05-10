using View;
using System;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление окончания игры
    /// </summary>
    public class ConsoleViewGameOver : ViewGameOver
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления окончания игры
        /// </summary>
        public ConsoleViewGameOver(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного окончания игры
        /// </summary>
        public override void Show()
        {
            ConsoleViewOutput.Clear();
            ConsoleViewOutput.Write(text, model.GetFullX(), model.GetFullY(), model.Width, model.Height, ConsoleColor.Yellow);
            ConsoleViewOutput.Write("Имя: ", model.GetFullX(), model.GetFullY() + model.Height, model.Width, 1, ConsoleColor.Yellow);
            ConsoleViewOutput.PrintOnConsole();
            Console.SetCursorPosition(model.GetFullX() + 5, model.GetFullY() + model.Height);
        }
    }
}
