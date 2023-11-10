using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using GithubSpace;
using System.Diagnostics;

namespace GithubTestSpace
{
    [TestClass]
    public class GithubTest
    {
        private static readonly Github _github = new();

        [TestMethod]
        public void GetRepositories_NoAccessToken_Test01()
        {
            try
            {
                Task task = Task.Run(() => _github.GetRepositories());
            } catch (Exception e)
            {
            }
            Assert.AreEqual(_github.repos, null);
        }
    }
}
