namespace Flyweight
{ 
    /// <summary>
    /// Flyweight
    /// </summary>
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }
    
    /// <summary>
    /// Concrete Flyweight
    /// </summary>
    public class CharacterA : ICharacter
    {
        private readonly char _actualCharacter = 'a'; // intrinsic state
        private string _fontFamily = String.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize) // extrinsic state
        {
            _fontFamily = fontFamily;
            _fontSize  = fontSize;
            System.Console.WriteLine($"Character: {_actualCharacter}, FontFamily: {fontFamily}, FontSize: {fontSize}");
        }
    }
    
    public class CharacterB : ICharacter
    {
        private readonly char _actualCharacter = 'b'; // intrinsic state
        private string _fontFamily = String.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize) // extrinsic state
        {
            _fontFamily = fontFamily;
            _fontSize  = fontSize;
            System.Console.WriteLine($"Character: {_actualCharacter}, FontFamily: {fontFamily}, FontSize: {fontSize}");
        }
    }
    
    public class CharacterC : ICharacter
    {
        private readonly char _actualCharacter = 'c'; // intrinsic state
        private string _fontFamily = String.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize) // extrinsic state
        {
            _fontFamily = fontFamily;
            _fontSize  = fontSize;
            System.Console.WriteLine($"Character: {_actualCharacter}, FontFamily: {fontFamily}, FontSize: {fontSize}");
        }
    }
    
    /// <summary>
    /// Flyweight Factory
    /// </summary>
    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();

        // this means that , if we have a lot of characters, we can reuse them
        // the character (value type) is not recreated, it is reused
        public ICharacter? GetCharacter(char characterIdentifier)
        {
            // Does the character dictionary  contain the requested character?
            if (_characters.ContainsKey(characterIdentifier))
            {
                Console.WriteLine("Character reuse");
                return _characters[characterIdentifier];
            }
            
            // The character isn't in the dictionary so create it and add it to the dictionary
            Console.WriteLine("Character creation");
            switch (characterIdentifier)
            {
                case 'a':
                    _characters.Add(characterIdentifier, new CharacterA());
                    return _characters[characterIdentifier];
                case 'b':
                    _characters.Add(characterIdentifier, new CharacterB());
                    return _characters[characterIdentifier];
                case 'c':
                    _characters.Add(characterIdentifier, new CharacterC());
                    return _characters[characterIdentifier];
                // and so on...
            }

            return null;
        }

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }
    
    /// <summary>
    /// Unshared Concrete Flyweight
    /// </summary>
    public class Paragraph : ICharacter
    {
        private int _location;
        private readonly List<ICharacter> _characters = new();

        public Paragraph(List<ICharacter> characters, int location)
        {
            _characters = characters;
            _location = location;
        }
        
        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }
}