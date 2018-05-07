//////////////////////////////////////////////////////////////
//
// Base state machine.
//
// 22-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace NeoDesk
{
namespace StateMachines
{

public abstract class BaseStateMachine
{
    /// <summary>Returns the current state.</summary>
    /// <returns>The current state.</returns>
    public BaseState GetCurrentState()
    {
        return m_CurrentState;
    }

    /// <summary>Adds state to the list of states.</summary>
    /// <param name="newState">A state to be added.</param>
    protected void AddState( BaseState newState )
    {
        m_States.Add( newState );
    }

    /// <summary>Changes the current state.</summary>
    /// <param name="newState">The next state.</param>
    protected void GoToState( BaseState newState )
    {
        m_CurrentState = newState;
    }

    /// <summary>Current state.</summary>
    private BaseState m_CurrentState;
    /// <summary>Machine's states.</summary>
    private List< BaseState > m_States = new List<BaseState>();
}

} // namespace StateMachines
} // namespace NeoDesk
