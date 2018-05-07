//////////////////////////////////////////////////////////////
//
// Implementation of a factory to produce menus for forms.
//
//  8-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Windows.Forms;

namespace NeoDesk
{
namespace Menus
{

abstract class MenuFactory
{
    /// <summary>Constructor.</summary>
    public MenuFactory()
    {
        m_Menu = new MainMenu();
        m_Submenus = new List< Submenus.BaseSubmenu >();
        m_MenuItems = new Dictionary< Submenus.BaseSubmenu, List< MenuItems.BaseMenuItem > >();
    }

    /// <summary>Gets the menu's handle.</summary>
    /// <returns>Handle of the menu.</returns>
    public MainMenu ProduceMenu()
    {
        FillMenu();
        return m_Menu;
    }

    /// <summary>Adding collected submenus and menu items.</summary>
    protected void FillMenu()
    {
        m_Menu.MenuItems.Clear();
        AddSubmenus();
    }

    /// <summary>Adding collected submenus.</summary>
    private void AddSubmenus()
    {
        foreach ( Submenus.BaseSubmenu submenu in m_Submenus )
        {
            m_Menu.MenuItems.Add( submenu.GetSubmenu() );
            m_MenuItems[ submenu ] = new List< MenuItems.BaseMenuItem >();
            AddMenuItems( submenu );
        }
    }

    /// <summary>Adding collected menu items.</summary>
    /// <param name="submenu">Points to a particular submenu.</param>
    private void AddMenuItems( Submenus.BaseSubmenu submenu )
    {
        foreach ( MenuItems.BaseMenuItem menuItem in m_MenuItems[ submenu ] )
        {
            submenu.GetSubmenu().MenuItems.Add( menuItem.GetMenuItem() );
        }
    }

    /// <summary>List of submenus.</summary>
    protected List< Submenus.BaseSubmenu > m_Submenus;
    /// <summary>Collection of menu items.</summary>
    protected Dictionary< Submenus.BaseSubmenu, List< MenuItems.BaseMenuItem > > m_MenuItems;
    /// <summary>Handle of the menu.</summary>
    private MainMenu m_Menu;
}

} // Menus
} // NeoDesk
