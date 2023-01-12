using System;
using System.Collections.Generic;
using TabViewSample2.Proxies;
using TabViewSample2.Core.Models;
using System.Collections.ObjectModel;

namespace TabViewSample2;
/// <summary>
/// Mock data keeper, should probably be a singleton
/// </summary>
public static class MockDataSet
{
    private static List<Employee> _employees;
    private static List<Employee> employees => _employees ??= mockLoad();

    private static ObservableCollection<ProxyEmployee> observableEmployees;
    public static ObservableCollection<ProxyEmployee> Employees => observableEmployees ??= loadProxies();

    public static ProxyEmployee AddNewEmpoyee()
    {
        var employee = new Employee()
        {
            FirstName = "New",
            LastName = "User",
        };

        employees.Add(employee);
        var proxy = new ProxyEmployee(employee);

        Employees.Add(proxy);
        return proxy;
    }
    private static List<Employee> mockLoad()
    {
        return new List<Employee>()
        {
            new Employee { FirstName = "John", LastName = "James", IsOpen = true },
            new Employee { FirstName = "Sally", LastName = "Saves", IsOpen = true },
            new Employee { FirstName = "Billy", LastName = "Bob", IsOpen = true },
            new Employee { FirstName = "Ralh", LastName = "Rich" }
        };
    }

    private static ObservableCollection<ProxyEmployee> loadProxies()
    {
        return new ObservableCollection<ProxyEmployee>()
        {
            new ProxyEmployee(employees[0]),
            new ProxyEmployee(employees[1]),
            new ProxyEmployee(employees[2]),
            new ProxyEmployee(employees[3])
        };
    }
}
