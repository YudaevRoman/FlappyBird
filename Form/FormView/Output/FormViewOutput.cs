using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FormView.Output
{
    /// <summary>
    /// Вывод представлений консоли
    /// </summary>
    public class FormViewOutput
    {
        //Поля
        /// <summary>
        /// Шрифт выводимого текст
        /// </summary>
        private static Font font;
        /// <summary>
        /// Заливка для рисования
        /// </summary>
        private static Brush brush;
        /// <summary>
        /// Поле рисования
        /// </summary>
        private static BufferedGraphics bufferedGraphics;
        /// <summary>
        /// Поля ширины и высоты выводимой области
        /// </summary>
        private static int width, height;
        /// <summary>
        /// Форма вывода
        /// </summary>
        private static Form form;
        /// <summary>
        /// Фон формы
        /// </summary>
        private static Color backColor;

        //Свойства
        /// <summary>
        /// Доступ к форме
        /// </summary>
        public static Form Form { get { return form; } }
        /// <summary>
        /// Блокироващик потоков
        /// </summary>
        public static object Locker { get; } = new object();

        //Внешние методы
        /// <summary>
        /// Запустить отображение формы
        /// </summary>
        public static void FormRun() { if(form != null) Application.Run(form); }
        /// <summary>
        /// Завершить отображение формы
        /// </summary>
        public static void FormClose() 
        {
            if (Application.OpenForms.Count > 0)
            {
                Application.Exit();
                form = null;
            }
        }
        /// <summary>
        /// Метод инициализации
        /// </summary>
        public static void Initialization(short _width, short _height, string name, Color color)
        {
            width = _width;
            height = _height;
            backColor = color;
            font = new Font(FontFamily.GenericMonospace, 12);
            if (Application.OpenForms.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                form = new Form();
            }
            else { form = Application.OpenForms[0]; }
            form.MaximumSize = new Size(width, height);
            form.Size = new Size(width, height);
            form.Name = name;
            form.Text = name;
            form.Font = font;
            lock (Locker) bufferedGraphics = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), form.ClientRectangle);
        }
        /// <summary>
        /// Вывести строку в буфер
        /// </summary>
        public static void DrawString(string str, StringFormat format, int x, int y, int _width, int _height, Color color)
        {
            if (Application.OpenForms.Count > 0)
            {
                SizeNormaliz(x, y, ref _width, ref _height);
                brush = new SolidBrush(color);
                lock (Locker) bufferedGraphics.Graphics.DrawString(str, font, brush, new Rectangle(x, y, _width, _height), format);
            }
        }
        /// <summary>
        /// Вывести прямоугольник в буфер
        /// </summary>
        public static void DrawRect(int x, int y, int _width, int _height, Color color)
        {
            if (Application.OpenForms.Count > 0)
            {
                SizeNormaliz(x, y, ref _width, ref _height);
                brush = new SolidBrush(color);
                lock (Locker) bufferedGraphics.Graphics.FillRectangle(brush, new Rectangle(x, y, _width, _height));
            }
        }
        /// <summary>
        /// Вывести строку в прямоугольнике в буфер
        /// </summary>
        public static void DrawStringInRect(string str, StringFormat format, int x, int y, int _width, int _height, Color color)
        {
            if (Application.OpenForms.Count > 0)
            {
                SizeNormaliz(x, y, ref _width, ref _height);
                brush = new SolidBrush(color);
                lock (Locker) bufferedGraphics.Graphics.FillRectangle(brush, new Rectangle(x, y, _width, _height));
                lock (Locker) bufferedGraphics.Graphics.DrawString(str, font, Brushes.Black, new Rectangle(x, y, _width, _height), format);
            }
        }
        /// <summary>
        /// Вывести изображения в прямоугольнике
        public static void DrawImage(int x, int y, int _width, int _height, Image image)
        {
            if (Application.OpenForms.Count > 0)
            {
                SizeNormaliz(x, y, ref _width, ref _height);
                lock (Locker) bufferedGraphics.Graphics.DrawImage(image, new Rectangle(x, y, _width, _height));
            }
        }
        /// <summary>
        /// Вывести буфер на форму
        /// </summary>
        public static void ShowBuf()
        {
            if (Application.OpenForms.Count > 0)
            {
                lock (Locker) bufferedGraphics.Render();
                lock (Locker) bufferedGraphics.Graphics.Clear(backColor);
            }
        }

        //Внутренние методы
        /// <summary>
        /// Нормализация размера объектов (объекты с 0-ым размером занимают всю область родителя)
        /// </summary>
        private static void SizeNormaliz(int x, int y, ref int _width, ref int _height)
        {
            if (_width == 0) _width = width - x;
            if (_height == 0) _height = height - y;
        }
    }
}
