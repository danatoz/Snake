using System;
using System.Threading;

namespace Snake
{
    class Program {
        static void Main(string[] args)
        {
            #region Размер окна и буферной зоны

            Console.SetWindowSize(80, 25);//Задаем размер окна консоли
            Console.SetBufferSize(80, 25);//Задаем пределы окна
            Console.CursorVisible = false;
            #endregion

            #region Стены
            Walls walls = new Walls(79,25);//Создаем экземпляр класса и создаем стены
            walls.Draw();

            #endregion

            Point p = new Point(30,5,'*');
            Snake snake = new Snake(p,4, Direction.RIGHT);//Создаем змейку по указаным координатам смотрящую в право
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80,25,'$');//созздаем приманку
            Point food = foodCreator.CreateFood();

            food.Draw();

            while (true)//бесконечный цикл с условиями выхода из него
            {
                if(walls.IsHit(snake) || snake.IsHitTail())//проверка на столкновение с стенами и хвостом
                    break;
                if (snake.Eat(food))//проверка на столкновение с едой
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)//отслеживание нажатия клавиш для изменения направления змейки
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(100);
                snake.Move();
            }

            Console.ReadLine();
        }
    }
}
