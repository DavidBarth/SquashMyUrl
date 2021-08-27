namespace SquashMyUrl.DAL
{
    class DbInitialiser
    {
        public static bool Initialize(SquashMyUrlContext context)
        {
            return context.Database.EnsureCreated();
        }
    }
}
