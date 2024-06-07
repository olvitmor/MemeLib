namespace MemeLib.Domain.Models;

public class MemeModel
{
    public Guid Id { get; set; }
    
    public string Alias { get; set; }
    
    public DateTime Ts { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? Description { get; set; }
    
    public DateOnly PublishDate { get; set; }
}