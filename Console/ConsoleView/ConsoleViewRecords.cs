using View;
using Model;
using ConsoleView.Output;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление таблицы рекордов
    /// </summary>
    public class ConsoleViewRecords : ViewRecords
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель консольного представления таблицы рекордов
        /// </summary>
        public ConsoleViewRecords(Model.Model model) : base(model) { }

        //Внешние методы
        /// <summary>
        /// Представление консольной таблицы рекордов
        /// </summary>
        public override void Show()
        {
            if(model is ModelRecords modelRecords)
            {
                ConsoleViewRecordLine view = new ConsoleViewRecordLine(null);
                ConsoleViewOutput.Clear();
                modelRecords.Records.Insert(0, new ModelRecordLine(0, 0, model.Width, model.Height, model, "Игрок", "Очки"));
                view.ShowAll(modelRecords.Records);
                modelRecords.Records.RemoveAt(0);
                ConsoleViewOutput.PrintOnConsole();
            }
        }
    }
}
