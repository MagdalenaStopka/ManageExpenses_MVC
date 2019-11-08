using ManageExpenses.Entities;
using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageExpenses.Repositories
{
	public class UserInDbRepository : IUserRepository
	{
		public void Add(AddUserModel model)
		{
		}

		public EditUserModel GetUserById(long id)
		{
			return new EditUserModel();
		}

		public void Update(EditUserModel model)
		{
		}

		public void Delete(long id)
		{
		}

		public IEnumerable<UserListItemModel> GetAllUsers()
		{
			return Enumerable.Empty<UserListItemModel>();
		}

        public User Get(long userId)
        {
            return null;
        }
    }
}