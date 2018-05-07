//////////////////////////////////////////////////////////////
//
// Interface of a input file machine's state.
//
// 22-Jan-2018   Created.
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
    
    /// <summary>Processes input as a string.</summary>
    /// <param name="input">String input.</param>
    /// <returns>Result of the operation.</returns>
    public bool ProcessInput( string input )
    {
        return false;
    }

}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
