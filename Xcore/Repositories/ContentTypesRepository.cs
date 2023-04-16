using Xcore.Contexts;

namespace Xcore.Repositories
{
    public class ContentTypesRepository
    {
        private readonly DataContext _dataContext;

        public ContentTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
