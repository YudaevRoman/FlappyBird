using View;
using System;
using ConsoleView.Output;
using Model;

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
            if (model is ModelGameOver modelGameOver)
            {
                ConsoleViewOutput.Write(modelGameOver.Text, model.GetFullX(), model.GetFullY(), model.Width, model.Height, ConsoleColor.Yellow);
                ConsoleViewOutput.Write("Счёт: " + modelGameOver.Score, model.GetFullX(), model.GetFullY() + model.Height, model.Width, model.Height, ConsoleColor.Yellow);
            }
            ConsoleViewOutput.Write("Имя : ", model.GetFullX(), model.GetFullY() + (2 * model.Height), model.Width, model.Height, ConsoleColor.Yellow);
            ConsoleViewOutput.PrintOnConsole();
            ConsoleViewOutput.CursorVisible(true);
            ConsoleViewOutput.SetCursorPosition(model.GetFullX() + 6, model.GetFullY() + (2 * model.Height));
        }
    }
}
