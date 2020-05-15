using System;
using System.Linq;
using System.Threading.Tasks;
using AN.Core.Domain;
using AN.Helpers.Constants;
using Microsoft.AspNetCore.Identity;

namespace AN.Data
{
    public class SeedData
    {
        private static UserManager<User> _manager;
        private static ANDbContext _context;
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            _manager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));

            _context = (ANDbContext)serviceProvider.GetService(typeof(ANDbContext));

            InitializeVMS();


        }

        private static void InitializeVMS()
        {
            if (!_context.Roles.Any())
            {
                try
                {
                    _context.Roles.Add(new Role(AppRoles.Administrator));
                    _context.Roles.Add(new Role(AppRoles.Member));

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }


            if (!_context.Users.Any())
            {

                try
                {
                    User newUser = new User();
                    newUser.Email = newUser.UserName = "admisnistrator@gmail.com";
                    newUser.Firstname = "Barbara";
                    newUser.Lastname = "Ezomo";
                    newUser.DateOfBirth = DateTime.Now;
                    newUser.PhoneNumber = "07038875015";

                    var result = _manager.CreateAsync(newUser, "Password@1").GetAwaiter().GetResult();

                    var token = _manager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();

                    var confirmEmail = _manager.ConfirmEmailAsync(newUser, token).GetAwaiter().GetResult();

                    if (confirmEmail.Succeeded)
                    {
                        if (result.Succeeded)
                        {
                            var newResult = _manager.AddToRoleAsync(newUser, AppRoles.Administrator).GetAwaiter().GetResult();
                            if (newResult.Succeeded)
                            {
                                Console.WriteLine("User created Successfully");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                try
                {
                    User newUser = new User();
                    newUser.Email = newUser.UserName = "user@gmail.com";
                    newUser.Firstname = "Barbara";
                    newUser.Lastname = "Ezomo";
                    newUser.DateOfBirth = DateTime.Now;
                    newUser.PhoneNumber = "07038875015";

                    var result = _manager.CreateAsync(newUser, "Password@1").GetAwaiter().GetResult();

                    var token = _manager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();

                    var confirmEmail = _manager.ConfirmEmailAsync(newUser, token).GetAwaiter().GetResult();

                    if (confirmEmail.Succeeded)
                    {
                        if (result.Succeeded)
                        {
                            var newResult = _manager.AddToRoleAsync(newUser, AppRoles.Member).GetAwaiter().GetResult();
                            if (newResult.Succeeded)
                            {
                                Console.WriteLine("User created Successfully");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}

