namespace SolarLab.Academy.Contracts.Contexts.Adverts.Requests;

/// <summary>
/// Модель создания объявления.
/// </summary>
public class CreateAdvertRequest
{
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
    public decimal? Price { get; set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid? CategoryId { get; set; }
}