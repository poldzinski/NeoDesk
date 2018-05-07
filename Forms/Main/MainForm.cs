//////////////////////////////////////////////////////////////
//
// Implementation of the main form.
//
// 30-Nov-2017   Created.
//  6-Dec-2017   Setting basic form parameters.
//
//////////////////////////////////////////////////////////////

using System.Windows.Forms;

namespace NeoDesk
{
namespace Forms
{
namespace Main
{

public class MainForm : BaseForm
{
    /// <summary>Constructor.</summary>
    public MainForm() : base ( m_MainFormCaption )
    {
        // Nothing to do.
    }

    /// <summary>Form's components organisation.</summary>
    override protected void OrganizeComponents()
    {
        MainFormMenuFactory mainMenuFactory = new MainFormMenuFactory();
        Menu = mainMenuFactory.ProduceMenu();
        m_Components.Add( Menu );
    }

    /// <summary>Main form's caption.</summary>
    private const string m_MainFormCaption = "NeoDesk";
}

} // Main
} // Forms
} // NeoDesk
