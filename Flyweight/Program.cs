// See https://aka.ms/new-console-template for more information

using Flyweight;

Console.WriteLine("Hello, World!");

var aBunchOfCharacters = "aadc";

var characterFactory = new CharacterFactory();
// Get the flyweight(s) from the factory

// Extrinsic state is context-dependent and not inherent to the flyweight
// intrinsic state is inherent to the flyweight

var characterObject = characterFactory.GetCharacter(aBunchOfCharacters[0]);
characterObject?.Draw("Arial", 12);

var characterObject2 = characterFactory.GetCharacter(aBunchOfCharacters[1]);
characterObject2?.Draw("Trebuchet MS", 14);

var characterObject3 = characterFactory.GetCharacter(aBunchOfCharacters[2]);
characterObject3?.Draw("Times New Roman", 16);

var characterObject4 = characterFactory.GetCharacter(aBunchOfCharacters[3]);
characterObject4?.Draw("Comic Sans", 18);

var paragraph = characterFactory.CreateParagraph(
    new List<ICharacter>
    {
        characterObject, 
        characterObject2,
        characterObject3,
        characterObject4
    }, 
    1);


paragraph.Draw("Lucinda Console", 20);

Console.ReadKey();