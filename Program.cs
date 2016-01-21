using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayIntersection
{
    class Program
    {
        //credit for this mergesort code goes to 
        //http://www.sanfoundry.com/csharp-program-merge-sort/

        static public void mergemethod(int [] numbers, int left, int mid, int right)
        {
            int [] temp = new int[500000];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
 
        }
        static public void sortmethod(int [] numbers, int left, int right)
        {
          int mid;
          if (right > left)
          {
            mid = (right + left) / 2;
            sortmethod(numbers, left, mid);
            sortmethod(numbers, (mid + 1), right);
            mergemethod(numbers, left, (mid+1), right);
 
          }
        }
        static void Main(string[] args)
        {
            int Min = 1;
            int Max = 50000;
            Random randNum = new Random();
            int[] a = Enumerable.Repeat(0, 500000).Select(t => randNum.Next(Min, Max)).ToArray();
            int[] b = Enumerable.Repeat(0, 500000).Select(t => randNum.Next(Min, Max)).ToArray();
            List<int> c = new List<int>();
            List<int> d = new List<int>();
            int length;
            int length2;
            int i = 0;
            int j = 0;

            sortmethod(a, 0, a.Length - 1);
            sortmethod(b, 0, b.Length - 1);

            
            length = a.Length;
            length2 = b.Length;
            while (i < length && j < length2)
            {
                if (a[i] > b[j])
                    j++;
                else if (a[i] < b[j])
                    i++;
                else
                {
                    if (c.Count == 0)
                        c.Add(a[i]);
                    else
                        if (a[i] != c.Last())
                            c.Add(a[i]);
                    i++;
                    j++;
                }


            }

            //This Tests the correctness of the intersection that my
            //algorithm has computed by comparing it against the result
            //of the c# Intersect function.
            d = a.Intersect(b).ToList();

            if(d.SequenceEqual(c)){
                Console.WriteLine("The algorithm has succeeded!");
            }
            else
            {
                Console.WriteLine("The algorithm has not worked as expected!");
            }
            
            

            
        }
    }
}
