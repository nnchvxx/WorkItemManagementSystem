﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateTeam_Should
    {
        [TestMethod]
        public void CreateTeamShould_CreateSuccesfully()
        {
            var team = Factory.Instance.CreateTeam("Team1");
            Assert.IsInstanceOfType(team, typeof(ITeam));
        }
    }
}
