using View;
using Model;
using System;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление инструкции
    /// </summary>
    public class ConsoleViewInstruction : ViewInstruction
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления инструкции
        /// </summary>
        public ConsoleViewInstruction(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной инструкции
        /// </summary>
        public override void Show()
        {
            if(model is ModelInstruction modelInstruction)
            {
                ConsoleViewOutput.Clear();
                ConsoleViewOutput.Write(
                    modelInstruction.Text, 
                    modelInstruction.GetFullX(), modelInstruction.GetFullY(),
                    modelInstruction.Width, modelInstruction.Height,
                    ConsoleColor.Yellow);
                ConsoleViewOutput.PrintOnConsole();
            }
        }
    }
}
