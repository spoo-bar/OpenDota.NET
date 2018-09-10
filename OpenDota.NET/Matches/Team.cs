namespace OpenDota.NET.Matches
{
    public class Team
    {
        public int Score { get; set; }

        public dynamic GoldAdvantage { get; set; }

        public dynamic ExperienceAdvantage { get; set; }

        public int FinalScore { get; set; }

        public bool WonGame { get; set; }

        public int BarrackStatus { get; set; }

        /// <summary>
        /// Bitmask. An integer that represents a binary of which Radiant towers are still standing.
        /// </summary>
        public int TowerStatus { get; set; }
    }
}
