using web_blog.Core.Repositories;

namespace web_blog.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        IPostCategoryRepository PostCategories { get; }
        ISeriesRepository Series { get; }
        Task<int> CompleteAsync();
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }
        ITagRepository Tags { get; }

    }
}
