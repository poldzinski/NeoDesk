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
        m_ProjectFileStateMachineImpl = new ProjectFileStateMachineImpl( fileName );
        SetProgressRange( 0, m_ProjectFileStateMachineImpl.GetLinesCount() );

        Start();
    }

    /// <summary>The start of the work.</summary>
    override protected void WorkerThread()
    {
        while ( m_ProjectFileStateMachineImpl.ProcessInput() )
        {
            SetProgressStage( m_ProjectFileStateMachineImpl.GetCurrentLine() );
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
    private ProjectFileStateMachineImpl m_ProjectFileStateMachineImpl;
}

} // TransferWindow
} // Forms
} // NeoDesk
