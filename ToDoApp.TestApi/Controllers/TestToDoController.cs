using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Services;
using Xunit;
using ToDoApp.Controllers;
using ToDoApp.TestApi.Mockdata;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
namespace ToDoApp.TestApi.Controllers;

public class TestToDoController
{
    [Fact]
    public async Task GetAllAsync_ShouldReturn200Status()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(ToDoMockData.GetTodos());
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = (OkObjectResult)await sut.GetAllAsync();


        // /// Assert
        result.StatusCode.Should().Be(200);
    }
    [Fact]
    public async Task GetAllAsync_ShouldReturn204NoContentStatus()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(ToDoMockData.GetEmptyTodos());
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = (NoContentResult)await sut.GetAllAsync();


        /// Assert
        result.StatusCode.Should().Be(204);
        todoService.Verify(_ => _.GetAllAsync(), Times.Exactly(1));
    }

    [Fact]
    public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        var newTodo = ToDoMockData.NewTodo();
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = await sut.SaveAsync(newTodo);

        /// Assert
        todoService.Verify(_ => _.SaveAsync(newTodo), Times.Exactly(1));
    }
}
