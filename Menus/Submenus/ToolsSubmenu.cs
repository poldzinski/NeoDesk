//////////////////////////////////////////////////////////////
//
// Implementation of the tools submenu.
//
// 16-May-2018   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace NeoDesk
{
namespace Menus
{
namespace Submenus
{

class ToolsSubmenu : BaseSubmenu
{
    /// <summary>Constructor.</summary>
    public ToolsSubmenu() : base( m_Description )
    {
        // Nothing to do.
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&Tools";
}

} // Submenus
} // Menus
} // NeoDesk
