namespace OpenDota.NET.Matches
{
    public class PickBan
    {
        public bool IsPick { get; set; }
        public bool IsBan { get { return !IsPick; } }
        public int HeroId { get; set; }
        public int Team { get; set; }
        public int Order { get; set; }
        public int MatchId { get; set; }
    }
}