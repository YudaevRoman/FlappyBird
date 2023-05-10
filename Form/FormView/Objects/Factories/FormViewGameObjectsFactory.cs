using View.Objects;
using View.Objects.Enum;

namespace FormView.Objects.Factories
{
    /// <summary>
    /// Фабрика представление игровых объектов
    /// </summary>
    public class FormViewGameObjectsFactory
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
                    return new FormViewPipe(model);
                case ViewType.BIRD:
                    return new FormViewBird(model);
                case ViewType.WALL:
                    return new FormViewWall(model);
                default: return null;
            }
        }
    }
}
