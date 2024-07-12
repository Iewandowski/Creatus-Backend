using System;

namespace creatus_backend.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(string.Format("Usuário(s) não encontrado(s)")) { }
    }
}