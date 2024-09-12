using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.Contracts.Contexts.Adverts.Responses;

/// <summary>
/// Полная модель категории.
/// </summary>
public class AdvertResponse
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Признак не актуальности.
    /// </summary>
    public bool Disabled { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime Created { get; set; }
    
    /// <summary>
    /// Модель категории.
    /// </summary>
    public CategoryInfoModel Category { get; set; }
}