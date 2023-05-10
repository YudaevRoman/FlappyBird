using Model.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFlappuBird
{
    [TestClass]
    public class TestModelPipe
    {
        /// <summary>
        /// Тест инициализации модели трубы
        /// </summary>
        [TestMethod]
        public void TestModelGame()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            Assert.IsNotNull(pipe.Body);
            Assert.IsNotNull(pipe.Voids);
        }
        /// <summary>
        /// Тест проверки шага на нулевое значение при инициализации
        /// </summary>
        [TestMethod]
        public void TestStepInit()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            Assert.AreNotEqual(0, pipe.Step);
        }
        /// <summary>
        /// Тест проверки шага на нулевое значение при явном указании
        /// </summary>
        [TestMethod]
        public void TestStepIndicate()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            pipe.Step = 0;

            Assert.AreNotEqual(0, pipe.Step);
        }
        /// <summary>
        /// Тест проверки длины пустот на нулевое значение при инициализации
        /// </summary>
        [TestMethod]
        public void TestVoidLenghtInit()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            Assert.AreNotEqual(0, pipe.VoidLength);
        }
        /// <summary>
        /// Тест проверки длины пустот на нулевое значение при явном указании
        /// </summary>
        [TestMethod]
        public void TestVoidLenghtIndicate()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            pipe.VoidLength = 0;

            Assert.AreNotEqual(0, pipe.VoidLength);
        }
        /// <summary>
        /// Тест проверки координаты X компонентов тела трубы
        /// </summary>
        [TestMethod]
        public void TestPosX()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            int X1 = pipe.Body[0].X;
            int X2 = pipe.Voids[0].X;

            foreach (Model.Model obj in pipe.Body)
            {
                Assert.AreEqual(obj.X, X1);
            }

            foreach (Model.Model obj in pipe.Voids)
            {
                Assert.AreEqual(obj.X, X2);
            }
        }
        /// <summary>
        /// Тест проверки координаты Y компонентов тела трубы
        /// </summary>
        [TestMethod]
        public void TestPosY()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            int Height1 = pipe.Body[0].Height;
            int Height2 = pipe.Body[0].Height;

            for (int j = 0; j < pipe.Body.Count - 2; j++)
            {
                Assert.AreEqual(pipe.Body[j].Y + Height1, pipe.Body[j + 1].Y);
            }
            for (int j = 0; j < pipe.Voids.Count - 2; j++)
            {
                Assert.AreEqual(pipe.Body[j].Y + Height2, pipe.Body[j + 1].Y);
            }
        }
        /// <summary>
        /// Тест проверки выхода компонентов за пределы трубы
        /// </summary>
        [TestMethod]
        public void TestOutside()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            foreach(Model.Model obj in pipe.Body)
            {
                Assert.AreEqual(obj.X + obj.Width, pipe.Width);
                Assert.IsTrue(obj.Y + obj.Height <= pipe.Height);
            }
            foreach (Model.Model obj in pipe.Voids)
            {
                Assert.AreEqual(obj.X + obj.Width, pipe.Width);
                Assert.IsTrue(obj.Y + obj.Height <= pipe.Height);
            }
        }
        /// <summary>
        /// Тест проверки соответствия пустых компонентов и не пустых
        /// </summary>
        [TestMethod]
        public void TestCompareVoidsAndBody()
        {
            ModelPipe pipe = new ModelPipe(0, 0, 2, 20, null, 3);

            bool isCompare = false;
            foreach(ModelGameObject obj in pipe.Voids)
            {
                pipe.Body.ForEach(_obj =>
                {
                    if (obj.Compare(_obj)) isCompare = true;
                });

                Assert.IsTrue(isCompare);
            }
        }
        /// <summary>
        /// Тест проверки целостности трубы после движения
        /// </summary>
        [TestMethod]
        public void TestMove()
        {
            ModelPipe pipe = new ModelPipe(10, 0, 2, 20, null, 3);

            pipe.Step = 5;

            pipe.Move();

            int X1 = pipe.Body[0].GetFullX();
            int X2 = pipe.Voids[0].GetFullX();

            foreach (Model.Model obj in pipe.Body)
            {
                Assert.AreEqual(obj.GetFullX(), X1);
            }

            foreach (Model.Model obj in pipe.Voids)
            {
                Assert.AreEqual(obj.GetFullX(), X2);
            }
        }
        /// <summary>
        /// Тест проверки столкновения трубы и птицы
        /// </summary>
        [TestMethod]
        public void TestCompareGameObjectAndPipe()
        {
            ModelPipe pipe = new ModelPipe(10, 0, 1, 20, null, 0);

            pipe.Step = 5;

            ModelBird bird = new ModelBird(5, 15, 1, 1, null);

            Assert.IsFalse(pipe.Compare(bird));

            pipe.Move();

            Assert.IsTrue(pipe.Compare(bird));

            pipe.X = 10;

            bird.Y = 0;

            pipe.Move();

            Assert.IsFalse(pipe.Compare(bird));
        }
        /// <summary>
        /// Тест проверки пересечения трубы и игрового объекта
        /// </summary>
        [TestMethod]
        public void TestCrossingGameObjectAndPipe()
        {
            ModelPipe pipe = new ModelPipe(10, 0, 2, 20, null, 0);

            pipe.Step = 5;

            ModelBird bird = new ModelBird(5, 15, 2, 2, null);

            Assert.IsFalse(pipe.Crossing(bird));

            pipe.Move();

            Assert.IsTrue(pipe.Crossing(bird));

            pipe.X = 10;

            bird.Y = 0;

            pipe.Move();

            Assert.IsTrue(pipe.Crossing(bird));
        }
    }
}
