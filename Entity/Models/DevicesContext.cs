using System.Data.Entity;
using Entity.Models.Entity;

namespace Entity.Models
{
    public class DevicesContext : DbContext
    {     
        static DevicesContext()
               {
                   Database.SetInitializer<DevicesContext>(new DevicesContextInitializer());
               }



        public DbSet<Device> Device { get; set; }
        public DbSet<Conditioner> Conditioner { get; set; }
        public DbSet<DVD> DVD { get; set; }
        public DbSet<Fridge> Fridge { get; set; }
        public DbSet<Kettle> Kettle { get; set; }
        public DbSet<Lamp> Lamp { get; set; }
        public DbSet<TapRecoder> TapeReoder { get; set; }
        public DbSet<TeleVision> TeleVision { get; set; }
       
    }
}