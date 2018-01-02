using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{
    public class EmpStatus : EntityData
    {

        private int _empId;
        private StatusCode _statusCode;
        private DateTime _effDate;
        private DateTime _hireDate;

        protected EmpStatus() { }

        public EmpStatus(StatusCode statusCode, DateTime effDate, DateTime hireDate, int empId)
        {
            _empId = empId;
            _statusCode = statusCode;
            _effDate = effDate;
            _hireDate = hireDate;
        }

        /// <summary>
        /// Return all statuses for employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public IEnumerable<EmpStatus> getAllStatus(int empId)
        {
            return new List<EmpStatus>().Where(s => s._empId == empId).ToList();
        }


        /// <summary>
        /// return EmploymentStatusCode
        /// </summary>
        /// <returns></returns>
        public StatusCode GetStatusCode()
        {
            return _statusCode;
        }

        /// <summary>
        /// return Employment StatusDate
        /// </summary>
        /// <returns></returns>
        public DateTime GetEffDate()
        {
            return _effDate;
        }

        /// <summary>
        /// return Hire Date
        /// </summary>
        /// <returns></returns>
        public DateTime GetHireDate()
        {
            return _hireDate;
        }
    }

    public enum StatusCode
    {
        Active , Inactive, Terminated
    }
}