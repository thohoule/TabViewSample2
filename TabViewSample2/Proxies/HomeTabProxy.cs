using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using TabViewSample2.Core.Models;
using TabViewSample2.Views.Controls;

namespace TabViewSample2.Proxies;
public class HomeTabProxy : ProxyTab
{
    private const string HOME = "Home";

    private HomeTabControl homeControl;

    public override string Header => HOME;
    public override UserControl Content => homeControl;
    public override bool IsOpen
    {
        get => true;
        set => throw new NotImplementedException();
    }

    public override bool IsClosable => false;

    public HomeTabProxy(EmployeeTabView tabView)
    {
        homeControl = new HomeTabControl(tabView);
    }

    public override bool IsMatch(Employee employee)
    {
        return false;
    }
}
