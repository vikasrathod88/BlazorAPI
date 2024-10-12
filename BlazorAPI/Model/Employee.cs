using System.ComponentModel.DataAnnotations;

namespace BlazorAPI.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string GmOldEmpId { get; set; } = null!;

        public int? SapEmpId { get; set; }

        public string? PersonnelName { get; set; }

        public string? EmployeeSubgroup { get; set; }

        public int? PositionCode { get; set; }

        public string? PositionName { get; set; }

        public int? OrgUnitCode { get; set; }

        public string? OrgUnitName { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Gender { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Location { get; set; }

        public int? PostalCode { get; set; }

        public int? StateCode { get; set; }

        public string? State { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? L1ManagerCode { get; set; }

        public int? L1ManagerSapCode { get; set; }

        public string? L1ManagerName { get; set; }

    }
}
