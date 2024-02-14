namespace API.Interface
{
    public interface IPasswordHasher
    {
        bool verify(string passwordHash, string password);

        string Hash(string password);

    }
}
