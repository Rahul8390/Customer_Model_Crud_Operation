using System;
using System.Collections.Generic;

namespace Customer_Model_Crud_Operation.Models;

public partial class CustDetail
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailId { get; set; }

    public string? PhoneNo { get; set; }

    public string? City { get; set; }
}
