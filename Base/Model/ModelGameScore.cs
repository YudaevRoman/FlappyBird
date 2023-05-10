
namespace Model
{
    /// <summary>
    /// Модель счёта игры
    /// </summary>
    public class  ModelGameScore : Model
    {
        //Свойства
        public string Score { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели счёта игры
        /// </summary>
        public ModelGameScore(int x, int y, int width, int height, Model parent, string score) : base(x, y, width, height, parent) { Score = score; }
    }
}
