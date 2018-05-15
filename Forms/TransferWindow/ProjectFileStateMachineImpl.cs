//////////////////////////////////////////////////////////////
//
// Implementation of a state machine for the project file.
//
// 29-Mar-2018   Created.
// 15-May-2018   File name parameter added to the constructor.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;
using NeoDesk.StateMachines;
using NeoDesk.StateMachines.InputFile;

namespace NeoDesk
{
namespace Forms
{
namespace TransferWindow
{

public class ProjectFileStateMachineImpl : InputFileStateMachine
{
    /// <summary>Constructor.</summary>
    /// <param name="inputFileName">Name of a file to be processed.</param>
    public ProjectFileStateMachineImpl( string inputFileName ) : base ( inputFileName )
    {
    }
        
}

} // namespace TransferWindow
} // namespace Forms
} // namespace NeoDesk
