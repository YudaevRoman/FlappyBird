using View;
using Model;
using System;
using Controller;
using ConsoleView;

namespace ConsoleController
{
    /// <summary>
    /// Консольный контроллер меню
    /// </summary>
    public class ConsoleControllerMenu : ControllerMenu
    {
        //Поля
        /// <summary>
        /// Сущность контроллера
        /// </summary>
        private static ConsoleControllerMenu instance;
        /// <summary>
        /// Текст пункта игра
        /// </summary>
        private const string PLAY = "Играть";
        /// <summary>
        /// Текст пункта рекорды
        /// </summary>
        private const string RECORDS = "Таблица рекордов";
        /// <summary>
        /// Текст пункта инструкции
        /// </summary>
        private const string INSTRUCTION = "Инструкция";
        /// <summary>
        /// Текст пункта выход
        /// </summary>
        private const string EXIT = "Выход";
        /// <summary>
        /// Флаг работы меню
        /// </summary>
        private bool isMenu;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление консольного меню
        /// </summary>
        private ConsoleControllerMenu(Model.Model _model, View.View _view) : base(_model, _view)
        {
            if(model is ModelMenu modelMenu)
            {
                int i = 0;
                int height = (int)(model.Height * 0.1575), offset = (int)(model.Height * 0.075);

                modelMenu.Items.Add(
                    new ModelMenuItem(0, i, model.Width, height, model, PLAY, () =>
                    {
                        ModelGame _model_ = new ModelGame(2, 1, model.Parent.Width - 3, model.Parent.Height - 2, model.Parent, 1);
                        ConsoleControllerGame controller = new ConsoleControllerGame(_model_, new ConsoleViewGame(_model_));
                        controller.GameOver += new dEventHandler(() =>
                        {
                            ModelGameOver __model_ = new ModelGameOver(2, 1, model.Parent.Width - 3, 1, model.Parent, _model_.Score);
                            ConsoleControllerGameOver controllerGameOver = new ConsoleControllerGameOver(__model_, new ConsoleViewGameOver(__model_));
                            controllerGameOver.Start();
                        });
                        controller.Start();
                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, RECORDS, () =>
                    {
                        ModelRecords _model_ = new ModelRecords(2, 1, model.Parent.Width - 2, model.Parent.Height - 2, model.Parent, 1);
                        ConsoleControllerRecords recordsConsole = new ConsoleControllerRecords(_model_, new ConsoleViewRecords(_model_));
                        recordsConsole.Start();
                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, INSTRUCTION, () =>
                    {
                        ModelInstruction _model_ = new ModelInstruction(2, 1, model.Parent.Width - 2, model.Parent.Height - 2, model.Parent);
                        ConsoleControllerInstruction instructionConsole = new ConsoleControllerInstruction(_model_, new ConsoleViewInstruction(_model_));
                        instructionConsole.Start();
                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, EXIT, () =>
                    {
                        isMenu = false;
                    }));
            }
        }

        //Внешние методы
        /// <summary>
        /// Запуск консольного меню
        /// </summary>
        public override void Start()
        {
            if (view is ConsoleViewMenu viewMenu)
            {
                if (model is ModelMenu modelMenu)
                {
                    viewMenu.Start();
                    isMenu = true;
                    while (isMenu)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.Enter:
                                viewMenu.Stop();
                                modelMenu.Action();
                                if (isMenu) viewMenu.Start();
                                break;
                            case ConsoleKey.UpArrow:
                                modelMenu.CurrentItem--;
                                break;
                            case ConsoleKey.DownArrow:
                                modelMenu.CurrentItem++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Получить сущность контроллера
        /// </summary>
        public static ConsoleControllerMenu GetInstance(ModelMenu _model)
        {
            if (instance == null) { instance = new ConsoleControllerMenu(_model, new ConsoleViewMenu(_model)); }

            return instance;
        }
    }
}
