//////////////////////////////////////////////////////////////
//
// Implementation of a state machine for the project file.
//
// 29-Mar-2018   Created.
// 15-May-2018   File name parameter added to the constructor.
// 23-May-2018   Implementation added.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;
using NeoDesk.StateMachines;
using NeoDesk.StateMachines.InputFile;

namespace NeoDesk
{
namespace Forms
{
namespace TransferWindow
{

public class ProjectFileStateMachineImpl : InputFileStateMachine
{
    /// <summary>Constructor.</summary>
    /// <param name="inputFileName">Name of a file to be processed.</param>
    public ProjectFileStateMachineImpl( string inputFileName ) : base( inputFileName )
    {
        m_Created = new CreatedState( this );
        m_Processing = new ProcessingState( this );
        m_Finished = new FinishedState( this );

        AddState( m_Created );
        AddState( m_Processing );
        AddState( m_Finished );

        GoToState( m_Created );
    }
        
    /// <summary>Processes next input value.</summary>
    /// <returns>Result of the operation.</returns>
    override public bool ProcessInput()
    {
        GoToState( m_Processing );

        bool baseResult = base.ProcessInput();

        if ( baseResult == false )
        {    
            GoToState( m_Finished );
        }

        return baseResult;
    }

    /// <summary>State after creating.</summary>    
    private InputFileBaseState m_Created;
    /// <summary>State while processing.</summary>    
    private InputFileBaseState m_Processing;
    /// <summary>State after finishing.</summary>    
    private InputFileBaseState m_Finished;

}

} // namespace TransferWindow
} // namespace Forms
} // namespace NeoDesk
