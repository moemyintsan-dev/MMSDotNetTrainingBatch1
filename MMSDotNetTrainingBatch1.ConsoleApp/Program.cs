
string firstName = "Moe";
string lastName = "San";
string fullName = firstName + lastName;
Console.WriteLine(" My name is " + fullName);

int myNum = 151;
double myDoubleNum = 39.23D;
char myLetter = 'E';
bool myBool = false;
Console.WriteLine(myNum);
Console.WriteLine(myDoubleNum);
Console.WriteLine(myLetter);
Console.WriteLine(myBool);

string name = "B";
if (name == "A")
{
    Console.WriteLine("Coffee");
}
else if (name == "B")
{
    Console.WriteLine("Bread");
}
else if (name == "C")
{
    Console.WriteLine("Eat");
}
else
{
    Console.WriteLine("Nothing");
}

switch (name)
{
    case "A":
        Console.WriteLine("Coffee");
        break;
    case "B":
        Console.WriteLine("Bread");
        break;
    case "C":
        Console.WriteLine("Eat");
        break;
    default:
        Console.WriteLine("Nothing");
        break;
}

for (int i = 1; i <= 3; i++)
{
    Console.WriteLine("Before");
    Console.WriteLine(i);
    Console.WriteLine("After");
}

string[] color = { "red", "blue", "purple", "green" };

for (int i = 0; i < color.Length; i++)
{
    Console.WriteLine(color[i]);
}

foreach (string item in color)
{
    Console.WriteLine(item);
}

Resume resume = new Resume();
resume.Name = "Mg Mg";
resume.Age = 18;
Console.WriteLine(resume.Name);
Console.WriteLine(resume.Age);

Resume resume2 = new Resume();
resume2.Name = "Ma Ma";
resume2.Age = 20;
var result = resume2.IS18Year();
Console.WriteLine(result);

public class Resume
{
    public string Name;
    public int Age;
    public bool IS18Year()
    {
        bool result = Age > 18;
        return result;
    }
}


class Animal
{
    public virtual void animalSound()
    {
        Console.WriteLine("The animal makes a sound");
    }
}
class Dog : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The dog says woke woke");
    }
}
class Animals
{
    static void Main(string[] args)
    {
        Animal myAnimal = new Animal();
        Animal myDog = new Dog();

        myAnimal.animalSound();
        myDog.animalSound();
    }
}













