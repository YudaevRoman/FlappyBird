using View;
using System.Drawing;
using FormView.Output;

namespace FormView
{
    /// <summary>
    /// Форма представления приложения
    /// </summary>
    public class FormViewApps : ViewApps
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления приложения
        /// </summary>
        public FormViewApps(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public override void Show() 
        { 
            FormViewOutput.Initialization((short)model.Width, (short)model.Height, "FlappyBird", Color.DeepSkyBlue); 
        }
    }
}
