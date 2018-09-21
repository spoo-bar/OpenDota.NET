using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    public class Chat
    {
        private int _playerSlotNumber { get; set; }
        /// <summary>
        /// Time in seconds at which message was sent
        /// </summary>
        public TimeSpan Time { get; private set; }
        /// <summary>
        /// Name of player who sent the message
        /// </summary>
        public string Player { get; private set; }
        /// <summary>
        /// Message sent by the player
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Slot
        /// </summary>
        public int Slot { get; private set; }
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

        public static Chat Deserialize(JToken json)
        {
            return new Chat
            {
                Message = (string)json["key"],
                Time = TimeSpan.FromSeconds((int)json["time"]),
                Player = (string)json["unit"],
            };
        }
    }
}
