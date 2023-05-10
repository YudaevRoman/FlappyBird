
namespace Model
{
    /// <summary>
    /// Модель окончания игры
    /// </summary>
    public class ModelGameOver : Model
    {
        //Свойства
        /// <summary>
        /// Текст окончания игры
        /// </summary>
        public string Text { get; } = Properties.Resources.GameOver;
        /// <summary>
        /// Счёт игрока
        /// </summary>
        public string Score { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели окончания игры
        /// </summary>
        public ModelGameOver(int x, int y, int width, int height, Model parent, string score) : base(x, y, width, height, parent) { Score = score; }
    }
}
