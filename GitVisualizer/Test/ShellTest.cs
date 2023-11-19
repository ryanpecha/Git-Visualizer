using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace ShellTestSpace
{
    [TestClass]
    public class ShellTest
    {
        [TestMethod]
        public void exec_ls_Test01()
        {
            ShellComRes result = Shell.exec(new Command("ls"));
            Assert.AreEqual(true, result.success);
        }

        [TestMethod]
        public void exec_ls_Test02()
        {
            ShellComRes result = Shell.exec(new Command("l"));
            Assert.AreEqual(false, result.success);
            StringAssert.StartsWith(result.errmsg, "System.Management.Automation.CommandNotFoundException: The term 'l' is not recognized as a name of a cmdlet");
        }
    }
}
