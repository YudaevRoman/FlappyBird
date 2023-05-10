using View;
using System;
using Controller;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер инструкции
    /// </summary>
    public class ConsoleControllerInstruction : ControllerInstruction
    {
        //Конструктор
        /// <summary>
        /// Конструктор задающий модель и представление консольной инструкции
        /// </summary>
        public ConsoleControllerInstruction(Model.Model model, View.View view) : base(model, view) { }

        //Внешнией метод
        /// <summary>
        /// Запуск консольной инструкции
        /// </summary>
        public override void Start()
        {
            view.Show();
            bool isESCorENTER = false;
            while (!isESCorENTER)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.Enter:
                        isESCorENTER = true;
                        OnClose();
                        break;
                }

                if (isESCorENTER) { isESCorENTER = true; }
            }
        }
    }
}
