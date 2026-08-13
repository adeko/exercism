public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        database.BeginTransaction();
        try
        {
            database.Write(data);
            database.EndTransaction();
        }
        catch
        {
            database.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        database.BeginTransaction();
        try
        {
            database.Write(data);
            database.EndTransaction();
        }
        catch
        {
            database.Dispose();
            return false;
        }
        return true;
    }
}
