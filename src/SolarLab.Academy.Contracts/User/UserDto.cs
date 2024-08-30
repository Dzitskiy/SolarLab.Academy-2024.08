namespace SolarLab.Academy.Contracts.User;

public class UserDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; }
}