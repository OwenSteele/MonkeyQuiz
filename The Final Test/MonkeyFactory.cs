using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace The_Final_Test
{
    public static class MonkeyFactory
    {
        private static List<Monkey> _monkeys = new List<Monkey>();
        
        private static string[] _monkeyTypes = new string[]
        {
            "Orangutan",
            "Gibbon",
            "Marmozet",
            "SquirrelMonkey",
            "Baboon",
            "Capuchin",
            "Mandrill",
            "SpiderMonkey",
            "No Monkey :("
        };
        public static string[] questions = new string[]
        {
                "Does the nickname for Napalm appeal to you",
                "Do you wish you could tackle your problems from further away",
                "Do you like learning new things",
                "Do you have any relatives hailing from Jesus town",
                "Would you order a pumpkin spiced latte at Starbucks",
                "Do you like heights",
                "Do you enjoy playing strip poker",
                "Have you ever been arrested for public indecency",
                "Does size matter to you",
                "Can you perform under pressure",
                "Can you do the helicopter action (guys only)",
                "Sandbags on roads (gals only)"
        };
        public static void CreateMonkeys()
        {
            _monkeys.Add(new Monkey(true, true, true, false, false, false, false));
            _monkeys.Add(new Monkey(false, false, false, false, false, false, false,3));
            _monkeys.Add(new Monkey(false, false, false, false, true, true, false,4));
            _monkeys.Add(new Monkey(false, false, false, false, false, true, genitalSize: 5));
            _monkeys.Add(new Monkey(false, false, true, true, true, false, false, 4));
            _monkeys.Add(new Monkey(false, true, false, true, false, true, genitalSize: 2));
            _monkeys.Add(new Monkey(false, true, true, true, false,false));
            _monkeys.Add(new Monkey(false, true, false,false, true, true,genitalSize: 5));
        }
        public static string MatchMonkey(Monkey user)
        { //objects won't match without each property defined.. to fix!
            int x = _monkeys.FindIndex(m => 
            (m.OrangeFur == user.OrangeFur) &&
            (m.LongArms == user.LongArms) &&
            (m.BigMonkey == user.BigMonkey) &&
            (m.BigNose == user.BigNose) &&
            (m.BasicBitch == user.BasicBitch) &&
            (m.TreeMonkey == user.TreeMonkey) &&
            (m.MonkeyApePrimate == user.MonkeyApePrimate) &&
            (m.GenitalSize == user.GenitalSize)
            );

            if (x==-1) return $"No perfect match, next best: {NextBestMatch(user)}";

            return _monkeyTypes[x];
        }
        private static string NextBestMatch(Monkey user)
        {
            int[] monkeyMatches = new int[_monkeyTypes.Length-1];

            for (int m = 0; m < monkeyMatches.Length; m++)
            {
                foreach (PropertyInfo mP in _monkeys[m].GetType().GetProperties())
                {
                    bool found = false;
                    foreach (PropertyInfo uP in user.GetType().GetProperties())
                    {
                        if (uP.PropertyType == typeof(int)) break;
                        else if (mP.Name == uP.Name)
                        {
                            bool mpv = (bool)mP.GetValue(_monkeys[m]);
                            bool upv = (bool)mP.GetValue(user);

                            if ((bool)mP.GetValue(_monkeys[m]) == (bool)uP.GetValue(user)) monkeyMatches[m]++;
                            found = true;
                        }
                        else if (found) break;

                    }
                }
                if (monkeyMatches[m] == 6) return _monkeyTypes[m];
            }
            
            return _monkeyTypes[Array.IndexOf(monkeyMatches, monkeyMatches.Max())];
        }
        public static string[] UserResults(Monkey user)
        {
            string[] results = new string[typeof(Monkey).GetProperties().Length];

            int i = 0;
            foreach (PropertyInfo uP in user.GetType().GetProperties())
            {
                if (uP.PropertyType == typeof(int)) 
                    results[i] = uP.Name + ": "+ ((int)uP.GetValue(user)) as string + "/5";
                else
                    results[i] = uP.Name + ": " + ((bool)uP.GetValue(user) ? "Yes" : "No") as string;
                i++;
            }
            return results;
        }
    }
}
