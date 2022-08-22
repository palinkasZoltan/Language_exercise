namespace Repository
{
    using Language_exercise.DL;

    public class BaseRepository
    {
        protected DataConnection dc;

        public BaseRepository(DataConnection dataConnection)
        {
            dc = dataConnection;
        }
    }
}