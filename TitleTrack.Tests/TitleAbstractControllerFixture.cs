using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Controllers;
using TitleTrack.Server.Repositories;

namespace TitleTrack.Tests
{
    public class TitleAbstractControllerFixture
    {
        public Mock<ITitleAbstractRepository> RepoMock { get; }

        public TitleAbstractControllerFixture()
        {
            RepoMock = new Mock<ITitleAbstractRepository>(MockBehavior.Strict);
        }

        public TitleAbstractController CreateController()
            => new TitleAbstractController(RepoMock.Object);

        public void Reset()
            => RepoMock.Reset();

    }
}
