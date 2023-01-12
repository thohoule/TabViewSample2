using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using TabViewSample2.Core.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TabViewSample2.Proxies;
using System.ComponentModel;

namespace TabViewSample2.Views.Controls;

/// <summary>
/// Used to display the details of a proxy employee.
/// </summary>
public sealed partial class EmployeeDetails : UserControl, INotifyPropertyChanged
{
    public ProxyEmployee Employee
    {
        get;
        set;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public EmployeeDetails(ProxyEmployee employee) :
        this()
    {
        Employee = employee;
    }


    public EmployeeDetails()
    {
        this.InitializeComponent();
    }

    public void RaiseChange(string message)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(message));
        }
    }
}
