namespace DoMain.Entities;

public class Request
{
    public int RequestId { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public int RequestedSkillId { get; set; }
    public int OfferedSkillId { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}