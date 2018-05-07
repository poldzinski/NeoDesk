//////////////////////////////////////////////////////////////
//
// Implementation of the transfer window form.
//
// 16-Jan-2018   Created.
// 18-Jan-2018   Derive from BaseProgressForm.
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
        Start();
    }

    /// <summary>The start of the work.</summary>
    override public void WorkerThread()
    {
    }

    /// <summary>Form's components organisation.</summary>
    override protected void OrganizeComponents()
    {
        // Nothing to do.
    }

    /// <summary>Transfer window form's caption./// </summary>
    private const string m_TransferWindowFormCaption = "Transfer window";
}

} // TransferWindow
} // Forms
} // NeoDesk
