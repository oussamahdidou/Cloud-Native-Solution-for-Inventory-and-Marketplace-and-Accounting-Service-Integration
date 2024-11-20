using MarketplaceService.Application.Dtos.Category;
using MarketplaceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceService.Application.Mappers
{
    public static class CategoryMappers
    {
        public static CategorieItem FromCategorieToItem(this Category category)
        {
            return new CategorieItem()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Thumbnail = category.Thumbnail,
            };
        }
    }
}
