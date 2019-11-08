using ManageExpenses.Entities;
using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageExpenses.Repositories
{
	public class UserInMemoryRepository : IUserRepository
	{
		private IList<User> _users = new List<User>()
		{
			new User()
			{
				Id = 1,
				FirstName = "Agnieszka",
				LastName = "Kowalska",
				Login = "a.kowalska",
				Password = "tajne",
				DateOfBirth = DateTime.Now.AddYears(-10)
			}
		};

		public void Add(AddUserModel model)
		{
			var user = new User()
			{
				Id = GetId(),
				FirstName = model.FirstName,
				LastName = model.LastName,
				Login = model.Login,
				Password = model.Password,
				DateOfBirth = model.DateOfBirth
			};

			_users.Add(user);
		}

		public EditUserModel GetUserById(long id)
		{
			return _users.Where(u => u.Id == id)
				.Select(u => new EditUserModel
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					Password = u.Password
				}).Single();

			//IList<User> result = new List<User>();
			//foreach(var user in _users)
			//{
			//	if (user.Id == id)
			//		result.Add(user);
			//}
		}

		public void Update(EditUserModel model)
		{
			var user = _users.Where(u => u.Id == model.Id).Single();

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.Password = model.Password;
		}

		public void Delete(long id)
		{
			var userToDelete = _users.Where(u => u.Id == id).Single();
			_users.Remove(userToDelete);
		}

		public IEnumerable<UserListItemModel> GetAllUsers()
		{
			return _users.Select(u => new UserListItemModel
			{
				Id = u.Id,
				Login = u.Login,
				FirstName = u.FirstName,
				LastName = u.LastName
			});
		}

		private long GetId()
		{
			if(_users.Count > 0)
			{
				return _users.Max(x => x.Id) + 1;

				//long max = 0;

				//foreach(var user in _users)
				//{
				//	if (user.Id > max)
				//		max = user.Id;
				//}
			}

			return 1;
		}

        public User Get(long userId)
        {
            return _users.SingleOrDefault(u => u.Id == userId);
        }
    }
}