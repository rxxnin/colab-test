namespace Domain.Entities;

public class Project
{
    /// <summary>
    ///     Айди
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Айди создателя
    /// </summary>
    public Guid CreatorId { get; set; }
    
    /// <summary>
    ///     Ссылка на модель создателя
    /// </summary>
    public User Creator { get; set; }
    
    /// <summary>
    ///     Название
    /// </summary>
    public string Name { get; set; }    
    
    /// <summary>
    ///     Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    ///     Требуемые навыки
    /// </summary>
    public string RequiredSkills { get; set; }
    
    /// <summary>
    ///     Список участников
    /// </summary>
    public ICollection<User> Members { get; set; } = new List<User>();
}