using SolarLab.Academy.Contracts.Common;

namespace SolarLab.Academy.Contracts.Contexts.Adverts.Requests;

/// <summary>
/// Модель поиска объявлений.
/// </summary>
public class SearchAdvertRequest : BasePaginationRequest
{
    /// <summary>
    /// Строка поиска.
    /// </summary>
    public string Search { get; set; }
    
    /// <summary>
    /// Минимальная цена.
    /// </summary>
    public decimal? MinPrice { get; set; }
    
    /// <summary>
    /// Максимальная цена.
    /// </summary>
    public decimal? MaxPrice { get; set; }
    
    /// <summary>
    /// Включать не актуальные объявления.
    /// </summary>
    public bool? IncludeDisabled { get; set; }
}