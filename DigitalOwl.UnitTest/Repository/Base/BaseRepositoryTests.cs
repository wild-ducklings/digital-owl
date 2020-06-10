using Xunit;

namespace DigitalOwl.UnitTest.Repository.Base
{
    public class BaseRepositoryTests : IClassFixture<UnitOfWorkFixture>
    {
        protected readonly UnitOfWorkFixture _fixture;

        public BaseRepositoryTests(UnitOfWorkFixture fixture)
        {
            this._fixture = fixture;
        }
    }
}