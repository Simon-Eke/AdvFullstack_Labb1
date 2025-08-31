using AdvFullstack_Labb1.Models.DTOs.Table;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;

namespace AdvFullstack_Labb1.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepo;
        public TableService(ITableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }
        public async Task<List<TableDto>> GetAllTablesAsync()
        {
            var tables = await _tableRepo.GetAllAsync();

            var tableDtoList = tables.Select(t => new TableDto
            {
                Id = t.Id,
                Seatings = t.Seatings,
                TableNumber = t.TableNumber
            }).ToList();

            return tableDtoList;
        }

        public async Task<List<TableDto>> GetAvailableTablesAsync(int wantedSeats, DateTime desiredStartTime)
        {
            var tables = await _tableRepo.GetAvailableTablesAsync(wantedSeats, desiredStartTime);

            var availableTableDtos = tables.Select(t => new TableDto
            {
                Id = t.Id,
                Seatings = t.Seatings,
                TableNumber = t.TableNumber
            }).ToList();

            return availableTableDtos;
        }
        public async Task<TableDto> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepo.GetByIdAsync(tableId);

            if (table == null)
                return null;

            var tableDto = new TableDto
            {
                Id = table.Id,
                Seatings = table.Seatings,
                TableNumber = table.TableNumber
            };

            return tableDto;
        }
        public async Task<int> CreateTableAsync(TableCreateDto newTable)
        {
            var table = new Table
            {
                Seatings = newTable.Seatings,
                TableNumber = newTable.TableNumber
            };

            var newTableId = await _tableRepo.CreateAsync(table);

            return newTableId;
        }
        public async Task<bool> UpdateTableAsync(TableDto table)
        {
            var existingTable = await _tableRepo.GetByIdAsync(table.Id);
            if (existingTable == null)
                return false;

            existingTable.Seatings = table.Seatings;
            existingTable.TableNumber = table.TableNumber;

            await _tableRepo.UpdateAsync(existingTable);

            return true;
        }
        public async Task<bool> PatchTableAsync(int id, TablePatchDto patchTable)
        {
            var existingTable = await _tableRepo.GetByIdAsync(id);
            if (existingTable == null)
                return false;

            if (patchTable.Seatings.HasValue)
                existingTable.Seatings = patchTable.Seatings.Value;

            if (patchTable.TableNumber.HasValue)
                existingTable.TableNumber = patchTable.TableNumber.Value;

            var success = await _tableRepo.UpdateAsync(existingTable);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteTableAsync(int tableId)
        {
            var existingTable = await _tableRepo.GetByIdAsync(tableId);
            if (existingTable == null)
                return false;

            var success = await _tableRepo.DeleteAsync(tableId);
            if (success != true)
                return false;

            return true;
        }
    }
}
