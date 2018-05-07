using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

using NeoDesk.Forms.TransferWindow;

namespace UnitTests
{
namespace Forms
{

[TestClass()]
public class TransferWindowFormTests
{
    [TestMethod()]
    public void TransferWindowFormCreation()
    {
        TransferWindowForm transferWindowForm = new TransferWindowForm();

        Assert.IsNotNull( transferWindowForm );
    }
}

}
}
