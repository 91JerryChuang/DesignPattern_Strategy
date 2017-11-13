using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public class WeaponFactory
    {
        public static WeaponBehavior GetWeaponBehavior(WeaponEnum weaponType, CharacterEnum characterType)
        {
            switch (weaponType)
            {
                case WeaponEnum.Knife:
                    return new KnifeBehavior(characterType);
                case WeaponEnum.Sword:
                    return new SwordBehavior(characterType);
                case WeaponEnum.Bow:
                    return new BowBehavior(characterType);
                case WeaponEnum.Staff:
                    return new StaffBehavior(characterType);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
