//////////////////////////////////////////////////////////////
//
// Unit tests within TransferWindowForm.
//
// 15-May-2018   Created.
// 23-May-2018   Test of ProjectFileStateMachineImpl.
//
//////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NeoDesk.StateMachines;
using NeoDesk.Forms.TransferWindow;

namespace UnitTests
{
namespace Forms
{

[TestClass()]
public class TransferWindowFormTests
{
    [TestMethod]
    public void ProjectFileStateMachineHappyPath()
    {
        string testFileName = "Forms/TestInputFile.txt";
        ProjectFileStateMachineImpl stateMachine = new ProjectFileStateMachineImpl( testFileName );
        int linesCount = System.IO.File.ReadAllLines( testFileName ).GetLength( 0 );

        Assert.IsNotNull( stateMachine );
        Assert.IsTrue( stateMachine.GetCurrentState().GetStateId() == BaseState.StateId.CREATED_STATE );
        Assert.IsTrue( stateMachine.GetCurrentLine() == 0 );
        Assert.IsTrue( stateMachine.GetLinesCount() == linesCount );
        while ( stateMachine.ProcessInput() )
        {
            Assert.IsTrue( stateMachine.GetCurrentState().GetStateId() == BaseState.StateId.PROCESSING_STATE );
        }
        Assert.IsTrue( stateMachine.GetCurrentLine() == linesCount );
        Assert.IsTrue( stateMachine.GetCurrentState().GetStateId() == BaseState.StateId.FINISHED_STATE );
    }

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
