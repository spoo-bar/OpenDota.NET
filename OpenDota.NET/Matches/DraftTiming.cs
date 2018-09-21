using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    public class DraftTiming
    {
        internal int _playerSlotNumber { private get; set; }
        public int Order { get; private set; }
        public bool Picked { get; private set; }
        public bool Banned { get { return !Picked; } }
        public int ActiveTeam { get; private set; }
        public int HeroID { get; private set; }
        public Slot PlayerSlot
        {
            get
            {
                if (_playerSlotNumber >= 128)
                {
                    return Slot.Dire;
                }
                return Slot.Radiant;
            }
        }
        public int ExtraTime { get; private set; }
        public int TotalTimeTaken { get; private set; }

        public static DraftTiming Deserialize(JToken json)
        {
            return new DraftTiming(); // TODO : Deserialize
        }

    }
}
