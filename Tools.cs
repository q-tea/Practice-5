using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// Абстрактный класс орудия</summary>
    abstract class Tool
    {
        protected bool OneHanded;
        public Tool()
        {
            OneHanded = true;
        }
        /// <summary>
        /// Возвращает значение одноручное ли орудие</summary>
        /// <returns>Правда или ложь</returns>
        public bool IsOneHanded() => OneHanded;
    }
    /// <summary>
    /// Абстрактный класс оружие</summary>
    abstract class Weapon : Tool
    {
        /// <summary>
        /// Хранилище значения урона</summary>
        protected int Damage;
        /// <summary>
        /// Хранилище значения скорости атаки</summary>
        /// <remarks>Меньше - лучше</remarks>
        protected int AttackSpeed;
        public Weapon()
        { }
        /// <summary>
        /// Возвращает урон оружия</summary>
        /// <returns>Значение урона</returns>
        public int GetDamage() => Damage;
        /// <summary>
        /// Возвращает скорость атаки оружия</summary>
        /// <returns>Значение скорости атаки</returns>
        public int GetAttackSpeed() => AttackSpeed;
    }
    /// <summary>
    /// Класс кулаки</summary>
    class Fists : Weapon
    {
        public Fists()
        {
            Damage = 5;
            AttackSpeed = 5;
            OneHanded = false;
        }
    }
    /// <summary>
    /// Класс меч</summary>
    class Sword : Weapon
    {
        public Sword()
        {
            Damage = 10;
            AttackSpeed = 2;
        }
    }
    /// <summary>
    /// Класс тяжелый меч</summary>
    class HeavySword : Sword
    {
        public HeavySword()
        {
            Damage = 20;
            AttackSpeed = 3;
            OneHanded = false;
        }
    }
    /// <summary>
    /// Класс Щит</summary>
    class Shield : Tool
    {
        /// <summary>
        /// Хранилище значения защиты</summary>
        private int Defence;
        /// <summary>
        /// Хранилище значения шанса на отражение атаки</summary>
        private int BlockChance;
        public Shield()
        {
            Defence = 3;
            BlockChance = 10;
        }
        /// <summary>
        /// Возвращает урон оружия</summary>
        /// <returns>Значение урона</returns>
        public int GetDefence() => Defence;
        /// <summary>
        /// Возвращает скорость атаки оружия</summary>
        /// <returns>Значение скорости атаки</returns>
        public int GetBlockChance() => BlockChance;
    }
}
