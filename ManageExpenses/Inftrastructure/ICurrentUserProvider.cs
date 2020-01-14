using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExpenses.Inftrastructure
{
    public interface ICurrentUserProvider
    {
        long GetCurrentUserId();
    }
}
