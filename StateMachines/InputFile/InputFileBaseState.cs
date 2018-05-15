//////////////////////////////////////////////////////////////
//
// Interface of a input file machine's state.
//
// 22-Jan-2018   Created.
// 15-May-2018   Exception added as the default processing result.
//
//////////////////////////////////////////////////////////////

namespace NeoDesk
{
namespace StateMachines
{
namespace InputFile
{

public abstract class InputFileBaseState : BaseState
{

    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine to own the state.</param>
    public InputFileBaseState( BaseStateMachine parentStateMachine ) : base( parentStateMachine )
    {
        // Nothing to do.
    }
    
    /// <summary>Processes next input value.</summary>
    /// <param name="input">Input to be processed.</param>
    /// <returns>Result of the operation.</returns>
    virtual public bool ProcessInput( string input )
    {
        throw new System.Exception( m_ExceptionDescription );
    }

    /// <summary>Description.</summary>
    private const string m_ExceptionDescription = "Invalid state of InputFileBaseState while processing.";
}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
