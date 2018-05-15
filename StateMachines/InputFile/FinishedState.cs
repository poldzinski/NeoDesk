//////////////////////////////////////////////////////////////
//
// Finished state of an input file state machine.
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

public class FinishedState : InputFileBaseState
{

    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine to own the state.</param>
    public FinishedState( BaseStateMachine parentStateMachine ) : base( parentStateMachine )
    {
        // Nothing to do.
    }

}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
