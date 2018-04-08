﻿using TabletopCardCompanion.PlayingPieces;
using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of the same component type.
    /// <para>
    /// For example, hex tiles in Settlers of Catan.
    /// </para>
    /// </summary>
    public class GroupableWithComponent : GroupableBase
    {
        /// <summary>
        /// Combine the above object with this one if both are of the same component type.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            var typeOfThis =          GetComponent<PlayingPiece>().GetComponentType();
            var typeOfThat = objAbove.GetComponent<PlayingPiece>().GetComponentType();

            if (!string.IsNullOrWhiteSpace(typeOfThis) && !string.IsNullOrWhiteSpace(typeOfThat) &&
                string.Equals(typeOfThis, typeOfThat))
            {
                // Combine together to create a stack or deck.
            }
        }
    }
}
