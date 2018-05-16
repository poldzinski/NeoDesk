//////////////////////////////////////////////////////////////
//
// Implementation of an options menu item.
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
namespace MenuItems
{

class OptionsMenuItem : BaseMenuItem
{
    /// <summary>Constructor.</summary>
    public OptionsMenuItem() : base( m_Description )
    {
        // Nothing to do.
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&Options...";
}

} // MenuItems
} // Menus
} // NeoDesk
