//////////////////////////////////////////////////////////////
//
// Interface of a machine's state.
//
// 22-Jan-2018   Created.
// 15-May-2018   A method for retrieving state ID added.
//
//////////////////////////////////////////////////////////////

namespace NeoDesk
{
namespace StateMachines
{

public abstract class BaseState
{
    /// <summary>Constructor.</summary>
    /// <param name="parentStateMachine">A state machine that owns the state.</param>
    public BaseState( BaseStateMachine parentStateMachine )
    {
        m_StateMachine = parentStateMachine;
    }

    /// <summary>Gets the ID of the state.</summary>
    /// <returns>ID of the state.</returns>
    abstract public StateId GetStateId();

    /// <summary>ID of the states.</summary>
    public enum StateId
    {
        CREATED_STATE,
        PROCESSING_STATE,
        FINISHED_STATE,
        STATES_COUNT
    }

    /// <summary>A state machine that owns the state.</summary>
    protected BaseStateMachine m_StateMachine;
}

} // namespace StateMachines
} // namespace NeoDesk
