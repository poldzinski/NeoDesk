//////////////////////////////////////////////////////////////
//
// Processing state of an input file state machine.
//
// 15-May-2018   Created.
//
//////////////////////////////////////////////////////////////

namespace NeoDesk
{
namespace StateMachines
{
namespace InputFile
{

class ProcessingState : InputFileBaseState
{

    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine to own the state.</param>
    public ProcessingState( BaseStateMachine parentStateMachine ) : base( parentStateMachine )
    {
        // Nothing to do.
    }

    /// <summary>Gets the ID of the state.</summary>
    /// <returns>ID of the state.</returns>
    override public StateId GetStateId()
    {
        return StateId.PROCESSING_STATE;
    }

    /// <summary>Processes next input value.</summary>
    /// <param name="input">Input to be processed.</param>
    /// <returns>Result of the operation.</returns>
    override public bool ProcessInput( string input )
    {
        System.Threading.Thread.Sleep( 10 );
        return true;
    }

}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
