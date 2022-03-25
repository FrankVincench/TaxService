namespace TaxService.Domain.ViewModels;

public record OrderViewModel
{
    public string? from_country { get; set; }
    public string? from_zip { get; set; }
    public string? from_state { get; set; }
    public string? from_city { get; set; }
    public string? from_street { get; set; }
    public string? to_country { get; set; }
    public string? to_zip { get; set; }
    public string? to_state { get; set; }
    public string? to_city { get; set; }
    public int to_street { get; set; }
    public decimal amount { get; set; }
    public decimal shipping { get; set; }

    public List<Nexus_address> nexus_addresses { get; set; }
    public List<Line_item> line_items { get; set; }

    public record Nexus_address
    {
        public string? id { get; set; }
        public string? country { get; set; }
        public string? zip { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? street { get; set; }
    }

    public class Line_item
    {
        public string? id { get; set; }
        public int quantity { get; set; }
        public string? product_tax_code { get; set; }
        public int unit_price { get; set; }
        public string? discount { get; set; }
        public string? sales_tax { get; set; }
    }

}
