using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Domain.Entities;

/// <summary>
/// Модель пользователя.
/// </summary>
public class User : BaseEntity
{
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
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Признак блокировки.
    /// </summary>
    public bool IsBlocked { get; set; }
}