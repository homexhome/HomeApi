namespace HomeApi.Contracts.Models.Rooms.Request
{
    /// <summary>
    /// Запрос для обновления свойств конматы
    /// </summary>
    public class EditRoomRequest
    {
        public string NewRoomName { get; set; }
        public int NewRoonAria { get; set; }
        public int NewRoomVoltage { get; set; }
        public bool NewRoomGasConnected { get; set; }
    }
}
