using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.DataAccess.FakeDB;

public static class Users
{
    public static Dictionary<Guid, User> _userRepository = new();
    
    public static IEnumerable<User> Get()
    {
        var result = new List<User>()
        {
            new()
            {
                Id = Guid.Parse("0152A64C-4CD3-4B9F-96E4-E5472AA6DA7C"),
                Name = "Иванов Иван Иванович",
                Email = "ivanov@company.com"
            },
            new()
            {
                Id = Guid.Parse("534B4013-33DD-4925-9B21-1C6BF898DDE3"),
                Name = "Петров Иван Иванович",
                Email = "petrov@company.com"
            },
            new()
            {
                Id = Guid.Parse("759995F8-1A83-4C39-AD39-0E9B4061F7FB"),
                Name = "Сидоров Иван Иванович",
                Email = "sidirov@company.com"
            }
        };

        return result;
    }
}