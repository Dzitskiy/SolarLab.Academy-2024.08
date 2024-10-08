using SolarLab.Academy.DataAccess;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Api.Tests
{
    /// <summary>
    /// Вспомогательный класс для заполнения БД тестовыми данными.
    /// </summary>
    public static class DataSeedHelper
    {
        /// <summary>
        /// Идентификатор тестовой категории.
        /// </summary>
        public static Guid TestCategoryId { get; set; }

        /// <summary>
        /// Идентификатор тестового объявления.
        /// </summary>
        public static Guid TestAdvertId { get; set; }

        /// <summary>
        /// Заполнить БД тестовыми данными.
        /// </summary>
        /// <param name="dbContext"></param>
        public static void SeedData(AcademyDbContext dbContext)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                ParentId = null,
                Name = "in_mem_cat_name",
                Description = "in_mem_cat_desc",
                Number = "test_num",
                Created = DateTime.UtcNow
            };

            var advert = new Advert
            {
                Id = Guid.NewGuid(),
                Name = "in_mem_name",
                Description = "in_mem_desc",
                Price = 100,
                Disabled = false,
                Created = DateTime.UtcNow,
                CategoryId = category.Id
            };

            dbContext.Add(category);
            dbContext.Add(advert);
            dbContext.SaveChanges();

            TestAdvertId = advert.Id;
            TestCategoryId = category.Id;
        }
    }
}