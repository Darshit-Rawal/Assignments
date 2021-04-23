using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_8
{
    public class Service
    {
        public async Task<IEnumerable<string>> GetStringArray()
        {
            IEnumerable<string> someString = new[] { "abc", "def", "ghi", "jkl" };
            await Task.Delay(100);
            return someString;
        }

        public async Task<IEnumerable<User>> GetUserData()
        {
            User[] users = new User[] {
                new User{ Id = 1, Name = "Abhishek", Email = "abhishekBakhai@gmail.com", Address = "Rajkot"},
                new User{ Id = 2, Name = "Darshit", Email = "darshitrawal@gmail.com", Address = "Rajkot"},
                new User{ Id = 3, Name = "Parth", Email = "parthnonghanvadra@gmail.com", Address = "Ahmedabad"},
            };

            await Task.Delay(100);

            return users;
        }

        public int[] GetTable(int number)
        {
            int[] table = new int[10];
            for (int i = 0; i <= 9; i++)
            {
                table[i] = (i + 1) * number;
            }
            return table;
        }

        public string GetString()
        {
            return "Darshit Rawal";
        }

        public DateTime GetDate()
        {
            return new DateTime(2000, 03, 07);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
