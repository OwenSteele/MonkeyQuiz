using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Final_Test
{
    public class Monkey
    {
        public bool OrangeFur { get; set; }
        public bool LongArms { get; set; }
        public bool BigMonkey { get; set; }
        public bool BigNose { get; set; }
        public bool BasicBitch { get; set; }
        public bool TreeMonkey { get; set; }
        public bool MonkeyApePrimate { get; set; }

        public int GenitalSize { get; set; }

        public Monkey(bool orangeFur, bool longArms, bool bigMonkey, bool bigNose, bool basicBitch, bool treeMonkey, bool monkeyApePrimate = true, int genitalSize = 0)
        {
            OrangeFur = orangeFur;
            LongArms = longArms;
            BigMonkey = bigMonkey;
            BigNose = bigNose;
            TreeMonkey = treeMonkey;
            BasicBitch = basicBitch;
            MonkeyApePrimate = monkeyApePrimate;
            GenitalSize = genitalSize;
        }

    }
}
