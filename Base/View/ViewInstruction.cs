using Model;

namespace View
{
    /// <summary>
    /// Базовый класс представления инструкции
    /// </summary>
    public abstract class ViewInstruction : View
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель представления инструкции
        /// </summary>
        public ViewInstruction(Model.Model model) : base(model) { }
    }
}
