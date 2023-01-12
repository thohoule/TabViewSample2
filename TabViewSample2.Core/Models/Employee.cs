using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TabViewSample2.Core.Models;
public class Employee
{
    public string FirstName
    {
        get;
        set;
    }
    public string LastName
    {
        get; set;
    }

    public bool IsOpen { get; set; }

    public string FullName { get; set; }
}
