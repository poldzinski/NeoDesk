//////////////////////////////////////////////////////////////
//
// Implementation of a exit menu item.
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

class ExitMenuItem : BaseMenuItem
{
    /// <summary>Constructor.</summary>
    public ExitMenuItem() : base( m_Description )
    {
        // Nothing to do.
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&Exit";
}

} // MenuItems
} // Menus
} // NeoDesk
