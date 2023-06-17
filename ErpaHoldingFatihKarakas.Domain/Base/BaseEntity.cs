namespace ErpaHoldingFatihKarakas.Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid CreaterUserId { get; set; }
        public Guid? DeleterUserId { get; set; }
        public Guid? UpdatetorUserId { get; set; }
    }
}
