using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;
using System;

public partial class SetAnalyzer{
    //FullHouse level1, level2 strongest ThreeOfKind value, level3 StrongestPair value
    public void calculateFullHouse(){
        throw new NotImplementedException();
        ClearLevels();
        calculateThreeOfKind();
        if(CheckIfFits()){
            byte strongestThreeLevel = cardSetLevels[1];
            calculateOnePair();
            if(CheckIfFits()){
                byte strongestPairLevel= cardSetLevels[1];
                ClearLevels();
                cardSetLevels[0]=(byte)KindOfSet.FullHouse;
                cardSetLevels[1]=strongestThreeLevel;
                cardSetLevels[2]=strongestPairLevel;
            }
        }
    }
}