namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Модель регистрации пользователя.
/// </summary>
public class UserRegisterRequestDto
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
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
}