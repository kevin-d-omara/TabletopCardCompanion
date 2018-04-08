using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of the same class.
    /// <para>
    /// For example, playing cards.
    /// </para>
    /// </summary>
    public class GroupableWithClass : GroupableBase
    {
        /// <summary>
        /// Combine the above object with this one if both are the same class.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            var typeOfThis =          GetComponent<PlayingPiece>().GetType();
            var typeOfThat = objAbove.GetComponent<PlayingPiece>().GetType();

            if (typeOfThis.IsAssignableFrom(typeOfThat) || typeOfThat.IsAssignableFrom(typeOfThis))
            {
                Debug.Log("Both are GroupableWithClass");
            }
        }
    }
}
