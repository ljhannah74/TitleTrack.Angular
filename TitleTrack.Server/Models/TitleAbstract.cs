using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitleTrack.Server.Models
{
    public class TitleAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TitleAbstractID { get; set; }
        public string OrderNo { get; set; }
        public DateTime SearchDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Client Client { get; set; }
        public string ClientRefNo { get; set; }
        public Property Property { get; set; }
        public ProductType ProductType { get; set; }
    }
}
