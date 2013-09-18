using System;
using System.Text;
using System.Collections.Generic;
using PlugInLib;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Reflection;

namespace Plateso2
{
    public partial class Window1 : Window
    {

        #region LoadPlugIns

        void LoadPlugIns()
        {
            string[] pluginFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            PlugInContext context = new PlugInContext(this.stackTopButtons, this.svTextViewer, this.tvRoot);
            
            foreach (string file in pluginFiles)
            {                
                Assembly asm;
                asm = Assembly.LoadFile(file);
                if (asm != null)
                {
                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        if (typeof(IPlugIn).IsAssignableFrom(t))
                        {                            
                            try
                            {
                                IPlugIn plugin = (IPlugIn)Activator.CreateInstance(t);
                                plugin.Context = context;
                                plugin.PerformAction();
                            }
                            catch { }
                        }
                    }
                }
            }

            foreach (UIElement uiElement in stackTopButtons.Children)
            {
                if (typeof(Button).IsAssignableFrom(uiElement.GetType()))
                {
                    try
                    {
                        Button button = (Button)uiElement;
                        if (button.Style != (Style)(App.Current.TryFindResource("style_MainButtons")))
                        {
                            button.Style = (Style)(App.Current.TryFindResource("style_MainButtons"));
                            button.Width = 45;
                        }
                    }
                    catch { }
                }
            }

        }

        #endregion

        #region PlugInContext

        public class PlugInContext : IPlugInContext
        {
            StackPanel topButtonsStack;
            ScrollViewer contentViewer;
            TreeView treeViewHost;

            public PlugInContext(StackPanel topButtonsStack,ScrollViewer contentViewer,TreeView treeViewHost)
            {
                this.topButtonsStack = topButtonsStack;
                this.contentViewer = contentViewer;
                this.treeViewHost = treeViewHost;
            }

            public StackPanel TopButtonsStack
            {
                get { return topButtonsStack; }
            }
            public ScrollViewer ContentViewer
            {
                get { return contentViewer; }
            }
            public TreeView TreeViewParent
            {
                get { return treeViewHost; }
            }
        }

        #endregion

    }

}