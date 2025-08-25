using AdvFullstack_Labb1.Models.DTOs.Table;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
            var tables = await _tableRepo.GetAllTablesAsync();

            var tableDtoList = tables.Select(t => new TableDto
            {
                TableId = t.TableId,
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
                TableId = t.TableId,
                Seatings = t.Seatings,
                TableNumber = t.TableNumber
            }).ToList();

            return availableTableDtos;
        }
        public async Task<TableDto> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepo.GetTableByIdAsync(tableId);

            if (table == null)
                return null;

            var tableDto = new TableDto
            {
                TableId = table.TableId,
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

            var newTableId = await _tableRepo.CreateTableAsync(table);

            return newTableId;
        }
        public async Task<bool> UpdateTableAsync(TableDto table)
        {
            var existingTable = await _tableRepo.GetTableByIdAsync(table.TableId);
            if (existingTable == null)
                return false;

            existingTable.Seatings = table.Seatings;
            existingTable.TableNumber = table.TableNumber;

            await _tableRepo.UpdateTableAsync(existingTable);

            return true;
        }
        public async Task<bool> PatchTableAsync(int id, TablePatchDto patchTable)
        {
            var existingTable = await _tableRepo.GetTableByIdAsync(id);
            if (existingTable == null)
                return false;

            if (patchTable.Seatings.HasValue)
                existingTable.Seatings = patchTable.Seatings.Value;

            if (patchTable.TableNumber.HasValue)
                existingTable.TableNumber = patchTable.TableNumber.Value;

            var success = await _tableRepo.PatchTableAsync(existingTable);
            if (success != true)
                return false;

            return true;
        }
        public async Task<bool> DeleteTableAsync(int tableId)
        {
            var existingTable = await _tableRepo.GetTableByIdAsync(tableId);
            if (existingTable == null)
                return false;

            var success = await _tableRepo.DeleteTableAsync(tableId);
            if (success != true)
                return false;

            return true;
        }
    }
}
