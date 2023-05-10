
namespace Model
{
    /// <summary>
    /// Модель линии рекордов таблицы
    /// </summary>
    public class ModelRecordLine : Model
    {
        //Свойства
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Счёт игрока
        /// </summary>
        public string Score { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий 
        /// </summary>
        /// <param name="name">Имя игрока</param>
        /// <param name="score">Счёт игрока</param>
        public ModelRecordLine(int x, int y, int width, int height, Model parent, string name, string score)
            : base(x, y, width, height, parent)
        { 
            Name = name; 
            Score = score; 
        }
    }
}
