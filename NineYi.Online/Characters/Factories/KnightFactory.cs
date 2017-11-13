namespace NineYi.Online.Characters
{
    public class KnightFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter(string name)
        {
            var knight = new Knight(name);

            return knight;
        }
    }
}
