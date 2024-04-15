namespace WebApplication1;

public class Animal
{
    public Animal(){}
    public Animal(int id, string name, string category, int weight, string color)
    {
        Id = id;
        Name = name;
        Category = category;
        Weight = weight;
        Color = color;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Weight { get; set; }
    public string Color { get; set; }
}