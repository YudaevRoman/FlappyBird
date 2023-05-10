using View;
using Model;
using System;
using ConsoleView.Output;
using System.Collections.Generic;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление пункта меню
    /// </summary>
    public class ConsoleViewMenuItem : ViewMenuItem
    {
        //Поля
        /// <summary>
        /// Цвет пункта меню перед отрисовкой
        /// </summary>
        private ConsoleColor color;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления пункта меню
        /// </summary>
        public ConsoleViewMenuItem(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольного пункта меню
        /// </summary>
        public override void Show()
        {
            if(model is ModelMenuItem modelMenuItem)
            {
                ConsoleViewOutput.Write(
                    "╔" + "".PadRight(modelMenuItem.Width - 2, '═') + "╗" +
                    "║" + modelMenuItem.Text.PadLeft(modelMenuItem.Text.Length + 
                    (modelMenuItem.Width - modelMenuItem.Text.Length) / 2, ' ').PadRight((modelMenuItem.Width - 2), ' ') + "║" +
                    "╚" + "".PadRight(modelMenuItem.Width - 2, '═') + "╝",
                    modelMenuItem.GetFullX(), modelMenuItem.GetFullY(),
                    modelMenuItem.Width, modelMenuItem.Height,
                    color
                    );
            }
        }
        /// <summary>
        /// Представление консольного списка моделей пунктов меню
        /// </summary>
        public override void ShowAll(List<Model.Model> models)
        {
            if (models.Count > 0)
            {
                int i = 0;
                models.ForEach(obj => 
                {
                    color = i++ == CurrentItem ? ConsoleColor.Red : ConsoleColor.Yellow; 
                    model = obj; 
                    Show(); 
                });
            }
        }
    }
}
