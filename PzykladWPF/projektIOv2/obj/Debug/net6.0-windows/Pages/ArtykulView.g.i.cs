﻿#pragma checksum "..\..\..\..\Pages\ArtykulView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97AF374D305B54E6FE0BE52D63D5052821924DEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
using projektIOv2;
using projektIOv2.Controls;
using projektIOv2.Converters;
using projektIOv2.Pages;


namespace projektIOv2.Pages {
    
    
    /// <summary>
    /// ArtykulView
    /// </summary>
    public partial class ArtykulView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal projektIOv2.Controls.ErrorBox errorBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem search;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer sg1;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid naw1;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button poprzedniArtykul;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nastepnyArtykul;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\..\Pages\ArtykulView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu bardmenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projektIOv2;V1.0.0.0;component/pages/artykulview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ArtykulView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Pages\ArtykulView.xaml"
            ((projektIOv2.Pages.ArtykulView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.errorBox = ((projektIOv2.Controls.ErrorBox)(target));
            return;
            case 3:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 82 "..\..\..\..\Pages\ArtykulView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.search = ((System.Windows.Controls.MenuItem)(target));
            
            #line 103 "..\..\..\..\Pages\ArtykulView.xaml"
            this.search.Click += new System.Windows.RoutedEventHandler(this.search_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.sg1 = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.naw1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.poprzedniArtykul = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\..\Pages\ArtykulView.xaml"
            this.poprzedniArtykul.Click += new System.Windows.RoutedEventHandler(this.nastepnyArtykul_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.nastepnyArtykul = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\..\..\Pages\ArtykulView.xaml"
            this.nastepnyArtykul.Click += new System.Windows.RoutedEventHandler(this.poprzedniArtykul_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 200 "..\..\..\..\Pages\ArtykulView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gpt_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 221 "..\..\..\..\Pages\ArtykulView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.reloadgpt_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.bardmenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 13:
            
            #line 263 "..\..\..\..\Pages\ArtykulView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Bard_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

