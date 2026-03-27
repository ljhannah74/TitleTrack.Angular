using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class GetAllTests : TitleAbstractControllerTestBase, IClassFixture<TitleAbstractControllerFixture>
    {
        public GetAllTests(TitleAbstractControllerFixture fx) : base(fx) { }

        [Fact]
        public async Task ReturnsOk_WithItems()
        {
            var items = new[]
            {
            new TitleAbstract { TitleAbstractID = 1 },
            new TitleAbstract { TitleAbstractID = 2 }
        };

            Fx.RepoMock.Setup(r => r.GetAllTitleAbstractsAsync())
                       .ReturnsAsync(items);

            var result = await Controller.GetAllTitleAbstractsAsync();

            result.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.As<IEnumerable<TitleAbstract>>()
                .Should().HaveCount(2);
        }

    }
}
