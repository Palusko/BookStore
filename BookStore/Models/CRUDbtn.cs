using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookStore.Models
{
    public class CRUDbtn
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? GenreId { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        public int? MembershipTypeId { get; set; }

        public int ActionParameter
        {
            get
            {
                if (BookId != null && BookId > 0)
                    return (int)BookId;

                if (GenreId != null && GenreId > 0)
                    return (int)GenreId;

                if (CustomerId != null && CustomerId > 0)
                    return (int)CustomerId;
                
                if (MembershipTypeId != null && MembershipTypeId > 0)
                    return (int)MembershipTypeId;

                return 0;
            }
        }

    }
}