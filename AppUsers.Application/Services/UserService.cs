using AppUsers.Dominio;
using AppUsers.Dominio.Exceptions;
using PruebaTecnica.net7.Data.Repositories;
using AppUsers.Dominio.Interfaces;

namespace AppUsers.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailServices _mail;

        public UserService(IUserRepository userRepo, IMailServices mail)
        {
            _userRepository = userRepo;
            _mail = mail;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var listUsers = await _userRepository.GetUsersAsync();

            return listUsers.Select(user =>
            new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email
            }).ToList();

        }

        public async Task ValidateUser(UserModel user)
        {
            var userExist = await _userRepository.GetUserFilter(user.UserName, user.Email);
            if (userExist != null)
            {
                var validationError = new List<Validation>
                {
                    new ()
                    {
                        Message = "El UserName o Email ya existe",
                        Name = "Datos invalidos"
                    }
                };
                throw new CoreValidationException("Datos Invalidos", validationError);
            }
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await ValidateUser(user);
            User model = new User();
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Name = user.Name;
            model.CreateAt = DateTime.Now;
            model.Active = true;

            var createdUser = await _userRepository.CreateUserAsync(model);

            /**Send Email**/
            //if(createdUser != null)
            //{
            //    _mail.SendEmailGmail(createdUser.Email, "Creacion de usuario", "Usuario creado exitosamente");
            //}

            return new UserModel
            {
                Email = createdUser.Email,
                UserName = createdUser.UserName,
                Id = createdUser.Id,
                Name = createdUser.Name
            };



        }
    }
}
