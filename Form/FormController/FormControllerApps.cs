using Model;
using FormView;
using Controller;
using FormView.Output;

namespace FormController
{
    /// <summary>
    /// Форма контроллер приложения
    /// </summary>
    public class FormControllerApps : ControllerApps
    {
        //Поля
        /// <summary>
        /// Сущность контроллера
        /// </summary>
        private static FormControllerApps instance;

        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление формы приложения
        /// </summary>
        private FormControllerApps(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск формы приложения
        /// </summary>
        public override void Start()
        {
            if(view is FormViewApps viewApps)
            {
                viewApps.Show();

                ModelMenu menu = new ModelMenu(0, 0, (int)(model.Width * 0.3), 
                    model.Height - (int)(model.Height * 0.5) - 2, model);
                menu.Heading = new ModelMenuHeading((int)(model.Width * 0.33), 2, 
                    (int)(model.Width * 0.3), (int)(model.Height * 0.4), model);
                FormControllerMenu menuController = FormControllerMenu.GetInstance(menu);

                FormViewOutput.Form.KeyDown += menuController.OnKey;
                FormViewOutput.Form.FormClosing += menuController.ParentClose;
                menuController.ItemClose += new dEventHandler(() =>
                {
                    FormViewOutput.Form.KeyPress -= menuController.OnKeyPressItem;
                    FormViewOutput.Form.KeyDown -= menuController.OnKeyDownItem;
                    FormViewOutput.Form.KeyDown += menuController.OnKey;
                });
                menuController.ItemOpen += new dEventHandler(() =>
                {
                    FormViewOutput.Form.KeyDown -= menuController.OnKey;
                    FormViewOutput.Form.KeyDown += menuController.OnKeyDownItem;
                    FormViewOutput.Form.KeyPress += menuController.OnKeyPressItem;
                });
                menuController.Close += new dEventHandler(() =>
                {
                    FormViewOutput.FormClose();
                });

                menuController.Start();
                FormViewOutput.FormRun();
            }
        }

        /// <summary>
        /// Получить сущность контроллера
        /// </summary>
        public static FormControllerApps GetInstance(ModelApps apps)
        {
            if (instance == null) { instance = new FormControllerApps(apps, new FormViewApps(apps)); }

            return instance;
        }
    }
}
