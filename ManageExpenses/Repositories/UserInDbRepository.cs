using ManageExpenses.Entities;
using ManageExpenses.Inftrastructure;
using ManageExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageExpenses.Repositories
{
    public class UserInDbRepository : IUserRepository
    {


        public void Add(AddUserModel model)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login,
                    Password = model.Password,
                    DateOfBirth = model.DateOfBirth
                };

                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }


    

        public EditUserModel GetUserById(long id)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                return ctx.Users.Where(u => u.Id == id)
                    .Select(u => new EditUserModel
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Password = u.Password
                    }).Single();
            }
                

            //IList<User> result = new List<User>();
            //foreach(var user in _users)
            //{
            //	if (user.Id == id)
            //		result.Add(user);
            //}
        }

        public void Update(EditUserModel model)
        {

            using (var ctx = new ManageExpensesContext2())
            {
                var user = ctx.Users.Where(u => u.Id == model.Id).Single();

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Password = model.Password;

                ctx.SaveChanges();
            }
               
        }

        public void Delete(long id)
        {
            using (var ctx = new ManageExpensesContext2())
            {
                var userToDelete = ctx.Users.Where(u => u.Id == id).Single();
                ctx.Users.Remove(userToDelete);

                ctx.SaveChanges();
                
            }
               
        }

        public IEnumerable<UserListItemModel> GetAllUsers()
        {
            using (var ctx = new ManageExpensesContext2())
            {
                return ctx.Users.Select(u => new UserListItemModel
                {
                    Id = u.Id,
                    Login = u.Login,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ToList();

            }
               
        }

        

        //public User Get(long userId)
        //{
        //    using (var ctx = new ManageExpensesContext2())
        //    {
        //        return ctx.Users.SingleOrDefault(u => u.Id == userId);

        //    }
               
        //}
    }
}