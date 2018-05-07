//////////////////////////////////////////////////////////////
//
// Interface of a menu item.
//
//  8-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace NeoDesk
{
namespace Menus
{
namespace MenuItems
{

abstract class BaseMenuItem
{
    /// <summary>Constructor.</summary>
    public BaseMenuItem( string description )
    {
        m_MenuItemHandle = new MenuItem();
        m_MenuItemHandle.Text = description;
    }
                
    /// <summary>Gets a item's handle.</summary>
    public MenuItem GetMenuItem()
    {
        return m_MenuItemHandle;
    }

    /// <summary>Reference to the handle of the submenu.</summary>
    private MenuItem m_MenuItemHandle;
}

} // MenuItems
} // Menus
} // NeoDesk
