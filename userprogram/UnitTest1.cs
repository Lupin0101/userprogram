using System;
using userClass;

namespace userprogram
{
    public class UnitTest1
    {
        [Fact] // Attribute to denote that this method is a test method; in this case, it's a fact test
        public void Check_If_User_Added_Is_Unique() // Define a test method to check if the added user is unique
        {
            // Arrange
            // Create two instances of the User class with identical data
            var user1 = new User("Basher", "12@34567b", "test@hotmaill.com");
            var user2 = new User("Basher", "12@34567b", "test@hotmaill.com");

            // Create an instance of UserCollector class
            var userBank = new UserCollector();

            // Act
            userBank.AddUser(user1);

            // Assert
            // Create an instance of UserCollector class
            Assert.Throws<ArgumentException>(() => userBank.AddUser(user2));
        }


        [Theory]
        [InlineData("JagÄrÖver20Karaktärer2222")]
        [InlineData("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string user)
        {
            // Arrange & Act

            // Fixa till att Datorows som skall ge ut olika värden samt olika fellmeddelanden beroende på datat som skickas in
            var exception1 = Assert.Throws<ArgumentException>(() => new User($"{user}", "pas!sword", "whatever@hotmaill.com"));
            //var exception2 = Assert.Throws<ArgumentException>(() => new User("User", "pas!sword", "whatever@email.com"));
            // Assert
            Assert.Equal("'Username must be between 5 and 20'", exception1.Message);
            // Assert.Equal("Username must be between 5 and 20 characters and email must end with '@email.com'", exception2.Message);



        }

        [Fact]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            var user1 = new User("Basher", "1234567@@a", "Gielinor@hotmaill.com");

            // Assert
            Assert.Equal("Gielinor@hotmaill.com", user1.Email);


            var exception = Assert.Throws<ArgumentException>(() => new User("Basher", "12345@67bb", "DåligEmail"));
            Assert.Equal("email must end with '@hotmail.com", exception.Message);
        }

        [Fact]
        public void Check_If_User_Message_When_Successfull_Works()
        {

            var userbank = new UserCollector();
            var user = new User("UserTest", "JagheterBa@sher1", "Basher.AlhajKhalil@hotmaill.com");

            string success = userbank.AddUser(user);

            Assert.Equal($"{user.Username} has been sucessfully created!", success);

        }

        [Fact]
        public void Check_If_Added_Users_PassWord_Contains_The_Right_Formatting()
        {
            // Arrange
            var userbank = new UserCollector();

            // Act and Arrange
            var exception = Assert.Throws<ArgumentException>(() => new User("Basher", "LösenordetharingeSpecialTecken", "Basher@hotmaill.com"));

            Assert.Equal("'Password lenght must be over 8 characters, and needs a special sign'", exception.Message);
        }
    }
    
}