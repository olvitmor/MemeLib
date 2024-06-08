namespace MemeLib.Domain.Requests;

public record CreateOrUpdateMemeRequest
{
    public Guid Id { get; set; }
    
    public string Alias { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? Description { get; set; }
}