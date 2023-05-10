using System;
using Model.Objects;
using Model.Objects.Factories;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class ModelGame : Model
    {
        //Делегаты
        /// <summary>
        /// Делегат игровых событий
        /// </summary>
        public delegate void dEventHandler();

        //События
        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public event dEventHandler GameOver;

        //Поля
        /// <summary>
        /// Счёт игрока
        /// </summary>
        private ModelGameScore score;
        /// <summary>
        /// Колво объектов в строке и столбце
        /// </summary>
        private int countX, countY;

        //Свойства
        /// <summary>
        /// Блокировщик потоков
        /// </summary>
        public object Locker { get; set; } = new object();
        /// <summary>
        /// Счёт игрока
        /// </summary>
        public string Score 
        {
            get { return score.Score; }
            set { score.Score = value;  }
        }
        /// <summary>
        /// Размер игровых объектов
        /// </summary>
        public int GameObjectsSize { get; set; }
        /// <summary>
        /// Модель птицы
        /// </summary>
        public ModelBird Bird { get; set; }
        /// <summary>
        /// Список стен (грани игрового поля)
        /// </summary>
        public List<Model> Walls { get; set; } = new List<Model>();
        /// <summary>
        /// Список труб
        /// </summary>
        public List<Model> Pipes { get; set; } = new List<Model>();
        /// <summary>
        /// Фабрика труб
        /// </summary>
        public ModelPipesFactory PipesFactory { get; set; }

        //Конструкторы
        /// <summary>
        /// Конструктор задающий координаты, размеры и модель родителя модели игры
        /// </summary>
        public ModelGame(int x, int y, int width, int height, Model parent, int _gameObjectsSize) : base(x, y, width, height, parent)
        {
            GameObjectsSize = _gameObjectsSize;
            countX = (int)(Width / GameObjectsSize); 
            countY = (int)(Height / GameObjectsSize);
            if (countX * GameObjectsSize + GameObjectsSize > Width) countX--;
            if (countY * GameObjectsSize + GameObjectsSize > Height) countY--;
            PipesFactory = new ModelPipesFactory((countX - 2) * GameObjectsSize, GameObjectsSize, this, GameObjectsSize);
            score = new ModelGameScore(X + (int)(countX * 0.5) * GameObjectsSize, Y - GameObjectsSize, (int)(countX * 0.5) * GameObjectsSize, GameObjectsSize, parent, 0.ToString());
            Bird = new ModelBird((int)(countX * 0.15 ) * GameObjectsSize, (int)(countY * 0.5 ) * GameObjectsSize, GameObjectsSize, GameObjectsSize, this);
            Bird.Step = GameObjectsSize;
            InitializationWalls();
        }

        //Внешние методы
        /// <summary>
        /// Проверка окончания игры
        /// </summary>
        public bool GameOverCheck()
        {
            if (CollisionCheck()) { GameOver?.Invoke();  return true; }

            return false;
        }
        /// <summary>
        /// Проверка пересечения птицы и списка труб
        /// </summary>
        public bool PipeCrossing()
        {
            lock (Locker) foreach (var obj in Pipes) 
                {  
                    if (obj is ModelPipe pipe && pipe.Crossing(Bird)) { return true; }  
                }

            return false;
        }
        /// <summary>
        /// Получить модель счёта игрока
        /// </summary>
        public Model GetModelScore() { return score; }

        //Внутренние методы
        /// <summary>
        /// Метод инициализации стен (границ) игровой области
        /// </summary>
        private void InitializationWalls()
        {
            Walls.Clear();
            InitializationVerticalWalls(0, countY - 1);
            InitializationHorizontalWalls(countX, 0);
            InitializationVerticalWalls(Walls[Walls.Count - 1].X, countY - 1);
            InitializationHorizontalWalls(countX, Walls[Walls.Count - 1].Y);
        }
        /// <summary>
        /// Инициализация горизонтальных стен
        /// </summary>
        private void InitializationHorizontalWalls(int maxX, int y)
        {
            for (int i = 0; i < maxX; i++)
                Walls.Add(new ModelWall(i * GameObjectsSize, y, GameObjectsSize, GameObjectsSize, this));
        }
        /// <summary>
        /// Инициализации вертикальных стен
        /// </summary>
        private void InitializationVerticalWalls(int x, int maxY)
        {
            for (int j = 0; j < maxY; j++)
                Walls.Add(new ModelWall(x, j * GameObjectsSize, GameObjectsSize, GameObjectsSize, this));
        }
        /// <summary>
        /// Проверка столкновения птицы и игровых препятствий
        /// </summary>
        private bool CollisionCheck()
        {
            lock (Locker) foreach (var obj in Pipes)
                {
                    if (obj is ModelPipe pipe && pipe.Compare(Bird)) { return true; }
                }
            lock (Locker) foreach (var obj in Walls)
                {
                    if (obj is ModelWall wall && wall.Compare(Bird)) { return true; }
                }
            return false;
        }
    }
}
