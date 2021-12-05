using System.Collections.Generic;
using UnityEngine;

namespace GameJam2
{
    public class PlayerState
    {
        private const string GameState = "GameState";

        public static void SaveState(Vector2 pos)
        {
            PlayerPrefs.SetString(GameState, pos.x + "," + pos.y);
        }
        
        public static Vector2 GetState()
        {
            if (PlayerPrefs.HasKey(GameState))
            {
                var str = PlayerPrefs.GetString(GameState);
                var strSplit = str.Split(",");
                return new Vector2(float.Parse(strSplit[0]), float.Parse(strSplit[1]));
            }

            return Vector2.zero;
        }

    
    }
}