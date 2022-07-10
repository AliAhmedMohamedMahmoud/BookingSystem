using System.ComponentModel.DataAnnotations.Schema;


namespace BookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }

        [ForeignKey("RoomType")]
        public int TypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual HotelBranch Branch { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        
    }
}
