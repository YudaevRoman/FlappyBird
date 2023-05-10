using View;
using Model;
using System;
using ConsoleView.Output;
using System.Collections.Generic;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление линии рекорда таблицы
    /// </summary>
    public class ConsoleViewRecordLine : ViewRecordLine
    {
        //Конструкторы
        public ConsoleViewRecordLine(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной линии рекорда таблицы
        /// </summary>
        public override void Show()
        {
            if(model is ModelRecordLine modelRecordLine)
            {
                ConsoleViewOutput.Write(
                    modelRecordLine.Name,
                    modelRecordLine.GetFullX(), modelRecordLine.GetFullY(),
                    (int)(modelRecordLine.Width * 0.5), modelRecordLine.Height,
                    ConsoleColor.White);
                ConsoleViewOutput.Write(
                    modelRecordLine.Score,
                    modelRecordLine.GetFullX() + (int)(modelRecordLine.Width * 0.5), modelRecordLine.GetFullY(),
                    (int)(modelRecordLine.Width * 0.5), modelRecordLine.Height,
                    ConsoleColor.White);
            }
        }
        /// <summary>
        /// Представление консольного списка моделей линий рекордов таблицы
        /// </summary>
        public override void ShowAll(List<Model.Model> models) { if (models.Count > 0) { models.ForEach(obj => { model = obj; Show(); }); } }
    }
}
