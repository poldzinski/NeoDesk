//////////////////////////////////////////////////////////////
//
// Application's main file.
//
// 30-Nov-2017   Created.
//
//////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace NeoDesk
{
namespace Main
{

static class Program
{
    /// <summary>The main entry point for the application.</summary>
    [ STAThread ]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );
        Application.Run( new Forms.Main.MainForm() );
    }
}

}
}
