﻿#pragma checksum "..\..\LessonShowInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC57AE07F2B691BDAF3922294D2236542C8D637C17EFDCE7C432510CCEB95E29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using School_Schedule;
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
    /// LessonShowInfo
    /// </summary>
    public partial class LessonShowInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SubjectInfo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TeacherInfo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimeInfo;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander FullTeacherInfo;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander LessonInfo;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\LessonShowInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkayButton;
        
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
            System.Uri resourceLocater = new System.Uri("/School_Schedule;component/lessonshowinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LessonShowInfo.xaml"
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
            
            #line 8 "..\..\LessonShowInfo.xaml"
            ((School_Schedule.LessonShowInfo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SubjectInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TeacherInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TimeInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.FullTeacherInfo = ((System.Windows.Controls.Expander)(target));
            return;
            case 6:
            this.LessonInfo = ((System.Windows.Controls.Expander)(target));
            return;
            case 7:
            this.OkayButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\LessonShowInfo.xaml"
            this.OkayButton.Click += new System.Windows.RoutedEventHandler(this.OkayButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

