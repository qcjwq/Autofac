using AutofacDemo.Interfaces;

namespace AutofacDemo.Modules.UserInfo
{
    public class User:IIdentity
    {
        public int Id { get; set; }

        public bool IsAuthority()
        {
            return Id == 1;
        }
    }
}