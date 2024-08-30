using SolarLab.Academy.Contracts.Enums;
using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Domain.Entities;

/// <summary>
/// Заказ
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Описание заказа
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Комментарий к заказу.
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    /// Сумма заказа.
    /// </summary>
    public decimal Amount { get; set; }
    
    /// <summary>
    /// Общее количество товаров.
    /// </summary>
    public decimal TotalCount { get; set; }
    
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public OrderStatus OrderStatus { get; set; }
    
    /// <summary>
    /// Иденификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; } 
    
    /// <summary>
    /// Пользователь, сделавший заказ.
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Позиции заказа.
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; }
}