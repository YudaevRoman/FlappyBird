using View;
using Model;
using System.Drawing;
using FormView.Output;
using System.Collections.Generic;

namespace FormView
{
    /// <summary>
    /// Форма представление пункта меню
    /// </summary>
    public class FormViewMenuItem : ViewMenuItem
    {
        //Поля
        /// <summary>
        /// Цвет пункта меню перед отрисовкой
        /// </summary>
        private Color color;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления пункта меню
        /// </summary>
        public FormViewMenuItem(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы пункта меню
        /// </summary>
        public override void Show()
        {
            if (model is ModelMenuItem modelMenuItem)
            {
                FormViewOutput.DrawStringInRect(
                    modelMenuItem.Text,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    },
                    modelMenuItem.GetFullX(), modelMenuItem.GetFullY(),
                    modelMenuItem.Width, modelMenuItem.Height,
                    color);
            }
        }
        /// <summary>
        /// Представление формы списка моделей пунктов меню
        /// </summary>
        public override void ShowAll(List<Model.Model> models)
        {
            if (models.Count > 0)
            {
                int i = 0;
                models.ForEach(obj =>
                {
                    color = i++ == CurrentItem ? Color.OrangeRed : Color.Yellow;
                    model = obj;
                    Show();
                });
            }
        }
    }
}
