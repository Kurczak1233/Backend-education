using System;

namespace NSGA_III
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Calculate number reference points(H).
            //2. Generate initial population.
            //3. Realize non-dominated population sorting
            //4. Select P1 and P2
            //5. Crossover between P1 and P2
            //6. Realize non-dominated population sorting
            //7. Normalize the population members
            //8. Associate population with reference points
            //9. Apply the niche preservation
            //10. Keep niche obtained solutions for next generation
            //11. If iter>Iter_max (NO --> 4., YES -->12.)
            //12. Display results
            //13. Stop.

                    protected int iterations;
        protected int maxIterations;
        protected SolutionListEvaluator evaluator; //Klasa?
        protected int numberOfDivisions;
        protected List<ReferencePoint> referencePoints = new List<ReferencePoint>();

    }
    public class ReferencePoint
    {
        public List<double> position;
        private int memberSize;
        private List<ReferencePoint> potentialMembers;

        public ReferencePoint()
        {
        }

        public ReferencePoint(int size) //Generujemy po wymiarze macierzy?
        {
            position = new List<double>();
            for (int i = 0; i < size; i++)
            {
                position.Add(0.0);
            }
            memberSize = 0;
            potentialMembers = new List<ReferencePoint>();


        }
        public void generateReferencePoints(List<ReferencePoint> referencePoints, int numberOfObjectives,
         int numberOfDivisions)
        {
            ReferencePoint refPoint = new ReferencePoint(numberOfObjectives);
            generateRecursive(referencePoints, refPoint, numberOfObjectives, numberOfDivisions, numberOfDivisions, 0);
        }
        public void generateReferencePoints(
        List<ReferencePoint> referencePoints,
        int numberOfObjectives,
        int numberOfDivisions)
        {

            ReferencePoint refPoint = new ReferencePoint(numberOfObjectives);
            generateRecursive(referencePoints, refPoint, numberOfObjectives, numberOfDivisions, numberOfDivisions, 0);
        }

        private void generateRecursive(List<ReferencePoint> referencePoints, ReferencePoint refPoint,
                int numberOfObjectives, int left, int total, int element)
        {
            if (element == (numberOfObjectives - 1))
            {
                refPoint.position.set(element, (double)left / total);
                referencePoints.add(new ReferencePoint<>(refPoint));
            }
            else
            {
                for (int i = 0; i <= left; i += 1)
                {
                    refPoint.position.set(element, (double)i / total);

                    generateRecursive(referencePoints, refPoint, numberOfObjectives, left - i, total, element + 1);
                }
            }
        }
    }
}

