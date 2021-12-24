using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;
using System;

public partial class SetAnalyzer{
    public void calculateStreighFlush(){
        ClearLevels();
        calculateStreigh();
        if(CheckIfFits()){
            byte streighLevel= cardSetLevels[1];
            calculateFlush();
            if(CheckIfFits()){
                cardSetLevels[0] = (byte)KindOfSet.StreighFlush;
                cardSetLevels[1] = streighLevel;
            }
        }
    }
}