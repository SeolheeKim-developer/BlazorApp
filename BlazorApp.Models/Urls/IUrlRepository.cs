namespace BlazorApp.Models
{
    public interface IUrlRepository
    {
        bool IsExists(string email);
    }
}