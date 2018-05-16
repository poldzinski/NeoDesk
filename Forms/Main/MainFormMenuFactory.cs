//////////////////////////////////////////////////////////////
//
// Implementation of the main form's main menu factory.
//
//  8-Jan-2018   Created.
// 16-May-2018   Tools submenu added.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Windows.Forms;

using NeoDesk.Menus.MenuItems;
using NeoDesk.Menus.Submenus;

namespace NeoDesk
{
namespace Forms
{
namespace Main
{

class MainFormMenuFactory : Menus.MenuFactory
{
    /// <summary>Constructor.</summary>
    public MainFormMenuFactory() : base()
    {
        m_Submenus.Add( m_FileSubmenu );
        m_FileSubmenu.AddMenuItem( m_OpenFileMenuItem );
        m_FileSubmenu.AddMenuItem( m_ExitMenuItem );

        m_OpenFileMenuItem.GetMenuItem().Click += OpenFileChosen;
        m_ExitMenuItem.GetMenuItem().Click += ( sender, eventArguments ) => Application.Exit();

        m_Submenus.Add( m_EditSubmenu );

        m_Submenus.Add( m_ToolsSubmenu );
        m_ToolsSubmenu.AddMenuItem( m_OptionsMenuItem );
    }

    /// <summary>Opens a dialog window to point a file.</summary>
    private void OpenFileChosen( object sender, System.EventArgs eventArguments )
    {
        OpenFileMenuItem menuItem = m_OpenFileMenuItem as OpenFileMenuItem;
        string fileName = menuItem.GetFileName();

        if ( fileName.Length > 0U )
        {
            TransferWindow.TransferWindowForm transferWindow = new TransferWindow.TransferWindowForm();

            transferWindow.ProcessFile( fileName );
        }
    }

    /// <summary>The 'File' submenu.</summary>
    private BaseSubmenu m_FileSubmenu = new FileSubmenu();
    /// <summary>The 'Open file...' menu item.</summary>
    private BaseMenuItem m_OpenFileMenuItem = new OpenFileMenuItem();
    /// <summary>The 'Exit' menu item.</summary>
    private BaseMenuItem m_ExitMenuItem = new ExitMenuItem();
    /// <summary>The 'Edit' submenu.</summary>
    private BaseSubmenu m_EditSubmenu = new EditSubmenu();
    /// <summary>The 'Tools' submenu.</summary>
    private BaseSubmenu m_ToolsSubmenu = new ToolsSubmenu();
    /// <summary>The 'Options' menu item.</summary>
    private BaseMenuItem m_OptionsMenuItem = new OptionsMenuItem();
}

} // Main
} // Forms
} // NeoDesk
