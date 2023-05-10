using System;
using View.Objects;
using ConsoleView.Output;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Базовое представление консольного игрового объекта
    /// </summary>
    public abstract class ConsoleViewGameObject : ViewGameObject
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представление игровго объекта
        /// </summary>
        public ConsoleViewGameObject(Model.Model model) : base(model) { }

        //Внутренние  методы
        /// <summary>
        /// Записать объект в буфер консоли
        /// </summary>
        protected void WriteObject(string objPicture, Model.Model model, ConsoleColor color)
        {
            ConsoleViewOutput.Write(objPicture, model.GetFullX(), model.GetFullY(), model.Width, model.Height, color);
        }
    }
}
