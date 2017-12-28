using System;
using System.Collections.Generic;
using System.Text;

namespace HRIS.Interfaces
{
    public abstract class EntityData
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
