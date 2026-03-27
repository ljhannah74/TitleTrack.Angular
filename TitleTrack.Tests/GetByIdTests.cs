using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class GetByIdTests : TitleAbstractControllerTestBase, IClassFixture<TitleAbstractControllerFixture>
    {
        public GetByIdTests(TitleAbstractControllerFixture fx) : base(fx) { }

        [Fact]
        public async Task ReturnsNotFound_WhenMissing()
        {
            SetupNotFound(1);

            var result = await Controller.GetTitleAbstractByIdAsync(1);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ReturnsOk_WhenFound()
        {
            var entity = new TitleAbstract { TitleAbstractID = 1 };
            SetupFound(1, entity);

            var result = await Controller.GetTitleAbstractByIdAsync(1);

            result.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(entity);
        }

    }
}
