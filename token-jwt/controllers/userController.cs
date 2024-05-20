namespace Loja.controllers;

public class UserController
{
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }

    public UserController(string userLogin, string userPassword)
    {
        UserLogin = userLogin;
        UserPassword = userPassword;
    }

    public bool Login(string UserLogin, String UserPassaword)
    {
        if (UserLogin == "admin" && UserPassword == "abc")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}