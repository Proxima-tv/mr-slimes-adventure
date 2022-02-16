using System;
using UnityEngine;
using Discord;

public class DiscordRichPresence : MonoBehaviour
{
	public string name = "Mr.Slime's Attack";
	public string level;
	public Discord.Discord discord;

    // Use this for initialization
    void Start()
	{
		if (Convert.ToBoolean(PlayerPrefs.GetInt("discordrichpresence")))
		{
			discord = new Discord.Discord(854319550467670016, (System.UInt64)Discord.CreateFlags.Default);
			var activityManager = discord.GetActivityManager();
			var activity = new Discord.Activity
			{
				State = name + " - ALPHA Testing",
				Details = level
			};
			activityManager.UpdateActivity(activity, (res) =>
			{
				if (res == Discord.Result.Ok)
				{
					Debug.LogError("Everything is fine!");
				}
			});
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Convert.ToBoolean(PlayerPrefs.GetInt("discordrichpresence")))
		{

			discord.RunCallbacks();

		}
	}

	void OnApplicationQuit()
	{
		if (Convert.ToBoolean(PlayerPrefs.GetInt("discordrichpresence")))
		{

			discord.ActivityManagerInstance.ClearActivity((Result) =>
			{
				if (Result == Discord.Result.Ok)
				{
					Debug.Log("Success!");
				}
				else
				{
					Debug.LogError("Failed");
				}
			});
		}
	}
}