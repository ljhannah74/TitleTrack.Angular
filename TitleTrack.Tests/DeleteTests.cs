using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class DeleteTests : TitleAbstractControllerTestBase, IClassFixture<TitleAbstractControllerFixture>
    {
        public DeleteTests(TitleAbstractControllerFixture fx) : base(fx) { }

        [Fact]
        public async Task ReturnsNotFound_WhenMissing()
        {
            SetupNotFound(1);

            var result = await Controller.DeleteTitleAbstractAsync(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ReturnsNoContent_WhenDeleted()
        {
            var entity = new TitleAbstract { TitleAbstractID = 1 };
            SetupFound(1, entity);

            Fx.RepoMock.Setup(r => r.DeleteTitleAbstractAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await Controller.DeleteTitleAbstractAsync(1);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
