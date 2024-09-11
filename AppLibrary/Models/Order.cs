using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models;
public class Order : BaseEntity
{
    public DateOnly Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public IEnumerable<Product> Products { get; } = [];
}