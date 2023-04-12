using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whammy.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public OrderHeader OrderHeader { get; set; }

        public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public virtual MenuItem MenuItem { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }


    }

}

