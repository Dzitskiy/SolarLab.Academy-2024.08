using System.Security.Cryptography.X509Certificates;

namespace SolarLab.Academy.Contracts.Enums;

/// <summary>
/// Статус заказа
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Неопределенный статус.
    /// </summary>
    Undefined = 0,
    
    /// <summary>
    /// Черновик.
    /// </summary>
    Draft = 1,
    
    /// <summary>
    /// Опубликовано.
    /// </summary>
    Published = 2
}