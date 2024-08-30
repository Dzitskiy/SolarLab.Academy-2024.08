using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Domain.Entities;

/// <summary>
/// Позиции товара
/// </summary>
public class OrderItem : BaseEntity
{
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
    
    /// <summary>
    /// Заказ
    /// </summary>
    public Order Order { get; set; }
}