using View;
using Model;
using System.Drawing;
using FormView.Output;
using System.Collections.Generic;

namespace FormView
{
    /// <summary>
    /// Форма представление линии рекорда таблицы
    /// </summary>
    public class FormViewRecordLine : ViewRecordLine
    {
        //Конструкторы
        public FormViewRecordLine(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы линии рекорда таблицы
        /// </summary>
        public override void Show()
        {
            if (model is ModelRecordLine modelRecordLine)
            {
                FormViewOutput.DrawString(
                    modelRecordLine.Name,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Near
                    },
                    modelRecordLine.GetFullX(), modelRecordLine.GetFullY(),
                    (int)(modelRecordLine.Width * 0.5), modelRecordLine.Height,
                    Color.White);
                FormViewOutput.DrawString(
                    modelRecordLine.Score,
                    new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Near
                    },
                    modelRecordLine.GetFullX() + (int)(modelRecordLine.Width * 0.5), modelRecordLine.GetFullY(),
                    (int)(modelRecordLine.Width * 0.5), modelRecordLine.Height,
                    Color.White);
            }
        }
        /// <summary>
        /// Представление формы списка моделей линий рекордов таблицы
        /// </summary>
        public override void ShowAll(List<Model.Model> models) 
        { 
            if (models.Count > 0) 
            { 
                models.ForEach(obj => 
                { 
                    model = obj; 
                    Show(); 
                }); 
            } 
        }
    }
}
