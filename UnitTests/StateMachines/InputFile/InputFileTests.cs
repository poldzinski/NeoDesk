//////////////////////////////////////////////////////////////
//
// Unit tests within StateMachines and InputFile.
//
// 15-May-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NeoDesk.StateMachines;
using NeoDesk.StateMachines.InputFile;

namespace UnitTests
{
namespace StateMachines
{
namespace InputFile
{

[TestClass]
public class InputFileTests
{
    [TestMethod]
    public void InputFileHappyPath()
    {
        string testFileName = "Forms/TestInputFile.txt";
        InputFileStateMachine stateMachine = new InputFileStateMachine( testFileName );
        int linesCount = System.IO.File.ReadAllLines( testFileName ).GetLength( 0 );

        Assert.IsNotNull( stateMachine );
        Assert.IsTrue( stateMachine.GetCurrentState().GetStateId() == BaseState.StateId.PROCESSING_STATE );
        Assert.IsTrue( stateMachine.GetCurrentLine() == 0 );
        Assert.IsTrue( stateMachine.GetLinesCount() == linesCount );
        while ( stateMachine.ProcessInput() )
        {
        }
        Assert.IsTrue( stateMachine.GetCurrentLine() == linesCount );
        Assert.IsTrue( stateMachine.GetCurrentState().GetStateId() == BaseState.StateId.FINISHED_STATE );
    }

    [TestMethod]
    [ExpectedException( typeof( System.IO.FileNotFoundException ) )]
    public void InputFileWrongFileName()
    {
        string testFileName = "WrongFile.txt";
        InputFileStateMachine stateMachine = new InputFileStateMachine( testFileName );
    }
}

} // InputFile
} // StateMachines
} // UnitTests
