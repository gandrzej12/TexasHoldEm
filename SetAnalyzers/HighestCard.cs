
using System.Collections.Generic;
using TexasHoldEm;

public class HighestCard : SetAnalyzer
{
    public HighestCard(List<Card> someCards) : base(someCards)
    {
    }

    public override void calculateCardSetLevel()
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckIfFits()
    {
        throw new System.NotImplementedException();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}