using System;
using System.Collections.Generic;
using System.Threading;

namespace evolution
{
    class Program
    {
        public int AttemptCount { get; private set; }
        public int RejectionCount  { get; private set; }
        public int CurrentMatchIndex { get; private set; }
        public int MatchIndexThreshold { get; set; } = 5;
        public List<KeyValuePair<int,int>> history=new List<KeyValuePair<int,int>>();
        public void Start()
        {
            Organism org = new Organism();
            int[] terrain = Organism.CreateShape();
            AttemptCount=0;
            RejectionCount = 0;
            do
            {
                CurrentMatchIndex = org.GetMatchIndex(terrain);
                int[] newShape = org.Shape.Clone() as int[];
                Reshape(newShape);
                AttemptCount++;
                var clone = new Organism(newShape);
                if(clone.GetMatchIndex(terrain)>CurrentMatchIndex)
                {
                    RejectionCount++;
                }
                else
                {
                    org = clone;
                    history.Add(new KeyValuePair<int, int>(AttemptCount, CurrentMatchIndex));
                }
                Thread.Sleep(50);
            }
            while(org.GetMatchIndex(terrain) > MatchIndexThreshold);

            Console.WriteLine("{0} attempts, {1} rejections", AttemptCount, RejectionCount);
        }

        private static void Reshape(int[] newShape)
        {
            Random random = new Random();
            for (int j = 0; j < newShape.Length; j++)
            {
                var fact = random.NextDouble();
                int add = 0;
                if (fact > 0.666)
                {
                    add = 1;
                }
                else if (fact < 0.333)
                {
                    add = -1;
                }
                newShape[j] += add;
            }
        }
    }
}
