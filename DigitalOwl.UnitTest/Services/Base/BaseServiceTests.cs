using Xunit;

namespace DigitalOwl.UnitTest.Services.Base
{
    public class BaseServiceTests : IClassFixture<MapperFixture>
    {
        protected readonly MapperFixture fixture;

        public BaseServiceTests(MapperFixture fixture)
        {
            this.fixture = fixture;
        }
    }
}