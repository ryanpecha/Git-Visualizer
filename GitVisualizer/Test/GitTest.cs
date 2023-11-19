using GitVisualizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTestSpace
{
    [TestClass]
    public class GitTest
    {
        [TestClass]
        public class Actions
        {
            [TestMethod]
            public void addLocalBranchToRemote_Valid_Test01()
            {
                GitAPI.Actions.LocalActions.addLocalBranchToRemote();
            }
        }
    }
}
