//////////////////////////////////////////////////////////////
//
// Implementation of the file submenu.
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

class FileSubmenu : BaseSubmenu
{
    /// <summary>Constructor.</summary>
    public FileSubmenu() : base( m_Description )
    {
        // Nothing to do.
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&File";
}

} // Submenus
} // Menus
} // NeoDesk
