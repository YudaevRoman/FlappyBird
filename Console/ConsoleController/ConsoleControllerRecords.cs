using System;
using Controller;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер таблицы рекордов
    /// </summary>
    public class ConsoleControllerRecords : ControllerRecords
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление консольной таблицы рекордов
        /// </summary>
        public ConsoleControllerRecords(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск консольной таблицы рекордов
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
