using ManageExpenses.Entities;
using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExpenses.Repositories
{
	public interface IUserRepository
	{
		void Add(AddUserModel model);
		EditUserModel GetUserById(long id);
        //User Get(long userId);
		void Update(EditUserModel model);
		void Delete(long id);
		IEnumerable<UserListItemModel> GetAllUsers();
	}
}
