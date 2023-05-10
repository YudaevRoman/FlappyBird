
namespace Model
{
    /// <summary>
    /// Модель инструкции
    /// </summary>
    public class ModelInstruction : Model
    {
        //Свойства
        /// <summary>
        /// Текст инструкции
        /// </summary>
        public string Text { get; } = Properties.Resources.Instruction;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели инструкции
        /// </summary>
        public ModelInstruction(int x, int y, int width, int height, Model parent) : base(x, y, width, height, parent) { }
    }
}
