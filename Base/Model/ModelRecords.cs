using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Модель таблицы рекордов
    /// </summary>
    public class ModelRecords : Model
    {
        //Поля
        /// <summary>
        /// Путь к файлу рекордов
        /// </summary>
        private string path = Properties.Resources.RecordPath;

        //Свойства
        /// <summary>
        /// Список рекордов
        /// </summary>
        public List<Model> Records { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelRecords(int x, int y, int width, int height, Model parent, int heightLine) : base(x, y, width, height, parent)
        {
            Records = new List<Model>();
            if (File.Exists(path))
            {
                int num = 1, score = 0;
                string[] recordsLines = File.ReadAllLines(path);
                foreach (var line in recordsLines)
                {
                    string[] recordItem = line.Split(' ');
                    if (recordItem.Length == 2)
                    {
                        if (Int32.TryParse(recordItem[1], out score))
                        {
                            ModelRecordLine recordLine =
                                new ModelRecordLine(
                                    X + heightLine, Y + num++ * heightLine, Width, heightLine, this,
                                    recordItem[0], score.ToString()
                                    );
                            Records.Add(recordLine);
                        }
                    }
                }
            }
            else { File.Create(path).Close(); }

            DistinctRecords();
        }

        //Внешние методы
        /// <summary>
        /// Удалить повторения в таблице рекордов
        /// </summary>
        public void DistinctRecords()
        {
            for (int i = 0; i < Records.Count - 1; i++)
            {
                if(Records[i] is ModelRecordLine modelRecordLine1)
                {
                    for (int j = i + 1; j < Records.Count; j++)
                    {
                        if(Records[j] is ModelRecordLine modelRecordLine2)
                        if (modelRecordLine1.Name == modelRecordLine2.Name &&
                            modelRecordLine1.Score == modelRecordLine2.Score)
                        {
                            Records.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Записать таблицу рекордов в файл
        /// </summary>
        public void WriteRecordsToFile()
        {
            DistinctRecords();
            var file = File.OpenWrite(path);
            Records.Sort((a, b) => 
            {
                if(b is ModelRecordLine bLine)
                {
                    if(a is ModelRecordLine aLine) return Int32.Parse(bLine.Score) - Int32.Parse(aLine.Score);
                    else return Int32.Parse(bLine.Score) - a.X;
                }
                else return b.X - a.X;
            });
            for (int i = 0; i < Records.Count; i++)
            {
                if(Records[i] is ModelRecordLine modelRecordLine)
                {
                    var line = $"{modelRecordLine.Name} {modelRecordLine.Score}\r\n";
                    var bytes = Encoding.UTF8.GetBytes(line);
                    file.Write(bytes, 0, bytes.Length);
                }
            }
            file.Flush();
            file.Close();
        }
    }
}
