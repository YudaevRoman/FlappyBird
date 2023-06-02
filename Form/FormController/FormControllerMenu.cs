using Model;
using FormView;
using Controller;
using System.Windows.Forms;

namespace FormController
{
    /// <summary>
    /// Форма контроллер меню
    /// </summary>
    public class FormControllerMenu : ControllerMenu
    {
        //События
        /// <summary>
        /// Открыт пункт меню
        /// </summary>
        public event dEventHandler ItemOpen;
        /// <summary>
        /// Закрыт пункт меню
        /// </summary>
        public event dEventHandler ItemClose;
        /// <summary>
        /// Нажатие клавиши в пункте меню
        /// </summary>
        public event KeyEventHandler KeyDownItem;
        /// <summary>
        /// Отслеживание ввода символов
        /// </summary>
        public event KeyPressEventHandler KeyPressItem;

        //Поля
        /// <summary>
        /// Сущность контроллера
        /// </summary>
        private static FormControllerMenu instance;
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

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление формы меню
        /// </summary>
        private FormControllerMenu(Model.Model _model, View.View _view) : base(_model, _view)
        {
            if (view is FormViewMenu viewMenu && model is ModelMenu modelMenu)
            {
                int i = 0;
                int height = (int)(model.Height * 0.1575), offset = (int)(model.Height * 0.075);

                modelMenu.Items.Add(
                    new ModelMenuItem(0, i, model.Width, height, model, PLAY, () =>
                    {
                        ModelGame game = new ModelGame(0, 30, model.Parent.Width, model.Parent.Height - 30, model.Parent, 30);
                        FormControllerGame gameController = new FormControllerGame(game, new FormViewGame(game));
                        KeyDownItem += gameController.OnKey;
                        bool isGameOver = false;
                        game.GameOver += new ModelGame.dEventHandler(() =>
                        {
                            isGameOver = true;
                            KeyDownItem -= gameController.OnKey;
                            ModelGameOver gameOver = new ModelGameOver(0, 0, 
                                model.Parent.Width - 3, model.Parent.Height - 2, model.Parent, game.Score);
                            FormControllerGameOver gameOverController = new FormControllerGameOver(
                                gameOver, new FormViewGameOver(gameOver));
                            KeyPressItem += gameOverController.OnKey;
                            gameOverController.Close += new dEventHandler(() =>
                            {
                                KeyPressItem -= gameOverController.OnKey;
                                ItemClose?.Invoke();
                                isGameOver = false;
                                viewMenu.Start();
                            });
                            gameOverController.Start();
                        });
                        gameController.Close += new dEventHandler(() =>
                        {
                            if (!isGameOver)
                            {
                                KeyDownItem -= gameController.OnKey;
                                ItemClose?.Invoke();
                                viewMenu.Start();
                            }
                        });
                        gameController.Start();
                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, RECORDS, () =>
                    {
                        ModelRecords records = new ModelRecords(0, 0, model.Parent.Width - 2, model.Parent.Height - 2, 
                            model.Parent, 20);
                        FormControllerRecords recordsController = new FormControllerRecords(records, 
                            new FormViewRecords(records));
                        KeyDownItem += recordsController.OnKey;
                        recordsController.Close += new dEventHandler(() =>
                        {
                            KeyDownItem -= recordsController.OnKey;
                            ItemClose?.Invoke();
                            viewMenu.Start();
                        });
                        recordsController.Start();
                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, INSTRUCTION, 
                    () => {
                        ModelInstruction instruction = new ModelInstruction(0, 0, model.Parent.Width - 2, 
                            model.Parent.Height - 2, model.Parent);
                        FormControllerInstruction instructionController = new FormControllerInstruction(instruction, 
                            new FormViewInstruction(instruction));
                        KeyDownItem += instructionController.OnKey;
                        instructionController.Close += new dEventHandler(() =>
                        {
                            KeyDownItem -= instructionController.OnKey;
                            ItemClose?.Invoke();
                            viewMenu.Start();
                        });
                        instructionController.Start();

                    }));

                modelMenu.Items.Add(
                    new ModelMenuItem(0, modelMenu.Items[i++].Y + height + offset, model.Width, height, model, EXIT, () =>
                    {
                        OnClose();
                    }));
            }
        }

        //Внешние методы
        /// <summary>
        /// Запуск формы меню
        /// </summary>
        public override void Start()
        {
            if (view is FormViewMenu viewMenu && model is ModelMenu)
            {
                viewMenu.Start();
            }
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyEventArgs key)
        {
            if (view is FormViewMenu viewMenu && model is ModelMenu modelMenu)
            {
                switch (key.KeyCode)
                {
                    case Keys.Enter:
                        viewMenu.Stop();
                        ItemOpen?.Invoke();
                        modelMenu.Action();
                        break;
                    case Keys.Up:
                        modelMenu.CurrentItem--;
                        break;
                    case Keys.Down:
                        modelMenu.CurrentItem++;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Метод передачи нажатых клавиш в пункты меню
        /// </summary>
        public void OnKeyDownItem(object sender, KeyEventArgs key) { KeyDownItem?.Invoke(sender, key); }
        /// <summary>
        /// Метод передачи символов в пункты меню
        /// </summary>
        public void OnKeyPressItem(object sender, KeyPressEventArgs key) { KeyPressItem?.Invoke(sender, key); }
        /// <summary>
        /// Получить сущность контроллера
        /// </summary>
        public static FormControllerMenu GetInstance(ModelMenu menu)
        {
            if (instance == null) { instance = new FormControllerMenu(menu, new FormViewMenu(menu)); }

            return instance;
        }
        /// <summary>
        /// Обработка события закрытия родительской формы
        /// </summary>
        public void ParentClose(object sender, FormClosingEventArgs e)
        {
            if (view is FormViewMenu viewMenu && model is ModelMenu )
            {
                viewMenu.Stop();
            }
            OnClose();
        }
    }
}