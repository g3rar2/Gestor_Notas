using SQLite;

namespace GestorNotas1Q2025.Models;

public class NotaModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [NotNull]
    public string Titulo { get; set; }
    
    [NotNull]
    public string Descripcion { get; set; }
}