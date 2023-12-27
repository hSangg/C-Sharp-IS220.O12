namespace CshartpLab5.Models
{
    public class OrderViewModel
    {
        public string MAKH { get; set; }
        public decimal THT { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public DateTime NGAYHD { get; set; }
    }
}
