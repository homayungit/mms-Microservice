namespace Configure.API.Models;

public class ConfigureType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? SerialNo { get; set; }

    [MaxLength(200)]
    public string? Name { get; set; }

    public int? PowerNumber { get; set; }

    public int? ChildYesNo { get; set; }

    public int? ParentId { get; set; }

    public int ParentGroupType { get; set; }

    public int? DDLParentId { get; set; }

    public int? Active { get; set; }
}
