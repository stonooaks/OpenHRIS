using System;
using System.Collections.Generic;
using System.Text;

namespace Person.Interfaces
{
    public interface IMaritalStatus
    {
        int Id { get; set; }
        string Status { get; set; }
    }

    public interface IRace
    {
        int Id { get; set; }
        string RaceDesignation { get; set; }
    }
}
