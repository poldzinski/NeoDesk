//////////////////////////////////////////////////////////////
//
// Base state machine for an input file.
//
// 22-Jan-2018   Created.
// 15-May-2018   Processing and finished states added.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace NeoDesk
{
namespace StateMachines
{
namespace InputFile
{

public class InputFileStateMachine : BaseStateMachine
{
    /// <summary>Constructor.</summary>
    /// <param name="inputFileName">Name of a file to be processed.</param>
    public InputFileStateMachine( string inputFileName )
    {
        m_Created = new CreatedState( this );
        m_Processing = new ProcessingState( this );
        m_Finished = new ProcessingState( this );

        AddState( m_Created );
        AddState( m_Processing );
        AddState( m_Finished );

        GoToState( m_Created );

        m_Lines = System.IO.File.ReadAllLines( inputFileName );
        m_CurrentLine = 0;

        GoToState( m_Processing );
    }

    /// <summary>Processes next input value.</summary>
    /// <returns>Result of the operation.</returns>
    public bool ProcessInput()
    {
        InputFileBaseState currentState = GetCurrentState() as InputFileBaseState;

        if ( m_CurrentLine < GetLinesCount() )
        {
            return currentState.ProcessInput( m_Lines[ m_CurrentLine++ ] );
        }

        GoToState( m_Finished );

        return false;
    }

    /// <summary>Returns number of lines in the input file.</summary>
    /// <returns>Number of lines in the input file.</returns>
    public int GetLinesCount()
    {
        return m_Lines.GetLength( 0 );
    }

    /// <summary>Returns the current line.</summary>
    /// <returns>The current line.</returns>
    public int GetCurrentLine()
    {
        return m_CurrentLine;
    }

    /// <summary>State after creating.</summary>    
    private InputFileBaseState m_Created;
    /// <summary>State while processing.</summary>    
    private InputFileBaseState m_Processing;
    /// <summary>State after finishing.</summary>    
    private InputFileBaseState m_Finished;
    /// <summary>File's content.</summary>
    private string[] m_Lines;
    /// <summary>Current line to be processed.</summary>
    private int m_CurrentLine;
}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
