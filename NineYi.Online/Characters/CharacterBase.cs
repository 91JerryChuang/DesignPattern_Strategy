using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Characters
{
    public abstract class CharacterBase
    {
        private string _name;

        private int _hp;

        private int _mp;

        public CharacterBase(string name, CharacterEnum characterType)
        {
            this._name = name;
            this.InitialCharacterInfo(characterType);
        }

        private void InitialCharacterInfo(CharacterEnum characterType)
        {
            var random = new Random();
            var minHp = 0;
            var maxHp = 0;
            var minMp = 0;
            var maxMp = 0;
            
            switch(characterType)
            {
                case CharacterEnum.Elf:
                    minHp = 25;
                    maxHp = 35;
                    minMp = 20;
                    maxMp = 25;
                    break;
                case CharacterEnum.Knight:
                    minHp = 25;
                    maxHp = 40;
                    minMp = 10;
                    maxMp = 15;
                    break;
                case CharacterEnum.Prince:
                    minHp = 20;
                    maxHp = 30;
                    minMp = 15;
                    maxMp = 20;
                    break;
            }

            this._hp = random.Next(minHp, maxHp);
            this._mp = random.Next(minMp, maxMp);
        }

        public void ShowCharcterInfo()
        {
            Console.WriteLine($"{this._name} - HP:{this._hp} - MP:{this._mp}");
        }

        public void Fight(WeaponEnum weapon)
        {
            switch (weapon)
            {
                case WeaponEnum.Knife:
                    Console.WriteLine($"{this._name} 匕首刺擊");
                    break;
                case WeaponEnum.Sword:
                    Console.WriteLine($"{this._name} 揮舞長劍");
                    break;
                case WeaponEnum.Bow:
                    Console.WriteLine($"{this._name} 拉弓射箭");
                    break;
                default:
                    Console.WriteLine($"{this._name} 揮拳");
                    break;
            }
        }
    }
}
