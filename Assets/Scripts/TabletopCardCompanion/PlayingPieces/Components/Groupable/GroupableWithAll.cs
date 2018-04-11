using System;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object can group with any other object.
    /// <para>
    /// For example, a bag which may hold any other object within.
    /// </para>
    /// </summary>
    public class GroupableWithAll : GroupableBase
    {
        protected override void NotifyReceipientOfPlacement(PlayingPiece objAbove)
        {
            Debug.Log("This is GroupableWithAll");

            throw new NotImplementedException();
        }
    }
}
