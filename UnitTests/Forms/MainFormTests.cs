//////////////////////////////////////////////////////////////
//
// Unit tests within MainForm.
//
// 15-May-2018   Created.
//
//////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

using NeoDesk.Forms.Main;

namespace UnitTests
{
namespace Forms
{

[TestClass()]
public class MainFormTests
{
    [TestMethod()]
    public void MainFormCreation()
    {
        MainForm mainForm = new MainForm();

        Assert.IsNotNull( mainForm );
        Assert.IsNotNull( mainForm.Menu );
    }
}

}
}