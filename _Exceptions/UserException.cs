using System;

namespace _NSUserException {
    class UserException : Exception {
        public UserException() : base() { }
        public UserException(string Message) : base(Message) { }
    }
}
