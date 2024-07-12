using System.ComponentModel.DataAnnotations;

namespace creatus_backend.Dtos.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Level { get; set; }

        public UserResponse(int id, string name, string email, int level)
        {
            Id = id;
            Name = name;
            Email = email;
            Level = level;
        }

        public UserResponse() {}
    }
}
