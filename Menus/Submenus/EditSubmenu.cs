//////////////////////////////////////////////////////////////
//
// Implementation of the edit submenu.
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
namespace Submenus
{

class EditSubmenu : BaseSubmenu
{
    /// <summary>Constructor.</summary>
    public EditSubmenu() : base( m_Description )
    {
        // Nothing to do.
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&Edit";
}

} // Submenus
} // Menus
} // NeoDesk
