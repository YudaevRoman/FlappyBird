using Model;
using FormView;
using Controller;
using System.Windows.Forms;

namespace FormController
{
    /// <summary>
    /// Форма контроллер таблицы рекордов
    /// </summary>
    public class FormControllerRecords : ControllerRecords
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление формы таблицы рекордов
        /// </summary>
        public FormControllerRecords(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск формы таблицы рекордов
        /// </summary>
        public override void Start() 
        {
            if (view is FormViewRecords viewRecords && model is ModelRecords)
            {
                viewRecords.Show();
            }
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyEventArgs key)
        {
            if (view is FormViewRecords && model is ModelRecords)
            {
                switch (key.KeyCode)
                {
                    case Keys.Escape:
                    case Keys.Enter:
                        OnClose();
                        break;
                }
            }
        }
    }
}
