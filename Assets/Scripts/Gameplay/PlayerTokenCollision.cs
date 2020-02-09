using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using TMPro;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
            player.IncreaseTokenCount();
            
            GameObject stat = GameObject.FindWithTag("UiStatHeader");
            if (stat != null) {
                TextMeshProUGUI t = stat.GetComponent<TextMeshProUGUI>();
                if (t != null) {
                    t.text = player.GetTokenCount().ToString();
                }
            }
            
        }
    }
}