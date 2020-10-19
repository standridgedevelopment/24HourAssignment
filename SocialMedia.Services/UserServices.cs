using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class UserService
    {
        public class CategoryService
        {
            public bool CreateCategory(CategoryCreate model)
            {
                var emptyList = new List<string>
            {
                " "
            };
                var entity = new Category()
                {
                    ListOfNotes = "",
                    CategoryID = model.CategoryID,
                    Name = model.Name
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Categories.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<CategoryListItem> GetCategories()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query = ctx.Categories.Select
                        (e => new CategoryListItem
                        {
                            CategoryId = e.CategoryID,
                            Name = e.Name
                        }
                        );
                    return query.ToArray();
                }
            }
            public Category GetCategoryById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Categories.Single(e => e.CategoryID == id);
                    return new Category
                    {
                        CategoryID = entity.CategoryID,
                        Name = entity.Name,
                        ListOfNotes = entity.ListOfNotes,
                        NumberOfLists = entity.NumberOfLists

                    };
                }
            }
            public bool UpdateCategory(Category model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Categories.Single(e => e.CategoryID == model.CategoryID);

                    entity.Name = model.Name;

                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteCategory(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Categories.Single(e => e.CategoryID == id);

                    ctx.Categories.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }

    }
}
