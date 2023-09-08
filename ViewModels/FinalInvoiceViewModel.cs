namespace ITIProject.ViewModels
{
    public class FinalInvoiceViewModel
    {
        public int CartId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public List<ItemViewModel> Items { get; set; }
        public FinalInvoiceViewModel()
        {
            Items = new List<ItemViewModel>();
        }
    }
}
