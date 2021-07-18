using ServerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp
{
    public interface IAuthManager
    {
        string Authenticate(string username, string password, Patient patient);
    }
}
