using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Contracts.Categories
{
    public class CategoryInfoModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        /// <summary>
        /// Имя категории.
        /// </summary>
        public string Title { get; set; }

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
