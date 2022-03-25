namespace TaxService.Domain;

public record OrderResponse
{  
    public Tax tax { get; set; }

    public record Tax
    {
        public decimal order_total_amount { get; set; }
        public decimal shipping { get; set; }
        public int taxable_amount { get; set; }
        public decimal amount_to_collect { get; set; }
        public decimal rate { get; set; }
        public bool has_nexus { get; set; }
        public bool freight_taxable { get; set; }
        public Jurisdiction jurisdictions { get; set; }

        public record Jurisdiction
        {
            public string country { get; set; }
            public string state { get; set; }
            public string county { get; set; }
            public string city { get; set; }


        }
    }

    public record Breakdown
    {
        public int taxable_amount { get; set; }
        public decimal tax_collectable { get; set; }
        public decimal combined_tax_rate { get; set; }
        public int state_taxable_amount { get; set; }
        public decimal state_tax_rate { get; set; }
        public decimal state_tax_collectable { get; set; }
        public int county_taxable_amount { get; set; }
        public decimal county_tax_rate { get; set; }
        public decimal county_tax_collectable { get; set; }

        public int city_taxable_amount { get; set; }
        public int city_tax_rate { get; set; }
        public int city_tax_collectable { get; set; }
        public int special_district_taxable_amount { get; set; }
        public decimal special_tax_rate { get; set; }
        public decimal special_district_tax_collectable { get; set; }

        public List<LineItem> line_items { get; set; }
        public record LineItem
        {
            public string id { get; set; }
            public int taxable_amount { get; set; }
            public decimal tax_collectable { get; set; }
            public decimal combined_tax_rate { get; set; }
            public int state_taxable_amount { get; set; }
            public decimal state_sales_tax_rate { get; set; }
            public decimal state_amount { get; set; }
            public int county_taxable_amount { get; set; }
            public decimal county_tax_rate { get; set; }
            public int city_taxable_amount { get; set; }
            public int city_tax_rate { get; set; }
            public int city_amount { get; set; }
            public int special_district_taxable_amount { get; set; }
            public decimal special_tax_rate { get; set; }
            public decimal special_district_amount { get; set; }

            

        }

    }
}



