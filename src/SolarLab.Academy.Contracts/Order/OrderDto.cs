using SolarLab.Academy.Contracts.Enums;

namespace SolarLab.Academy.Contracts.Order;

public class OrderDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public Guid Id { get; set; }
    
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
}