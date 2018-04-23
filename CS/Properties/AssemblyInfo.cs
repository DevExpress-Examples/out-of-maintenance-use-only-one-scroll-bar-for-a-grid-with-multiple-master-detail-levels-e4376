// Developer Express Code Central Example:
// Use only one scroll bar for a grid with multiple master/detail levels.
// 
// A grid containing a number of groups (master), each with a number of lines
// (detail) is a representation of an order which is grouped for readability. When
// a group has a greater number of lines then fits on the screen, a scrollbar is
// added to the detail-view and when there are multiple groups the master-view also
// gets a scrollbar. When the user scrolls through the grid, only the master-view
// is scrolled (unless a row is selected, then only the detail-view is scrolled)
// and it feels like the program is behaving oddly, as half the rows are
// skipped.
// To achieve this goal, we need the GridControl to have a height equal
// to the height of all content placed in a master-view. So, the scrollbar does not
// appear in either the master-view or in the detail-view. To allow scrolling, we
// need to put our GridControl into a XtraScrollableControl and set the
// GridControl.Dock property to DockStyle.Top.
// We created the MyGridControl class
// - a descendant of the GridControl. MyGridControl works with MyGridView views and
// includes the CalcGridHeight() method, which is called when the appearance of the
// Master-View is changed.
// To put MyGridControl in the XtraScrollableContainer,
// use the MyGridControl.InitScrolling() method at runtime.
// Please note that if
// you want to change Bounds or Dock properties of MyGridControl at runtime, change
// similar properties of the MyGridControl.ScrollableContainer control.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4376

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("task41 Master-details")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("task41 Master-details")]
[assembly: AssemblyCopyright("Copyright ©  2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("bb7562b4-2637-4989-8b6f-b9e3516b4f85")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
