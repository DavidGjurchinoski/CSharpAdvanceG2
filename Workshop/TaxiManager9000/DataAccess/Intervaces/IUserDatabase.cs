﻿using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess.Intervaces
{
    public interface IUserDatabase
    {

        void Insert(User user);

        User GetByUserNameAndPassword(string userName, string password);

        bool Delete(User user);
        
        List<User> GetAll();

        User GetUserById(int id);

    }
}
