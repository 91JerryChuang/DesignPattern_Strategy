using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public abstract class WeaponBehavior
    {
        protected CharacterEnum _userType;

        public WeaponBehavior(CharacterEnum characterType)
        {
            this._userType = characterType;
        }

        public abstract void UseWeapon();

        protected void Fist()
        {
            Console.WriteLine("揮拳");
        }
    }
}
