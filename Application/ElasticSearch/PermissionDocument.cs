namespace Application.ElasticSearchEntities
{
    public class PermissionDocument
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }
    }

}
