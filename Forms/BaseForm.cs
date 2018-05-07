//////////////////////////////////////////////////////////////
//
// Implementation of the abstract window form.
//
// 16-Jan-2018   Created.
//
//////////////////////////////////////////////////////////////

using System.Windows.Forms;

namespace NeoDesk
{
namespace Forms
{

abstract public class BaseForm : Form
{
    /// <summary>Constructor.</summary>
    /// <param name="description">Description to be set.</param>
    public BaseForm( string description )
    {
        m_Components = new System.ComponentModel.Container();

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        StartPosition = FormStartPosition.CenterScreen;

        OrganizeComponents();

        Text = description;
    }

    /// <summary>Form's components organisation.</summary>
    abstract protected void OrganizeComponents();

    /// <summary>Required designer variable.</summary>
    protected System.ComponentModel.IContainer m_Components = null;

    /// <summary>Clean up any resources being used.</summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
        if ( ( disposing == true ) && ( m_Components != null ) )
        {
            m_Components.Dispose();
        }
        base.Dispose( disposing );
    }
}

} // Forms
} // NeoDesk
