public class ViewModel
{
    public BusinessPackDataSet<Customer> Customers { get; set; }

    public List<int> SelectedCustomerIds { get; set; } = new List<int>();

    public override Task Init()
    {
        Customers = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { PageSize = 10 }
        };

        return base.Init();
    }

    public override Task Load()
    {
        if (Customers.IsRefreshRequired)
        {
            Customers.LoadFromQueryable(GetQueryable(15));
        }

        return base.Load();
    }

    private IQueryable<Customer> GetQueryable(int size)
    {
        var numbers = new List<Customer>();
        for (var i = 0; i < size; i++)
        {
            numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
        }
        return numbers.AsQueryable();
    }
}