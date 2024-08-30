using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.DataAccess.FakeDB;

public static class Orders
{
    public static IEnumerable<Order> Get()
    {
        var result = new List<Order>()
        {
            new()
            {
                Id = Guid.Parse("6A5A9643-6940-478E-B0D9-6A88A671A659"),
                TotalCount = 10,
                Amount = 200m,
                Comment = "Comment -> 6A5A9643-6940-478E-B0D9-6A88A671A659",
                Description = "Desctiption -> 6A5A9643-6940-478E-B0D9-6A88A671A659",
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Parse("0152A64C-4CD3-4B9F-96E4-E5472AA6DA7C")
            },
            new()
            {
                Id = Guid.Parse("2D5578B4-BB0C-42D1-A9BC-B943438EE45B"),
                TotalCount = 10,
                Amount = 200m,
                Comment = "Comment -> 2D5578B4-BB0C-42D1-A9BC-B943438EE45B",
                Description = "Desctiption -> 2D5578B4-BB0C-42D1-A9BC-B943438EE45B",
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Parse("534B4013-33DD-4925-9B21-1C6BF898DDE3")
            },
            new()
            {
                Id = Guid.Parse("A64D991E-693C-4132-9492-A6134F3F22FF"),
                TotalCount = 10,
                Amount = 200m,
                Comment = "Comment -> A64D991E-693C-4132-9492-A6134F3F22FF",
                Description = "Desctiption -> A64D991E-693C-4132-9492-A6134F3F22FF",
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Parse("534B4013-33DD-4925-9B21-1C6BF898DDE3")
            }
        };

        return result;
    }
}