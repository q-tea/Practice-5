using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// Класс Игрок</summary>
    /// <remarks>В роли Организатора</remarks>
    class Player
    {
        /// <summary>
        /// Объект класса Орудие</summary>
        /// <remarks>Соответствует объекту в основной руке</remarks>
        private Tool PrimaryWeapon;
        /// <summary>
        /// Объект класса Орудие</summary>
        /// <remarks>Соответствует объекту во второй руке</remarks>
        private Tool SecondaryWeapon;
        /// <summary>
        /// Хранилище значения Здоровье персонажа</summary>
        private int HealthPoints;
        /// <summary>
        /// Хранилище значения Скорость по оси X</summary>
        private double XSpeed;
        /// <summary>
        /// Хранилище значения Скорость по оси Y</summary>
        private double YSpeed;
        /// <summary>
        /// Хранилище значения Позиция по оси X</summary>
        private double XPos;
        /// <summary>
        /// Хранилище значения Позиция по оси Y</summary>
        private double YPos;
        /// <summary>
        /// Конструктор класса</summary>
        public Player()
        {
            HealthPoints = 100;
            PrimaryWeapon = new Sword();
            SecondaryWeapon = new Shield();
            XSpeed = 0.0;
            YSpeed = 0.0;
            XPos = 0.0;
            YPos = 0.0;
        }
        /// <summary>
        /// Печатает значение очков здоровья</summary>
        public void PrintHealth()
        {
            Console.WriteLine(HealthPoints);
        }
        /// <summary>
        /// Метод, описывающий смену оружия</summary>
        /// <param name="Weapon">Оружие</param>
        public void TakeWeapon(Tool Weapon)
        {
            if (Weapon.IsOneHanded())
            {
                if (Weapon is Sword)
                    PrimaryWeapon = Weapon;
                else
                    SecondaryWeapon = Weapon;
            }
            else
            {
                PrimaryWeapon = Weapon;
                SecondaryWeapon = Weapon;
            }
        }
        /// <summary>
        /// Метод, описывающий движение вперед</summary>
        public void WalkForward()
        {
            XSpeed = 100;
        }
        /// <summary>
        /// Метод, описывающий движение назад</summary>
        public void WalkBackwards()
        {
            XSpeed = -100;
        }
        /// <summary>
        /// Метод, описывающий остановку персонажа</summary>
        public void Stop()
        {
            XSpeed = 0;
        }
        /// <summary>
        /// Метод, регистрирующий положение персонажа с течением времени</summary>
        public void Position()
        {
            XPos += XSpeed;
        }
        /// <summary>
        /// Метод, описывающий получение урона</summary>
        /// /// <param name="Damage">Значение урона</param>
        public void Hit(int Damage)
        {
            HealthPoints -= Damage;
        }
        /// <summary>
        /// Возвращает урон оружия</summary>
        /// <param name="save">Сохраненное состояние</param>
        /// <returns>Значение урона</returns>
        public void SetSave(Save save)
        {
            PrimaryWeapon = save.GetPrimaryWeapon();
            SecondaryWeapon = save.GetSecondaryWeapon();
            HealthPoints = save.GetHealth();
            XSpeed = save.GetXSpeed();
            YSpeed = save.GetYSpeed();
            XPos = save.GetXPos();
            YPos = save.GetYPos();
        }
        /// <summary>
        /// Возвращает сохраненное состояние персонажа</summary>
        /// <returns>Сохраненное состояние персонажа</returns>
        public Save GetSave()
        {
            return new Save(
                PrimaryWeapon,
                SecondaryWeapon,
                HealthPoints,
                XSpeed,
                YSpeed,
                XPos,
                YPos
                );
        }
    }
    /// <summary>
    /// Класс Сохранение</summary>
    /// <remarks>В роли Хранителя</remarks>
    class Save
    {
        private Tool PrimaryWeapon;
        private Tool SecondaryWeapon;
        private int HealthPoints;
        private double XSpeed;
        private double YSpeed;
        private double XPos;
        private double YPos;
        /// <summary>
        /// Конструктор класса</summary>
        /// <param name="PrimaryWeapon">Объект класса Орудие, главная рука</param>
        /// <param name="SecondaryWeapon">Объект класса Орудие, вторая рука</param>
        /// <param name="HealthPoints">Очки здоровья</param>
        /// <param name="XSpeed">Скорость по оси X</param>
        /// <param name="YSpeed">Скорость по оси Y</param>
        /// <param name="XPos">Позиция по оси X</param>
        /// <param name="YPos">Позиция по оси Y</param>
        public Save(
            Tool PrimaryWeapon,
            Tool SecondaryWeapon,
            int HealthPoints,
            double XSpeed,
            double YSpeed,
            double XPos,
            double YPos
            )
        {
            this.PrimaryWeapon = PrimaryWeapon;
            this.SecondaryWeapon = SecondaryWeapon;
            this.HealthPoints = HealthPoints;
            this.XSpeed = XSpeed;
            this.YSpeed = YSpeed;
            this.XPos = XPos;
            this.YPos = YPos;
        }
        /// <summary>
        /// Возвращает сохраненное состояние значения Орудие в основной руке</summary>
        /// <returns>Объект класса Орудие, главная рука</returns>
        public Tool GetPrimaryWeapon() => PrimaryWeapon;
        /// <summary>
        /// Возвращает сохраненное состояние значения Орудие во второй руке</summary>
        /// <returns>Объект класса Орудие, вторая рука</returns>
        public Tool GetSecondaryWeapon() => SecondaryWeapon;
        /// <summary>
        /// Возвращает сохраненное состояние значения Здоровье</summary>
        /// <returns>Очки здоровья</returns>
        public int GetHealth() => HealthPoints;
        /// <summary>
        /// Возвращает сохраненное состояние значения Скорости по оси X</summary>
        /// <returns>Скорость по оси X</returns>
        public double GetXSpeed() => XSpeed;
        /// <summary>
        /// Возвращает сохраненное состояние значения Скорость по оси Y</summary>
        /// <returns>Скорость по оси Y</returns>
        public double GetYSpeed() => YSpeed;
        /// <summary>
        /// Возвращает сохраненное состояние значения Позиция по оси X</summary>
        /// <returns>Позиция по оси X</returns>
        public double GetXPos() => XPos;
        /// <summary>
        /// Возвращает сохраненное состояние значения Позиция по оси Y</summary>
        /// <returns>Позиция по оси Y</returns>
        public double GetYPos() => YPos;

    }
    /// <summary>
    /// Класс Сохраняющий</summary>
    /// <remarks>В роли Опекуна</remarks>
    class Saver
    {
        /// <summary>
        /// Объект класса Сохранение</summary>
        private Save save;
        /// <summary>
        /// Быстрое сохранение</summary>
        /// <param name="player">Объект класса Игрок</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда происходит попытка сохранения, а игрока не существует</exception>
        public void QuickSave(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("No players exist");
            save = player.GetSave();
        }
        /// <summary>
        /// Быстрая загрузка</summary>
        /// <param name="player">Объект класса Игрок</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда происходит попытка загрузки, а игрока не существует</exception>
        /// <exception cref="ArgumentNullException">Выбрасывается, когда происходит попытка загрузки, а сохранения не существует</exception>
        public void QuickLoad(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("No players exist");
            if (save == null)
                throw new ArgumentNullException("You have no backups");
            player.SetSave(save);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Saver saver = new Saver();
            Player player = new Player();

            player.PrintHealth();
            saver.QuickSave(player);
            player.Hit(10);
            player.Hit(10);
            player.Hit(20);
            player.PrintHealth();
            player.TakeWeapon(new HeavySword());
            saver.QuickLoad(player);
            player.PrintHealth();
        }
    }
}