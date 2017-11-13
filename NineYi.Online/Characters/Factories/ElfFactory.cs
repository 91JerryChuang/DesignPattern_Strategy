namespace NineYi.Online.Characters
{
    public class ElfFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter(string name)
        {
            var elf = new Elf(name);

            return elf;
        }
    }
}
