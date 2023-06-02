using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ConsoleView.Output
{
    /// <summary>
    /// Вывод представлений консоли
    /// </summary>
    public class ConsoleViewOutput
    {
        //Поля
        /// <summary>
        /// Поле буфера вывода
        /// </summary>
        private static CharInfo[,] buf;
        /// <summary>
        /// Поле задания области вывода
        /// </summary>
        private static SmallRect rect;
        /// <summary>
        /// Поля ширины и высоты выводимой области
        /// </summary>
        private static short width, height;
        /// <summary>
        /// Поле дескриптора консоли
        /// </summary>
        private static SafeFileHandle h;

        //Свойства
        /// <summary>
        /// Свойство проверки существования дескриптора консоли
        /// </summary>
        public static bool IsHandle { get; set; } = false;

        //Подключение методов для работы с консолью библиотеки KERNEL32
        /// <summary>
        /// Метод открытия файла (буфера консоли)
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="fileAccess">Режим доступа</param>
        /// <param name="fileShare">Совместный доступ</param>
        /// <param name="securityAttributes">SD (дескр. защиты)</param>
        /// <param name="creationDisposition">Как действовать</param>
        /// <param name="flags">Атрибуты файла</param>
        /// <param name="template">Дескр.шаблона файла</param>
        /// <returns>Возвращает класс-оболочку для дескриптора файла</returns>
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
           string fileName,
           [MarshalAs(UnmanagedType.U4)] uint fileAccess,
           [MarshalAs(UnmanagedType.U4)] uint fileShare,
           IntPtr securityAttributes,
           [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
           [MarshalAs(UnmanagedType.U4)] int flags,
           IntPtr template);
        /// <summary>
        /// Записывает символ и данные атрибута цвета в заданном прямоугольном блоке 
        /// символьных знакомест в экранном буфере консоли
        /// </summary>
        /// <param name="hConsoleOutput">Дескриптор экранного буфера</param>
        /// <param name="lpBuffer">Буфер данных</param>
        /// <param name="dwBufferSize">Размер буфера данных</param>
        /// <param name="dwBufferCoord">Координаты ячейки</param>
        /// <param name="lpWriteRegion">Область записи</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        //Структуры
        /// <summary>
        /// Структура координат консоли
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            //Поля
            /// <summary>
            /// Координата X
            /// </summary>
            public short X;
            /// <summary>
            /// Координата Y
            /// </summary>
            public short Y;
        };
        /// <summary>
        /// Хранения символа в Юникоде и в Аски кодировках
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            //Поля
            /// <summary>
            /// Символ в Юникоде
            /// </summary>
            [FieldOffset(0)] public char UnicodeChar;
            /// <summary>
            /// Символ в Аски коде
            /// </summary>
            [FieldOffset(0)] public byte AsciiChar;
        }
        /// <summary>
        /// Хранения символа и его атрибутов
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            //Поля
            /// <summary>
            /// Символ
            /// </summary>
            [FieldOffset(0)] public CharUnion Char;
            /// <summary>
            /// Атрибуты символа
            /// </summary>
            [FieldOffset(2)] public short Attributes;
        }
        /// <summary>
        /// Хранение области
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            //Поля
            /// <summary>
            /// Левый край
            /// </summary>
            public short Left;
            /// <summary>
            /// Верхний край
            /// </summary>
            public short Top;
            /// <summary>
            /// Правый край
            /// </summary>
            public short Right;
            /// <summary>
            /// Нижний край
            /// </summary>
            public short Bottom;
        }

        //Внешние методы
        /// <summary>
        /// Метод инициализации
        /// </summary>
        public static void Initialization(short _width, short _height)
        {
            h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            IsHandle = !h.IsInvalid;
            if (IsHandle)
            {
                width = _width;
                height = _height;
                Console.CursorVisible = false;
                Console.SetWindowSize(width, height);
                Console.SetBufferSize(width, height);
                buf = new CharInfo[height, width];
                rect = new SmallRect() { Left = 0, Top = 0, Right = width, Bottom = height };
            }
        }

        /// <summary>
        /// Вывести строку в буфер на позиции с заданным цветом
        /// </summary>
        public static void Write(string str, int x, int y, int _width, int _height, ConsoleColor color)
        {
            if (IsHandle)
            {
                var bytes = Console.OutputEncoding.GetBytes(str);
                int offsetX = 0;
                int offsetY = 0;
                byte previousByte = 0;

                if (_width == 0) _width = width - x;
                if (_height == 0) _height = height - y;

                foreach (var item in bytes)
                {
                    if (x + offsetX >= x + _width || item == 10 && previousByte == 13 || item == '\n')
                    {
                        offsetY++;
                        offsetX = 0;
                    }
                    if (item < 20)
                    {
                        previousByte = item;
                        continue;
                    }
                    if (y >= 0 && x + offsetX >= 0 && x + offsetX < width && y + offsetY < height)
                    {
                        buf[y + offsetY, x + offsetX].Attributes = (byte)color;
                        buf[y + offsetY, x + offsetX].Char.AsciiChar = item;
                    }
                    offsetX++;
                    previousByte = item;
                }
            }
        }
        /// <summary>
        /// Очистка буфера
        /// </summary>
        public static void Clear() { if (IsHandle) buf = new CharInfo[height, width]; }
        /// <summary>
        /// Вывести буфер на консоль
        /// </summary>
        public static void PrintOnConsole()
        {
            if (IsHandle)
            {
                WriteConsoleOutput(h, buf.Cast<CharInfo>().ToArray(),
                  new Coord() { X = width, Y = height },
                  new Coord() { X = 0, Y = 0 },
                  ref rect);
            }
        }
        /// <summary>
        /// Управление видимостью курсора консоли
        /// </summary>
        public static void CursorVisible(bool cursorVisible)
        {
            Console.CursorVisible = cursorVisible;
        }
        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
