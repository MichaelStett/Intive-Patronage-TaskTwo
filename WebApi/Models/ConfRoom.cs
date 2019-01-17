using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    //Conference Room Class
    public class ConfRoomItem 
    {
        public long Id  { get; set; }
        public long RoomNr { get; set; }
        public bool IsRented { get; set; }
        public string RenterName { get; set; }
        
    }

    // Database 
    public class ConfRoomContext : DbContext 
    {
        public DbSet<ConfRoomItem> ConfRoomItems { get; set; }

        public ConfRoomContext(DbContextOptions<ConfRoomContext> options)
            : base(options) { }
    }    
}
