﻿namespace OpenDota.NET.Matches
{
    public class Chat
    {
        internal int _playerSlotNumber { private get; set; }
        /// <summary>
        /// Time in seconds at which message was sent
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// Name of player who sent the message
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Message sent by the player
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Slot
        /// </summary>
        public int Slot { get; set; }
        /// <summary>
        /// Which slot the player is in
        /// </summary>
        public Slot PlayerSlot
        {
            get
            {
                if(_playerSlotNumber >= 128)
                {
                    return Matches.Slot.Dire;
                }
                return Matches.Slot.Radiant;
            }
        }
    }
}