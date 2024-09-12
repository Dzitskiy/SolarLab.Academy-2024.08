﻿using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;

/// <summary>
/// Спецификация отсечения по максимальной цене.
/// </summary>
public class MaxPriceSpecification : Specification<Advert>
{
    private readonly decimal _maxPrice;

    /// <summary>
    /// Создаёт спецификацию отсечения по максимальной цене.
    /// </summary>
    /// <param name="maxPrice">Максимальная цена.</param>
    public MaxPriceSpecification(decimal maxPrice)
    {
        _maxPrice = maxPrice;
    }

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression =>
        advert => advert.Price <= _maxPrice;
}