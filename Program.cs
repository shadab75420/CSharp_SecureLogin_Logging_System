using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}

class Program
{
    static List<User> users = new List<User>();
    static string logFile = "log.txt";

    // Hash password using SHA256
    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }

    // Logging method (writes logs to file with timestamp)
    static void Log(string message)
    {
        try
        {
            File.AppendAllText(logFile, $"{DateTime.Now} : {message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Logging Error: " + ex.Message);
        }
    }

    // Register user
    static void Register()
    {
        try
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Role (Admin/User): ");
            string role = Console.ReadLine();

            string hash = HashPassword(password);

            users.Add(new User
            {
                Username = username,
                PasswordHash = hash,
                Role = role
            });

            Console.WriteLine("Registration Successful!");
            Log($"User Registered: {username}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during registration: " + ex.Message);
            Log("Registration Error: " + ex.Message);
        }
    }

    // Login method
    static User Login()
    {
        try
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string hash = HashPassword(password);

            foreach (var user in users)
            {
                if (user.Username == username && user.PasswordHash == hash)
                {
                    Console.WriteLine("Login Successful!");
                    Log($"Login Success: {username}");
                    return user;
                }
            }

            Console.WriteLine("Invalid Credentials!");
            Log($"Login Failed: {username}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Login Error: " + ex.Message);
            Log("Login Error: " + ex.Message);
            return null;
        }
    }

    // Role-based access
    static void AccessSystem(User user)
    {
        if (user.Role.ToLower() == "admin")
        {
            Console.WriteLine("Welcome Admin! You have full access.");
            Log($"Admin Access: {user.Username}");
        }
        else
        {
            Console.WriteLine("Welcome User! Limited access granted.");
            Log($"User Access: {user.Username}");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;

                case "2":
                    User user = Login();
                    if (user != null)
                        AccessSystem(user);
                    break;

                case "3":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}