namespace userClass
{
  
public class User

    {

        // Define three properties for storing user information: Username, Password, and Email
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }



        // Define a constructor for initializing user objects with username, password, and email
        public User(string user, string pas, string email)

        {


            // Check if the email is not null and ends with "@hotmaill.com"
            if (email is not null && email.EndsWith("@hotmaill.com"))

            {

                if (user is not null && user.Length >= 5 && user.Length <= 20)

                {

                }

                else

                {
                    // If the password doesn't meet the criteria, throw an ArgumentException
                    throw new ArgumentException("'Username must be between 5 and 20'");

                }

                if (pas is not null && pas.Length >= 8 && CheckIsCharacterSpecial(pas))

                {

                    Username = user;

                    Password = pas;

                    Email = email;

                }

                else

                {
                    // If the username doesn't meet the criteria, throw an ArgumentException
                    throw new ArgumentException("'Password lenght must be over 8 characters, and needs a special sign'");

                }

            }

            else

            {
                // If the email doesn't meet the criteria, throw an ArgumentException
                throw new ArgumentException("email must end with '@hotmail.com");

            }



        }

        private bool CheckIsCharacterSpecial(string password)

        {

            foreach (char c in password)

            {

                if (!char.IsLetterOrDigit(c))

                {
                    // If the character is not a letter or digit, return true
                    return true;

                }

            }
            // If no special character is found, return false
            return false;

        }

    }
}
