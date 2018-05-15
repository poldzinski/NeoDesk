//////////////////////////////////////////////////////////////
//
// Implementation of the transfer window form.
//
// 16-Jan-2018   Created.
// 18-Jan-2018   Derive from BaseProgressForm.
// 15-May-2018   Assembling the progress bar with the file state machine.
//               Unneeded public method changed to protected.
//
//////////////////////////////////////////////////////////////

using System.IO;

namespace NeoDesk
{
namespace Forms
{
namespace TransferWindow
{

public class TransferWindowForm : BaseProgressForm
{
    /// <summary>Constructor.</summary>
    public TransferWindowForm() : base( m_TransferWindowFormCaption )
    {
        // Nothing to do.
    }

    /// <summary>Processes pointed file.</summary>
    /// <param name="fileName">The name of a file.</param>
    public void ProcessFile( string fileName )
    {
        m_InputFileStateMachine = new StateMachines.InputFile.InputFileStateMachine( fileName );
        SetProgressRange( 0, m_InputFileStateMachine.GetLinesCount() );

        Start();
    }

    /// <summary>The start of the work.</summary>
    override protected void WorkerThread()
    {
        while ( m_InputFileStateMachine.ProcessInput() )
        {
            SetProgressStage( m_InputFileStateMachine.GetCurrentLine() );
        }
    }

    /// <summary>Form's components organisation.</summary>
    override protected void OrganizeComponents()
    {
        // Nothing to do.
    }

    /// <summary>Transfer window form's caption./// </summary>
    private const string m_TransferWindowFormCaption = "Transfer window";
    /// <summary>State machine to process an input file.</summary>
    private StateMachines.InputFile.InputFileStateMachine m_InputFileStateMachine;
}

} // TransferWindow
} // Forms
} // NeoDesk
