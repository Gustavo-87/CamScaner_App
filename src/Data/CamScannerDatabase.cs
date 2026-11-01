
using SQLite;
using CamScanner.Models;

namespace CamScanner.Data;

public class CamScannerDatabase
{
    private SQLiteAsyncConnection? _database;

    private async Task InitAsync()
    {
        if (_database != null)
            return;

        string dbPath = Path.Combine(
            FileSystem.AppDataDirectory,
            "camscanner.db3"
        );

        var database = new SQLiteAsyncConnection(dbPath);

        await database.CreateTableAsync<Lote>();
        await database.CreateTableAsync<Documento>();

        _database = database;
    }

    public async Task<List<Lote>> ObtenerLotesAsync()
    {
        await InitAsync();
        return await _database!.Table<Lote>().ToListAsync();
    }

    public async Task<int> GuardarLoteAsync(Lote lote)
    {
        await InitAsync();

        return lote.Id == 0
            ? await _database!.InsertAsync(lote)
            : await _database!.UpdateAsync(lote);
    }
}
