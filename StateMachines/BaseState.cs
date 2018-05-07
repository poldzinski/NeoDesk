//////////////////////////////////////////////////////////////
//
// Interface of a machine's state.
//
// 22-Jan-2018   Created.
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

    /// <summary>A state machine that owns the state.</summary>
    protected BaseStateMachine m_StateMachine;
}

} // namespace StateMachines
} // namespace NeoDesk
