namespace CRUDEntity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDEntity.Models.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CRUDEntity.Models.EmployeeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // viết entity vào 
            context.Departments.AddOrUpdate(x => x.DepartmentID, 
                new Models.Department { DepartmentID = 1, NameOfDepart = "IT" },
                new Models.Department { DepartmentID = 2, NameOfDepart = "Support" },
                new Models.Department { DepartmentID = 3, NameOfDepart = "Nhan su" });

            context.Employees.AddOrUpdate(x => x.EmployeeID,
                new Models.Employee { EmployeeID = 1001, NameEmployee = "Tran van a", DepartmentID = 1 },
                new Models.Employee { EmployeeID = 1002, NameEmployee = "Nguyen van c", DepartmentID = 2 },
                new Models.Employee { EmployeeID = 1003, NameEmployee = "Nguyen van b", DepartmentID = 2 },
                new Models.Employee { EmployeeID = 1004, NameEmployee = "Nguyen thi c", DepartmentID = 3 });
        }
    }
}
