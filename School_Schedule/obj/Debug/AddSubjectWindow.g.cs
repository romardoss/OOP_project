#pragma checksum "..\..\AddSubjectWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B309FAEC0E29E310A7A152A8378FD304023D2C37D5D4D4B108CF9FDF86A135E9"
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


namespace School_Schedule {
    
    
    /// <summary>
    /// AddSubjectWindow
    /// </summary>
    public partial class AddSubjectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoseSubject;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoseTeacher;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewSubjectButton;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewTeacherButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartTime;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndTime;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoseDayOfWeek;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfLesson;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\AddSubjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AcceptButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/School_Schedule;component/addsubjectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddSubjectWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\AddSubjectWindow.xaml"
            ((School_Schedule.AddSubjectWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChoseSubject = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ChoseTeacher = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.AddNewSubjectButton = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\AddSubjectWindow.xaml"
            this.AddNewSubjectButton.Click += new System.Windows.RoutedEventHandler(this.AddNewSubjectButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddNewTeacherButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\AddSubjectWindow.xaml"
            this.AddNewTeacherButton.Click += new System.Windows.RoutedEventHandler(this.AddNewTeacherButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.EndTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ChoseDayOfWeek = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.CheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 76 "..\..\AddSubjectWindow.xaml"
            this.CheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 76 "..\..\AddSubjectWindow.xaml"
            this.CheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DateOfLesson = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\AddSubjectWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.AcceptButton = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\AddSubjectWindow.xaml"
            this.AcceptButton.Click += new System.Windows.RoutedEventHandler(this.AcceptButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

