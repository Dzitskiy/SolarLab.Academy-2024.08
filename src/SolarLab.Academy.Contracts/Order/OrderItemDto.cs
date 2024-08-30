namespace SolarLab.Academy.Contracts.Order;

public class OrderItemDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Количество
    /// </summary>
    public decimal Count { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; set; }
}