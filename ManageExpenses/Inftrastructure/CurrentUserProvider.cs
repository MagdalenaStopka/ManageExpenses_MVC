using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Inftrastructure
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public long GetCurrentUserId()
        {
            return 1;
        }
    }
}