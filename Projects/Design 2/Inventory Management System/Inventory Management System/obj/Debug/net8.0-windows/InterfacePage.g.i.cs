// Updated by XamlIntelliSenseFileGenerator 26/12/2024 10:16:48 pm
#pragma checksum "..\..\..\InterfacePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3581EC7DB40DFD81566DC21BA07B58309155FA49"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Inventory_Management_System
{


	/// <summary>
	/// InterfacePage
	/// </summary>
	public partial class InterfacePage : System.Windows.Window, System.Windows.Markup.IComponentConnector
	{

#line default
#line hidden

		private bool _contentLoaded;

		/// <summary>
		/// InitializeComponent
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
		public void InitializeComponent()
		{
			if (_contentLoaded)
			{
				return;
			}
			_contentLoaded = true;
			System.Uri resourceLocater = new System.Uri("/Inventory Management System;component/interfacepage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\InterfacePage.xaml"
			System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
				case 1:

#line 73 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DashboardButton_Click);

#line default
#line hidden
					return;
				case 2:

#line 74 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ProductManagementButton_Click);

#line default
#line hidden
					return;
				case 3:

#line 75 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InventoryTrackingButton_Click);

#line default
#line hidden
					return;
				case 4:

#line 77 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PurchaseOrderManagementButton_Click);

#line default
#line hidden
					return;
				case 5:

#line 78 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SalesOrderManagementButton_Click);

#line default
#line hidden
					return;
				case 6:

#line 79 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StockMovementButton_Click);

#line default
#line hidden
					return;
				case 7:

#line 81 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SupplierManagementButton_Click);

#line default
#line hidden
					return;
				case 8:

#line 82 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomerManagementButton_Click);

#line default
#line hidden
					return;
				case 9:

#line 83 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReportsAndAnalyticsButton_Click);

#line default
#line hidden
					return;
				case 10:

#line 85 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReorderAlertsButton_Click);

#line default
#line hidden
					return;
				case 11:

#line 86 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UserManagementButton_Click);

#line default
#line hidden
					return;
				case 12:

#line 87 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuditLogsButton_Click);

#line default
#line hidden
					return;
				case 13:

#line 89 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BarcodeScanningButton_Click);

#line default
#line hidden
					return;
				case 14:

#line 90 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsCenterButton_Click);

#line default
#line hidden
					return;
				case 15:

#line 91 "..\..\..\InterfacePage.xaml"
					((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButton_Click);

#line default
#line hidden
					return;
				case 16:
					this.MainFrame = ((System.Windows.Controls.Frame)(target));
					return;
			}
			this._contentLoaded = true;
		}
	}
}

