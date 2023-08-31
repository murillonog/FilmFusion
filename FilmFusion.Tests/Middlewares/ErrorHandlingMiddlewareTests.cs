using FilmFusion.Api.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FilmFusion.Tests.Middlewares
{
    public class ErrorHandlingMiddlewareTests
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddlewareTests()
        {
            _logger = new Mock<ILogger<ErrorHandlingMiddleware>>().Object;
        }

        [Fact]
        public async Task Invoke_ShouldReturnOk()
        {
            HttpContext context = new DefaultHttpContext();

            Task next(HttpContext hc) => Task.CompletedTask;

            var handler = new ErrorHandlingMiddleware(next, _logger);

            await handler.Invoke(context);
            Assert.NotNull(context.Response);
        }

        [Fact]
        public async Task Invoke_ShouldReturnException()
        {
            HttpContext context = new DefaultHttpContext();
            Exception? exception = new("Error", new Exception("error"));


            Task next(HttpContext hc) => Task.FromException(exception);

            var handler = new ErrorHandlingMiddleware(next, _logger);

            await handler.Invoke(context);
            Assert.NotNull(context.Response);
        }
    }
}
