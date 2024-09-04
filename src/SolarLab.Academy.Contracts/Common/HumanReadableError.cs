﻿namespace SolarLab.Academy.Contracts.Common;

/// <summary>
/// Модель человеко-читаемой ошибки.
/// </summary>
public class HumanReadableError : ApiError
{
    /// <summary>
    /// Человеко-читаемое сообщение об ошибке для пользователя.
    /// </summary>
    public string HumanReadableErrorMessage { get; init; }
}