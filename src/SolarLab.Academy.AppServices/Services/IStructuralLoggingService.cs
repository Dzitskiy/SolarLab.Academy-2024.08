namespace SolarLab.Academy.AppServices.Services;

/// <summary>
/// Сервис структурного логирования.
/// </summary>
public interface IStructuralLoggingService
{
    /// <summary>
    /// Добавить свойство ко всем логам до уничтожения IDisposable.
    /// </summary>
    /// <param name="name">Наименование свойства.</param>
    /// <param name="value">Значение свойства.</param>
    /// <param name="destructureObjects">Нужно ли раскладывать объект на поля.</param>
    /// <returns>Объект <see cref="IDisposable"/>.</returns>
    IDisposable PushProperty(string name, object value, bool destructureObjects = false);
}