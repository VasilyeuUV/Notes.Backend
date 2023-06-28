namespace Notes.Persistence
{
    /// <summary>
    /// Инициализатор базы данных
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Инициализация БД
        /// </summary>
        /// <param name=""></param>
        public static void Initialize(NotesDbContext context) 
        {
            context.Database.EnsureCreated();   // - проверка на существование и создание БД
        }
    }
}
