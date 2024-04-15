namespace WebApplication1;

public class Visit
{
    public Visit(){}
    public Visit(int id, DateTime visitDate, int animalId, String description, decimal price)
    {
        Id = id;
        VisitDate = visitDate;
        AnimalId = animalId;
        Description = description;
        Price = price;
    }
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}