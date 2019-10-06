using System.ComponentModel.DataAnnotations;
namespace DogScover.Models
{
    public class Funder
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int FunderId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public User UsersFund { get; set; }
        public Item ItemsFunded { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public Funder() { }
        public Funder(int SessionId, int id)
        {
            UserId = SessionId;
            ItemId = id;
        }
    }
}