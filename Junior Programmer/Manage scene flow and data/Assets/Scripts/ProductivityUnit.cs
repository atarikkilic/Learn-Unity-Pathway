using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit // replace MonoBehaviour with Unit
{
    // new variables
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        // start of new code
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
        // end of new code
    }

}
