using View;
using Model;
using FormView.Output;

namespace FormView
{
    /// <summary>
    /// Форма представление таблицы рекордов
    /// </summary>
    public class FormViewRecords : ViewRecords
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель формы представления таблицы рекордов
        /// </summary>
        public FormViewRecords(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление формы таблицы рекордов
        /// </summary>
        public override void Show()
        {
            if (model is ModelRecords modelRecords)
            {
                FormViewRecordLine view = new FormViewRecordLine(null);
                modelRecords.Records.Insert(0, new ModelRecordLine(0, 0, model.Width, model.Height, model, "Игрок", "Очки"));
                view.ShowAll(modelRecords.Records);
                FormViewOutput.ShowBuf();
                modelRecords.Records.RemoveAt(0);
            }
        }
    }
}
