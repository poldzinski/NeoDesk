//////////////////////////////////////////////////////////////
//
// Created state of an input file state machine.
//
// 22-Jan-2018   Created.
// 15-May-2018   Removing the class from public access.
//
//////////////////////////////////////////////////////////////

namespace NeoDesk
{
namespace StateMachines
{
namespace InputFile
{

class CreatedState : InputFileBaseState
{

    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine to own the state.</param>
    public CreatedState( BaseStateMachine parentStateMachine ) : base( parentStateMachine )
    {
        // Nothing to do.
    }

    /// <summary>Gets the ID of the state.</summary>
    /// <returns>ID of the state.</returns>
    override public StateId GetStateId()
    {
        return StateId.CREATED_STATE;
    }

}

} // namespace InputFile
} // namespace StateMachines
} // namespace NeoDesk
