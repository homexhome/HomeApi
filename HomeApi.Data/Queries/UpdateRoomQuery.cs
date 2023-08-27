namespace HomeApi.Data.Queries
{
    public class UpdateRoomQuery
    {
        public string NewName { get; set; }
        public int NewAria { get; set; }
        public bool NewGasConntcted { get; set; }
        public int NewVoltage { get; set; }

        public UpdateRoomQuery(string newName, int newAria, int newVoltage, bool newGasConnected)
        {
            NewName = newName;
            NewAria = newAria;
            NewVoltage = newVoltage;
            NewGasConntcted= newGasConnected;
        }
    }
}
