//////////////////////////////////////////////////////////////
//
// Created state of an input file state machine.
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

public class CreatedState : InputFileBaseState
{

    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine to own the state.</param>
    public CreatedState( BaseStateMachine parentStateMachine ) : base( parentStateMachine )
    {
        // Nothing to do.
    }

}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
