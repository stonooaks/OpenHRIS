using HRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Entities
{
    public class Account : EntityData
    {
        public string accountNumber { get; set; }
        public Unit unit { get; set; }
        public Entity entity { get; set; }
        public Project project { get; set; }
        public Reporting reporting { get; set; }
    }

    public class Reporting : EntityData
    {
    }

    public class Project : EntityData
    {
    }

    public class Entity : EntityData
    {
    }

    public class Unit : EntityData
    {
    }
}
