using System;
using System.Threading;

namespace evolution
{
    class Program
    {
        public int AttemptCount { get; private set; }
        public int RejectionCount  { get; private set; }
        public void Start()
        {
            Organism org = new Organism();
            int[] terrain = Organism.CreateShape();
            double matchIndex;
            AttemptCount=0;
            RejectionCount = 0;
            do
            {
                matchIndex = org.GetMatchIndex(terrain);
                var origShape = org.Shape;
                int[] newShape = origShape.Clone() as int[];
                Reshape(newShape);
                AttemptCount++;
                var clone = new Organism(newShape);
                if(clone.GetMatchIndex(terrain)>matchIndex)
                {
                    org.Shape = origShape;
                    RejectionCount++;
                }
                else{
                    org = clone;
                }
                Thread.Sleep(50);
            }
            while(org.GetMatchIndex(terrain) > 5);

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
