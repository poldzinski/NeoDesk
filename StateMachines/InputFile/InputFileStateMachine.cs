//////////////////////////////////////////////////////////////
//
// Base state machine for an input file.
//
// 22-Jan-2018   Created.
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
    public InputFileStateMachine()
    {
        m_Created = new CreatedState( this );

        AddState( m_Created );

        GoToState( m_Created );
    }

    /// <summary>Process an input value.</summary>
    /// <param name="input">Input value to be processed.</param>
    /// <returns>Result of the operation.</returns>
    public bool ProcessInput( string input )
    {
        InputFileBaseState currentState = GetCurrentState() as InputFileBaseState;

        return currentState.ProcessInput( input );
    }

    /// <summary>State after creating.</summary>    
    private InputFileBaseState m_Created;
}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
