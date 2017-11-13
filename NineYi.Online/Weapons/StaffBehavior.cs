using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public class StaffBehavior : WeaponBehavior
    {
        public StaffBehavior(CharacterEnum characterType) 
            : base(characterType)
        {
        }

        public override void UseWeapon()
        {
            if (this._userType != CharacterEnum.Wizard)
            {
                this.Fist();
                return;
            }

            Console.WriteLine("揮舞魔杖");
        }
    }
}
