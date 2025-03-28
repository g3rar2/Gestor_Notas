using GestorNotas1Q2025.Models;
using SQLite;

namespace GestorNotas1Q2025.Services;

public class NotaService
{
    private readonly SQLiteConnection _connection;


    public NotaService()
    {
        string dbPath=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notas.db3");
        _connection = new SQLiteConnection(dbPath);
        _connection.CreateTable<NotaModel>();
    }

    public List<NotaModel> GetAll(string filtro = "")
    {

        if (string.IsNullOrEmpty(filtro))
        {
            return _connection.Table<NotaModel>().ToList();
        }
        
            return _connection.Table<NotaModel>().Where(nota => nota.Titulo.ToLower().Contains(filtro.ToLower())).ToList();

    }

    public int Insert(NotaModel Nota)
    {
        return _connection.Insert(Nota);
    }

    public int Update(NotaModel Nota)
    {
        return _connection.Update(Nota);
    }

    public int Delete(NotaModel Nota)
    {
        return _connection.Delete(Nota);
    }
    
    
}