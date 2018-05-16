//////////////////////////////////////////////////////////////
//
// Unit tests within TransferWindowForm.
//
// 15-May-2018   Created.
//
//////////////////////////////////////////////////////////////

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
    public void TransferWindowFormHappyPath()
    {
        string testFileName = "Forms/TestInputFile.txt";
        TransferWindowForm transferWindowForm = new TransferWindowForm();

        Assert.IsNotNull( transferWindowForm );
        transferWindowForm.ProcessFile( testFileName );
    }

    [TestMethod()]
    [ExpectedException( typeof( System.IO.FileNotFoundException ) )]
    public void TransferWindowFormWrongFileName()
    {
        const string testFileName = "WrongInputFile.txt";
        TransferWindowForm transferWindowForm = new TransferWindowForm();
        transferWindowForm.ProcessFile( testFileName );
    }
}

}
}
