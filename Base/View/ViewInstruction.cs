using Model;

namespace View
{
    /// <summary>
    /// Базовый класс представления инструкции
    /// </summary>
    public abstract class ViewInstruction : View
    {
        //Поля
        /// <summary>
        /// Текст представления инструкции
        /// </summary>
        protected string text;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления инструкции
        /// </summary>
        public ViewInstruction(Model.Model model) : base(model)
        {
            if (model is ModelInstruction modelInstruction) text = modelInstruction.Text;
            else text = Properties.Resources.NotFound;
        }
    }
}
