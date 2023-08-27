using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Репозиторий для операций с объектами типа "Room" в базе
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeApiContext _context;
        
        public RoomRepository (HomeApiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        ///  Найти комнату по имени
        /// </summary>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Найти комнату по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        
        /// <summary>
        ///  Добавить новую комнату
        /// </summary>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);
            
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Метод для обновления существующей комнаты
        /// </summary>
        public async Task UpdateRoom(Guid id,Room room, UpdateRoomQuery query)
        {
            // Проверка переданных параметров
            if(id == room.Id) 
            { 
            if(!string.IsNullOrEmpty(room.Name))
                room.Name = query.NewName;           
                room.Area = query.NewAria;
                room.GasConnected = query.NewGasConntcted;
                room.Voltage = query.NewVoltage;
            }
            
            // Добавляем изменения в базу
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(room);

            // Сохраняем изменения
            await _context.SaveChangesAsync();
        }
    }
}