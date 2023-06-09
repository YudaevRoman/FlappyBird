﻿using View;
using Model;
using FormView;
using Controller;
using System.Windows.Forms;

namespace FormController
{
    /// <summary>
    /// Форма контроллер окончания игры
    /// </summary>
    public class FormControllerGameOver : ControllerGameOver
    {
        //Конструкторы
        /// <summary>
        /// Конструктор задающий модель и представление формы окончания игры
        /// </summary>
        public FormControllerGameOver(Model.Model model, View.View view) : base(model, view) { }

        //Внешние методы
        /// <summary>
        /// Запуск формы окончания игры
        /// </summary>
        public override void Start() 
        {
            if (view is ViewThread viewThread && model is ModelGameOver)
            {
                viewThread.Start();
            }
        }
        /// <summary>
        /// Обработчик нажатий клавишь
        /// </summary>
        public void OnKey(object sender, KeyPressEventArgs key)
        {
            if (view is FormViewGameOver viewGameOver && model is ModelGameOver modelGameOver)
            {
                switch (key.KeyChar)
                {
                    case (char)13:
                        viewGameOver.Stop();
                        ModelRecords records = new ModelRecords(0, 0, 0, 0, model, 20);
                        string name = viewGameOver.Name;
                        if (!records.Records.Exists(record => 
                        ((ModelRecordLine)record).Name == name && modelGameOver.Score == ((ModelRecordLine)record).Score)) {
                            records.Records.Add(new ModelRecordLine(0, 0, 0, 0, model, name, modelGameOver.Score));
                            records.WriteRecordsToFile();
                        }
                        OnClose();
                        break;
                    case (char)8:
                        if (viewGameOver.Name.Length != 0) 
                            viewGameOver.Name = viewGameOver.Name.Remove(viewGameOver.Name.Length - 1, 1);
                        break;
                    default:
                        viewGameOver.Name = viewGameOver.Name + key.KeyChar;
                        break;
                }
            }
        }
    }
}