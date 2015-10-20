using System.Data.Entity;

namespace Library.Infra.Data.Ef.Context
{
    internal class LibrarySeedInitializer : DropCreateDatabaseAlways<LibraryContext>
    {
        public override void InitializeDatabase(LibraryContext context)
        {
            base.InitializeDatabase(context);
        }
        protected override void Seed(LibraryContext context)
        {
            base.Seed(context);
        }
    }
}