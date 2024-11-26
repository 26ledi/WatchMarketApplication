//using Microsoft.EntityFrameworkCore;
//using WatchMarketApp.DataAccess.Data;
//using WatchMarketApp.DataAccess.Repositories.Implementations;
//using WatchMarketApp.DataAccess.Tests;

//public class BaseRepositoryIntegrationTests
//{
//    //Integration Test
//    private readonly WatchMarketContext _context;
//    private readonly BaseRepository<TestEntity> _repository;

//    public BaseRepositoryIntegrationTests()
//    {
//        var options = new DbContextOptionsBuilder<WatchMarketContext>()
//            .UseInMemoryDatabase(databaseName: "TestDatabase")
//            .Options;

//        _context = new WatchMarketContext(options);
//        _repository = new BaseRepository<TestEntity>(_context);
//    }

//    [Fact]
//    public async Task AddAsync_Should_Add_Entity_To_Database()
//    {
//        // Arrange
//        var entity = new TestEntity { Id = 1, Name = "Test" };

//        // Act
//        await _repository.AddAsync(entity);
//        var result = await _context.Set<TestEntity>().FirstOrDefaultAsync();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal("Test", result.Name);
//    }

//    [Fact]
//    public async Task DeleteAsync_Should_Remove_Entity_From_Database()
//    {
//        // Arrange
//        var entity = new TestEntity { Id = 1, Name = "Test" };
//        await _repository.AddAsync(entity);

//        // Act
//        await _repository.DeleteAsync(entity);
//        var result = await _context.Set<TestEntity>().FirstOrDefaultAsync();

//        // Assert
//        Assert.Null(result);
//    }
//}
