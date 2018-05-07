//////////////////////////////////////////////////////////////
//
// Implementation of the main form's main menu factory.
//
//  8-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Windows.Forms;

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
    }

    /// <summary>Opens a dialog window to point a file.</summary>
    private void OpenFileChosen( object sender, System.EventArgs eventArguments )
    {
        string fileName = m_OpenFileMenuItem.GetFileName();

        if ( fileName.Length > 0U )
        {
            TransferWindow.TransferWindowForm transferWindow = new TransferWindow.TransferWindowForm();

            transferWindow.ProcessFile( fileName );
        }
    }

    /// <summary>The 'File' submenu.</summary>
    private Menus.Submenus.FileSubmenu m_FileSubmenu = new Menus.Submenus.FileSubmenu();
    /// <summary>The 'Open file...' menu item.</summary>
    private Menus.MenuItems.OpenFileMenuItem m_OpenFileMenuItem = new Menus.MenuItems.OpenFileMenuItem();
    /// <summary>The 'Exit' menu item.</summary>
    private Menus.MenuItems.ExitMenuItem m_ExitMenuItem = new Menus.MenuItems.ExitMenuItem();
    /// <summary>The 'Edit' submenu.</summary>
    private Menus.Submenus.EditSubmenu m_EditSubmenu = new Menus.Submenus.EditSubmenu();
}

} // Main
} // Forms
} // NeoDesk
