using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using TabViewSample2.Core.Models;
using TabViewSample2.Views;
using TabViewSample2.Views.Controls;

namespace TabViewSample2.Proxies;
public class ProxyEmployee : ProxyTab
{
    private readonly Employee employee;
    private EmployeeDetails employeeView;

    public override string Header => employee.FullName;
    public override UserControl Content => employeeView;

    public string FirstName
    {
        get => employee.FirstName;
        set
        {
            SetProperty(employee.FirstName, value, employee, (model, v) => model.FirstName = v);
            FullName = string.Format("{0}, {1}", employee.LastName, value);
        }
    }

    public string LastName
    {
        get => employee.LastName;
        set
        {
            //Trigger the notify event
            SetProperty(employee.LastName, value, employee, (model, v) => model.LastName = v);
            //This was just a Test
            FullName = string.Format("{0}, {1}", value, employee.FirstName);
        }
    }

    public string FullName
    {
        get => employee.FullName;
        set => SetProperty(employee.FullName, value, employee, (model, v) => model.FullName = v);
    }

    public override bool IsOpen
    {
        get;
        set;
    }

    public override bool IsClosable => true;

    public ProxyEmployee(Employee employee)
    {
        this.employee = employee;
        employeeView = new EmployeeDetails(this);
        employee.FullName = string.Format("{0}, {1}", employee.LastName, employee.FirstName);
    }

    public override bool IsMatch(Employee employee)
    {
        return this.employee == employee;
    }

    //protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    //{
    //    //employee.FullName = string.Format("{0}, {1}", employee.LastName, employee.FirstName);
    //    employeeView.RaiseChange("Blank");
    //    //employeeView = new EmployeeDetails(this);
    //    base.OnPropertyChanged(e);
    //}
}
