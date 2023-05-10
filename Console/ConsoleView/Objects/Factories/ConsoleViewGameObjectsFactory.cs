using View.Objects;
using View.Objects.Enum;

namespace ConsoleView.Objects.Factories
{
    /// <summary>
    /// Фабрика представление игровых объектов
    /// </summary>
    public class ConsoleViewGameObjectsFactory
    {
        //Внешние методы
        /// <summary>
        /// Метод создания представления для игрового объекта
        /// </summary>
        public ViewGameObject CreateView(ViewType type, Model.Model model)
        {
            switch (type)
            {
                case ViewType.PIPE:
                    return new ConsoleViewPipe(model);
                case ViewType.BIRD:
                    return new ConsoleViewBird(model);
                case ViewType.WALL:
                    return new ConsoleViewWall(model);
                default: return null;
            }
        }
    }
}
