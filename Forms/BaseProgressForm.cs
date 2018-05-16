//////////////////////////////////////////////////////////////
//
// Implementation of the abstract progress window form.
//
// 18-Jan-2018   Created.
// 15-May-2018   Setting stage of the progress bar safely.
//               Unneeded public method changed to protected.
//
//////////////////////////////////////////////////////////////

using System.ComponentModel;
using System.Windows.Forms;

namespace NeoDesk
{
namespace Forms
{

abstract public class BaseProgressForm : BaseForm
{
    /// <summary>Constructor.</summary>
    /// <param name="description">Description to be set.</param>
    public BaseProgressForm( string description ) : base( description )
    {
        MinimizeBox = false;
        MaximizeBox = false;
        ControlBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;

        FormClosing += ( sender, eventArguments ) => eventArguments.Cancel = true;
        progressWorker.DoWork += ( sender, eventArguments ) => WorkerThread();
        progressWorker.RunWorkerCompleted += ( sender, eventArguments ) => Dispose();

        progressBar.Dock = DockStyle.Top;
        Controls.Add( progressBar );

        m_Components.Add( progressBar );
    }

    /// <summary>The triger to start the work.</summary>
    public void Start()
    {
        progressWorker.RunWorkerAsync();
        ShowDialog();
    }

    /// <summary>The start of the work.</summary>
    abstract protected void WorkerThread();

    /// <summary>Sets progress bar's range.</summary>
    /// <param name="start">The start value.</param>
    /// <param name="finish">The finish value.</param>
    public void SetProgressRange( int start, int finish )
    {
        progressBar.Minimum = start;
        progressBar.Maximum = finish;
    }

    /// <summary>Sets progress bar's range.</summary>
    /// <param name="stage">The stage of the progress.</param>
    public void SetProgressStage( int stage )
    {
        Invoke( new SettingProgressStageDelegate( SettingProgressStage ), stage );
    }

    /// <summary>Sets safely progress bar's range.</summary>
    /// <param name="stage">The stage of the progress.</param>
    private void SettingProgressStage( int stage )
    {
        progressBar.Value = stage;
    }

    /// <summary>Background worker for the process of progress.</summary>
    private BackgroundWorker progressWorker = new BackgroundWorker();
    /// <summary>Progress bar.</summary>
    private ProgressBar progressBar = new ProgressBar();

    /// <summary>Setting progress stage delegate.</summary>
    /// <param name="stage">The stage of the progress.</param>
    private delegate void SettingProgressStageDelegate( int stage );

}

} // Forms
} // NeoDesk
