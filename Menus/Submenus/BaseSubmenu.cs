//////////////////////////////////////////////////////////////
//
// Interface of a submenu.
//
//  8-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace NeoDesk
{
namespace Menus
{
namespace Submenus
{

abstract class BaseSubmenu
{
    /// <summary>Constructor.</summary>
    public BaseSubmenu( string description )
    {
        m_SubmenuHandle = new MenuItem();
        m_SubmenuHandle.Text = description;
        m_MenuItems = new List< MenuItems.BaseMenuItem >();
    }
                
    /// <summary>Adds a menu item.</summary>
    public void AddMenuItem( MenuItems.BaseMenuItem menuItem )
    {
        m_MenuItems.Add( menuItem );
        m_SubmenuHandle.MenuItems.Add( menuItem.GetMenuItem() );
    }

    /// <summary>Gets a submenu's handle.</summary>
    public MenuItem GetSubmenu()
    {
        return m_SubmenuHandle;
    }

    /// <summary>Gets a list of menu items.</summary>
    public List< MenuItems.BaseMenuItem > GetMenuItems()
    {
        return m_MenuItems;
    }

    /// <summary>List of menu items.</summary>
    private List< MenuItems.BaseMenuItem > m_MenuItems;
    /// <summary>Reference to the handle of the submenu.</summary>
    private MenuItem m_SubmenuHandle;
}

} // Submenus
} // Menus
} // NeoDesk
