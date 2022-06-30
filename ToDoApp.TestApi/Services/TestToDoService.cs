using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ToDoApp.Data;
using ToDoApp.Services;
using ToDoApp.TestApi.Mockdata;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.TestApi.Services;

public class TestToDoService : IDisposable
{
    protected readonly ToDoDbContext _context;
    public TestToDoService()
    {
        var options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        _context = new ToDoDbContext(options);

        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task GetAllAsync_ReturnTodoCollection()
    {
        /// Arrange
        _context.ToDo.AddRange(Mockdata.ToDoMockData.GetTodos());
        _context.SaveChanges();

        var sut = new TodoService(_context);

        /// Act
        var result = await sut.GetAllAsync();

        /// Assert
        result.Should().HaveCount(ToDoMockData.GetTodos().Count);
    }

    [Fact]
    public async Task SaveAsync_AddNewTodo()
    {
        /// Arrange
        var newTodo = ToDoMockData.NewTodo();
        _context.ToDo.AddRange(Mockdata.ToDoMockData.GetTodos());
        _context.SaveChanges();

        var sut = new TodoService(_context);

        /// Act
        await sut.SaveAsync(newTodo);

        ///Assert
        int expectedRecordCount = (ToDoMockData.GetTodos().Count() + 1);
        _context.ToDo.Count().Should().Be(expectedRecordCount);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
