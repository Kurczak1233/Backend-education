using System;
using System.Collections.Generic;

namespace NSGA_III
{
    class Program
    {
        static void Main(string[] args)
        {

                    protected int iterations;
        protected int maxIterations;
        //protected SolutionListEvaluator evaluator; //Klasa?
        protected int numberOfDivisions;
        protected List<ReferencePoint> referencePoints = new List<ReferencePoint>();
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
        }
    }





    public class ReferencePoint
    {
        public List<double> position;
        private int memberSize;
        private List<ReferencePoint> potentialMembers;

        //Konstruktory
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
        public ReferencePoint(ReferencePoint point)
        {
            position = new List<double>(point.position.Count); // Count?
            foreach (var d in point.position)
            {
                position.Add(d);
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

        private void generateRecursive(List<ReferencePoint> referencePoints, ReferencePoint refPoint,
                int numberOfObjectives, int left, int total, int element)
        {
            if (element == (numberOfObjectives - 1))
            {
                refPoint.position[element] = ((double)left / total);
                referencePoints.Add(new ReferencePoint(refPoint));
            }
            else
            {
                for (int i = 0; i <= left; i += 1)
                {
                    refPoint.position[element] = ((double)i / total);

                    generateRecursive(referencePoints, refPoint, numberOfObjectives, left - i, total, element + 1);
                }
            }
        }
        public List<double> pos() { return position; }
        public int MemberSize() { return memberSize; }
        public bool HasPotentialMember() { return potentialMembers.Count > 0; }
        public void clear() { memberSize = 0; potentialMembers.Clear(); }
        public void AddMember() { memberSize++; }
        public void AddPotentialMember(ReferencePoint member_ind, double distance)
        {
            potentialMembers.Add(member_ind); //???
                                              //this.potentialMembers.add(new ImmutablePair<S, Double>(member_ind, distance)); Nie mam pojęcia jak to przetłumaczyć.
        }

        public void sort()
        {
            //???
            // this.potentialMembers.sort(Comparator.comparing(Pair < S, Double >::getRight).reversed());
        }

        //public ReferencePoint FindClosestMember(List<ReferencePoint> point)
        //{
        //    return potentialMembers.Remove(point[])
        //            .getLeft();
        //}???

        //public S RandomMember()
        //{
        //    int index = this.potentialMembers.size() > 1 ? JMetalRandom.getInstance().nextInt(0, this.potentialMembers.size() - 1) : 0;
        //    return this.potentialMembers.Remove(index).getLeft();
        //}
    }
}