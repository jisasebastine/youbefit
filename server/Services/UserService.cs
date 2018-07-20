using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using youbefit.Models;

namespace youbefit.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public User SignUp(string username, string password, string email="")
        {
            var user = _appDbContext.User.Where(u => u.Username == username).SingleOrDefault();
            if(user != null)
            {
                return null;
            }
            user = new User
            {
                Username = username,
                Password = password,
                Email = email
            };
            _appDbContext.User.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public User Login(string username, string password)
        {
            return _appDbContext.User.Where(u => u.Username == username && u.Password == password).SingleOrDefault();
        }

        public User GetUserById(string userid)
        {
            var id = Convert.ToInt32(userid);
            return _appDbContext.User.Where(u => u.Userid == id).SingleOrDefault();
        }
    }
}
