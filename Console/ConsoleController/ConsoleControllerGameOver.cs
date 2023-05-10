using View;
using Model;
using System;
using Controller;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер окончания игры
    /// </summary>
    public class ConsoleControllerGameOver : ControllerGameOver
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление консольного окончания игры
        /// </summary>
        public ConsoleControllerGameOver(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск консольного окончания игры
        /// </summary>
        public override void Start()
        {
            if (view is ViewThread viewThread)
            {
                if (model is ModelGameOver modelGameOver)
                {
                    viewThread.Start();
                    ModelRecords records = new ModelRecords(0, 0, 0, 0, model, 1);
                    string name = Console.ReadLine();
                    if (!records.Records.Exists(record => ((ModelRecordLine)record).Name == name && modelGameOver.Score == ((ModelRecordLine)record).Score))
                    {
                        records.Records.Add(new ModelRecordLine(0, 0, 0, 0, model, name, modelGameOver.Score));
                        records.WriteRecordsToFile();
                    }
                    OnClose();
                }
            }
        }
    }
}
