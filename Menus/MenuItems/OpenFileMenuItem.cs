//////////////////////////////////////////////////////////////
//
// Implementation of a open file menu item.
//
// 11-Jan-2018   Created.
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

class OpenFileMenuItem : BaseMenuItem
{
    /// <summary>Constructor.</summary>
    public OpenFileMenuItem() : base( m_Description )
    {
        // Nothing to do.
    }

    /// <summary>Shows a open file dialog and get a file name out if it.</summary>
    /// <returns>Name of the chosen file.</returns>
    public string GetFileName()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        if ( openFileDialog.ShowDialog() == DialogResult.OK )
        {
            return openFileDialog.FileName;
        }

        return "";
    }
                
    /// <summary>Description.</summary>
    private const string m_Description = "&Open file...";
}

} // MenuItems
} // Menus
} // NeoDesk
