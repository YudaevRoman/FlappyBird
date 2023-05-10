using View;
using Model;
using System;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление счёта игры
    /// </summary>
    public class ConsoleViewGameScore : ViewGameScore
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления счёта игры
        /// </summary>
        public ConsoleViewGameScore(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного счёта игры
        /// </summary>
        public override void Show()
        {
            if(model is ModelGameScore modelGameScore)
            {
                ConsoleViewOutput.Write(
                    "Очки: " + modelGameScore.Score,
                    modelGameScore.GetFullX(), modelGameScore.GetFullY(), 
                    modelGameScore.Width, modelGameScore.Height,
                    ConsoleColor.White);
            }
        }
    }
}
