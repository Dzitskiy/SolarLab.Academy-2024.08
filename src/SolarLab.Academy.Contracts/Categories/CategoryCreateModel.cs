namespace SolarLab.Academy.Contracts.Categories
{
    /// <summary>
    /// Модель создания категории.
    /// </summary>
    public class CategoryCreateModel
    {
        /// <summary>
        /// Имя категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        public string Number { get; set; }
    }
}
