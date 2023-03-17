using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
  
  
    public class FA1
    {
        State initial = new State()
        {
            Name = "initial";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State onesBeforeZero = new State()
        {
            Name = "onesBeforeZero";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State zeroWithoutOnes = new State()
        {
            Name = "zeroWithoutOnes";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State zeroAfterOnes = new State()
        {
            Name = "zeroAfterOnes";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = true;
        };
        State onesAfterZero = new State()
        {
            Name = "onesAfterZero";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = true;
        };
        State extraZeros = new State()
        {
            Name = "extraZeros";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };

        State InitialState = initial;

        public FA3()
        {
            initial.Transitions['0'] = zeroWithoutOnes;
            initial.Transitions['1'] = onesBeforeZero;
            onesBeforeZero.Transitions['0'] = zeroAfterOnes;
            onesBeforeZero.Transitions['1'] = onesBeforeZero;
            zeroWithoutOnes.Transitions['0'] = extraZeros;
            zeroWithoutOnes.Transitions['1'] = onesAfterZero;
            zeroAfterOnes.Transitions['0'] = extraZeros;
            zeroAfterOnes.Transitions['1'] = onesAfterZero;
            onesAfterZero.Transitions['0'] = extraZeros;
            onesAfterZero.Transitions['1'] = onesAfterZero;
            extraZeros.Transitions['0'] = extraZeros;
            extraZeros.Transitions['1'] = extraZeros;
        }
        public bool? Run(IEnumerable<char> s)
        {
            return false;
        }
    }
  
    public class FA2
    {
        State even0even1 = new State()
        {
            Name = "even0even1";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State odd0even1 = new State()
        {
            Name = "odd0even1";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State even0odd1 = new State()
        {
            Name = "even0odd1";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State odd0odd1 = new State()
        {
            Name = "odd0odd1";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = true;
        };

        State InitialState = even0even1;

        public FA3()
        {
            even0even1.Transitions['0'] = odd0even1;
            even0even1.Transitions['1'] = even0odd1;
            odd0even1.Transitions['0'] = even0even1;
            odd0even1.Transitions['1'] = odd0odd1;
            even0odd1.Transitions['0'] = odd0odd1;
            even0odd1.Transitions['1'] = even0even1;
            odd0odd1.Transitions['0'] = even0odd1;
            odd0odd1.Transitions['1'] = odd0even1;
        }
        public bool? Run(IEnumerable<char> s)
        {
            return false;
        }
    }
    
    public class FA3
    {
        State zeros = new State()
        {
            Name = "zeros";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State firstOne = new State()
        {
            Name = "firstOne";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = false;
        };
        State secondOne = new State()
        {
            Name = "secondOne";
            Transitions = new Dictionary<char, State>;
            IsAcceptState = true;
        };

        State InitialState = zeros;

        public FA3()
        {
            zeros.Transitions['0'] = zeros;
            zeros.Transitions['1'] = firstOne;
            firstOne.Transitions['0'] = zeros;
            firstOne.Transitions['1'] = secondOne;
            secondOne.Transitions['0'] = secondOne;
            secondOne.Transitions['1'] = secondOne;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}