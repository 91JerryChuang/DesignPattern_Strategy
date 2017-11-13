using System;
using System.Linq;
using System.Net;
using NineYi.Online.Enums;
using NineYi.Online.Utilities;

namespace NineYi.Online.Characters
{
    public abstract class CharacterBase
    {
        private string _name;

        private int _hp;

        private int _mp;

        private readonly CharacterEnum _characterType;

        public CharacterBase(string name, CharacterEnum characterType)
        {
            this._name = name;
            this._characterType = characterType;
            this.InitialCharacterInfo();
        }

        private void InitialCharacterInfo()
        {
            var random = new Random();
            var minHp = 0;
            var maxHp = 0;
            var minMp = 0;
            var maxMp = 0;
            
            switch(this._characterType)
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
                case CharacterEnum.Wizard:
                    minHp = 20;
                    maxHp = 25;
                    minMp = 25;
                    maxMp = 40;
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
            if (weapon == WeaponEnum.Knife)
            {
                Console.WriteLine($"{this._name} 匕首刺擊");
                return;
            }
            else if (weapon == WeaponEnum.Sword)
            {
                Console.WriteLine($"{this._name} 揮舞長劍");
                return;
            }
            else if (weapon == WeaponEnum.Bow)
            {
                Console.WriteLine($"{this._name} 拉弓射箭");
                return;
            }
            else if (weapon == WeaponEnum.Staff)
            {
                if (this._characterType == CharacterEnum.Wizard)
                {
                    Console.WriteLine($"{this._name} 揮舞魔杖");
                    return;
                }
            }

            var characterTypeName = Utility.GetDescriptions<CharacterEnum>().Where(x => x.Key == this._characterType).Select(x => x.Value).First();
            var weaponName = Utility.GetDescriptions<WeaponEnum>().Where(x => x.Key == weapon).Select(x => x.Value).First();

            Console.WriteLine($"很抱歉 {characterTypeName} 無法使用 {weaponName}");
            Console.WriteLine($"{this._name} 揮拳");
        }
    }
}
