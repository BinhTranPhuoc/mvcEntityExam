namespace CRUDEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [StringLength(100)]
        public string NameEmployee { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}
