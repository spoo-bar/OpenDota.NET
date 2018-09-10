namespace OpenDota.NET.Matches
{
    public class DraftTiming
    {
        internal int _playerSlotNumber { private get; set; }
        public int Order { get; set; }
        public bool Picked { get; set; }
        public bool Banned { get { return !Picked; } }
        public int ActiveTeam { get; set; }
        public int HeroID { get; set; }
        public Slot PlayerSlot
        {
            get
            {
                if (_playerSlotNumber >= 128)
                {
                    return Matches.Slot.Dire;
                }
                return Matches.Slot.Radiant;
            }
        }
        public int ExtraTime { get; set; }
        public int TotalTimeTaken { get; set; }

    }
}
