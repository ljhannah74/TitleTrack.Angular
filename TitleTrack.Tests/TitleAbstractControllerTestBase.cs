using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Controllers;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class TitleAbstractControllerTestBase
    {
        protected readonly TitleAbstractControllerFixture Fx;

        protected TitleAbstractControllerTestBase(TitleAbstractControllerFixture fx)
        {
            Fx = fx;
            Fx.Reset();
        }

        protected TitleAbstractController Controller => Fx.CreateController();

        protected void SetupFound(int id, TitleAbstract entity)
            => Fx.RepoMock.Setup(r => r.GetTitleAbstractByIdAsync(id))
                          .ReturnsAsync(entity);

        protected void SetupNotFound(int id)
            => Fx.RepoMock.Setup(r => r.GetTitleAbstractByIdAsync(id))
                          .ReturnsAsync((TitleAbstract)null);
    }
}
