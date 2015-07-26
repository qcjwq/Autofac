using AutofacDemo.Interfaces;

namespace AutofacDemo.Modules.UserInfo
{
    public class UserManager
    {
        private readonly IIdentity _identity;

        public UserManager(IIdentity identity)
        {
            _identity = identity;
        }

        public bool IsAuthority()
        {
            return _identity.IsAuthority();
        }
    }
}