using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project1.Models;
using Firebase.Database.Query;
using System.Linq;
using System.Diagnostics;

namespace Project1.Services
{
    public static class GoogleFirebase
    {
        public static FirebaseClient firebase =
         new FirebaseClient("https://projectfinal-1e184-default-rtdb.asia-southeast1.firebasedatabase.app/");

       
        public static async Task<bool> AddUser(Userdata users)
        {
            await firebase
              .Child("User")
              .PostAsync(users);
            return true;
        }
        public static async Task<bool> AddJob(Job users)
        {
            await firebase
              .Child("Job")
              .PostAsync(users);
            return true;
        }
        public static async Task<List<Job>> GetAllJob()
        {
            try
            {
                var Codelist = (await firebase
                .Child("Job")
                .OnceAsync<Job>()).Select(item =>
                new Job
                {
                    customer = item.Object.customer,
                    date = item.Object.date,
                    name = item.Object.name,
                    username = item.Object.username,
                    img = item.Object.img

                }).ToList();
                return Codelist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<List<Userdata>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("User")
                .OnceAsync<Userdata>()).Select(item =>
                new Userdata
                {
                    Username = item.Object.Username,
                    Password = item.Object.Password,
                    Name = item.Object.Name,
                    Surname = item.Object.Surname,

                }).ToList();
                
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<Userdata> GetUser(string username)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("User")
                .OnceAsync<Userdata>();
                var check = allUsers.Where(a => a.Username == username).FirstOrDefault();
                if (check != null)
                {
                    Global.NameGlobal = check.Name;
                    Global.SurnameGlobal = check.Surname;
                    Global.UsernameGlobal = check.Username;
                }
                return allUsers.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
    }
}
