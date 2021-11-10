
using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class CreateAccountCommand : BaseCommand
    {
        private RegisterFormViewModel registerFormViewModel;
        private readonly LogInViewModel logInViewModel;

        public CreateAccountCommand(RegisterFormViewModel registerFormViewModel, LogInViewModel logInViewModel)
        {
            this.registerFormViewModel = registerFormViewModel;
            this.logInViewModel = logInViewModel;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new InstanceContext(logInViewModel));

            string hashedPassword = GenerateHashedPassword((PasswordBox)parameter);

            try
            {
                contractClient.CreateAccount(registerFormViewModel.UserName, registerFormViewModel.Email, hashedPassword);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }

        private string GenerateHashedPassword(PasswordBox parameter)
        {
            byte[] salt = new byte[128 / 8];
            using (RNGCryptoServiceProvider randomCrypto =
                new RNGCryptoServiceProvider())
            {
                randomCrypto.GetNonZeroBytes(salt);
            }

            string hashedPassword =
                Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: parameter.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

            return hashedPassword;
        }
    }
}
