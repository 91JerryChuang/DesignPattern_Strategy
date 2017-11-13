using System;
using NineYi.Online.Enums;
using NineYi.Online.Weapons;

namespace NineYi.Online.Characters
{
    public abstract class CharacterBase
    {
        private string _name;

        private int _hp;

        private int _mp;

        private WeaponBehavior _weapon;

        protected readonly CharacterEnum _characterType;

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

        public void Fight()
        {
            this._weapon.UseWeapon();
        }

        public void SetWeapon(WeaponEnum weaponType)
        {
            this._weapon = WeaponFactory.GetWeaponBehavior(weaponType, this._characterType);
        }
    }
}
