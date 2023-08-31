using FilmFusion.Domain.Entities;
using FilmFusion.Domain.Repositories;
using FilmFusion.Infra.Data.SqlServer.Context;
using FilmFusion.Infra.Data.SqlServer.Repositories;
using FilmFusion.Tests.Configurations;
using FluentAssertions;
using Xunit;

namespace FilmFusion.Tests.Repositories
{
    public class RepositoryBaseTests
    {
        private readonly ApplicationSqlServerDbContext _context;
        private readonly IRepositoryBase<Entertainment> _repository;

        public RepositoryBaseTests()
        {
            _context = DbFactory.BuildSqlContext(nameof(RepositoryBaseTests));
            _repository = new RepositoryBase<Entertainment>(_context);
        }

        internal void Clear()
        {
            _context.Entertainments.RemoveRange(_context.Entertainments.Local.ToList());
            _context.SaveChanges();
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntertaimentInDatabase()
        {
            // Arrange
            var entertainmentEntity = new Entertainment { Title = "Test Name", Year = "2012" };

            // Act
            var result = await _repository.AddAsync(entertainmentEntity);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(entertainmentEntity);

            Clear();
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteEntertaimentFromDatabase()
        {
            // Arrange
            var entertainmentEntity = new Entertainment { Title = "Test Name", Year = "2012" };
            await _repository.AddAsync(entertainmentEntity);

            // Act
            _repository.DeleteAsync(entertainmentEntity);

            // Assert
            entertainmentEntity.Should().NotBeEquivalentTo(_context.Entertainments.Local);

            Clear();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntertaimentsFromDatabase()
        {
            // Arrange
            var entertainmentEntity1 = new Entertainment { Title = "Test Name 1", Year = "2012", Type = "movie" };
            var entertainmentEntity2 = new Entertainment { Title = "Test Name 2", Year = "2013", Type = "movie" };

            await _repository.AddAsync(entertainmentEntity1);
            await _repository.AddAsync(entertainmentEntity2);
            await _repository.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(2);
            result.Should().Contain(x => x.Title == "Test Name 1");
            result.Should().Contain(x => x.Year == "2012");

            Clear();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntertaimentWithIdSpecific()
        {
            // Arrange
            var entertainmentEntity = new Entertainment {Title = "Test Name", Year = "2012", Type = "movie" };
            await _repository.AddAsync(entertainmentEntity);
            await _repository.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(entertainmentEntity.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(entertainmentEntity);

            Clear();
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldSaveChangesToDatabase()
        {
            // Arrange
            var entertainmentEntity = new Entertainment {Title = "Test Name", Year = "2012", Type = "movie" };
            await _repository.AddAsync(entertainmentEntity);

            // Act
            var result = await _repository.SaveChangesAsync();

            // Assert
            result.Should().Be(1);

            Clear();
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityInDatabase()
        {
            // Arrange
            var entertainmentEntity = new Entertainment {Title = "Test Name", Year = "2012", Type = "movie" };
            await _repository.AddAsync(entertainmentEntity);
            await _repository.SaveChangesAsync();

            entertainmentEntity.Title = "Updated Test";

            // Act
            var result = await _repository.UpdateAsync(entertainmentEntity);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(entertainmentEntity.Id);
            result.Title.Should().Be(entertainmentEntity.Title);
            result.Should().Be(entertainmentEntity);

            Clear();
        }
    }
}
