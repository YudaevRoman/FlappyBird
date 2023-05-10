
namespace Controller
{
    /// <summary>
    /// Базовый класс контроллера игры
    /// </summary>
    public abstract class ControllerGame : Controller
    {
        //События
        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public event dEventHandler GameOver;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление игры
        /// </summary>
        public ControllerGame(Model.Model model, View.View view) : base(model, view) { }

        //Внутренние методы
        /// <summary>
        /// Вызов события окончания игры
        /// </summary>
        protected void OnGameOver() { GameOver?.Invoke(); }
    }
}
