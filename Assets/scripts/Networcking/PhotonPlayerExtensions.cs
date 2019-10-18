using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


#region PhotonPlayerExtensions ++++++++++++++++++++++++++
public enum PlayerProperty
{
    Login,
    Name,
    Score,
    Avatar,
    Speed,
}

//методы расширения для PhotonPlayer
public static class PhotonPlayerExtensions
{
    //установить значение
    public static void Set<T>(this PhotonPlayer player, PlayerProperty prop, T val)
    {
        var props = new Hashtable();
        props["p" + (int)prop] = val;
        player.SetCustomProperties(props);
    }
    //получить значение
    public static T Get<T>(this PhotonPlayer player, PlayerProperty prop)
    {
        object val;
        if (player.CustomProperties.TryGetValue("p" + (int)prop, out val))
        {
            //player.CustomProperties
            return (T)val;
        }

        return default(T);
    }
}
#endregion

public class RoomProperty
{
    public const string Word = "WD";
}

public enum RoomsProperty
{
    Word,
}


public static class PhotonRoomExtensions
{
    //установить значение
    public static void SetR<T>(this RoomOptions player, RoomsProperty prop, T val)
    {
        var props = new Hashtable();
        props["s" + (int)prop] = val;
        player.customRoomProperties.Add(RoomProperty.Word,val);
    }
    //получить значение
    public static T GetR<T>(this PhotonPlayer player, RoomsProperty prop)
    {
        object val;
        if (player.CustomProperties.TryGetValue("s" + (int)prop, out val))
        {
            //player.CustomProperties
            return (T)val;
        }

        return default(T);
    }
}
