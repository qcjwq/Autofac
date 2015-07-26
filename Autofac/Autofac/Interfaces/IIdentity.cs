namespace AutofacDemo.Interfaces
{
    public interface IIdentity
    {
        int Id { get; set ; }

        bool IsAuthority();
    }
}