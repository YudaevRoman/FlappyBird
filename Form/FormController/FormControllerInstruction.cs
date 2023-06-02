using Model;
using FormView;
using Controller;
using System.Windows.Forms;

namespace FormController
{
    /// <summary>
    /// Форма контроллер инструкции
    /// </summary>
    public class FormControllerInstruction : ControllerInstruction
    {
        //Конструктор
        /// <summary>
        /// Конструктор задающий модель и представление формы инструкции
        /// </summary>
        public FormControllerInstruction(Model.Model model, View.View view) : base(model, view) { }

        //Внешнией метод
        /// <summary>
        /// Запуск формы инструкции
        /// </summary>
        public override void Start() { 
            if (view is FormViewInstruction viewInstruction && model is ModelInstruction) viewInstruction.Show(); 
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyEventArgs key)
        {
            if (view is FormViewInstruction && model is ModelInstruction)
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
