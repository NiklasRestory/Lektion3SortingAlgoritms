using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion3Sorts
{
    class Sorting
    {
        void swap(int[] array, int index_a, int index_b)
        {
            int temp = array[index_a];
            array[index_a] = array[index_b];
            array[index_b] = temp;
        }
        void selection_sort(int[] array/*, int if_we_have_a_list_length*/)
        {
            int length = array.Length;
            for(int i = 0; i < length - 1; i++)
            {
                //print_array(array);
                int min = i;
                for(int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                swap(array, i, min);
            }
            
        }

        public void print()
        {

        }

        void bubble_sort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                //print_array(array);
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if(array[j] > array[j+1])
                    {
                        swap(array, j, j+1);
                        sorted = false;
                    }
                }
                if (sorted == true)
                {
                    break;
                }
            }
        }

        void insertion_sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i; //j is our index moving backwards.

                while(j > 0 && array[j-1] > temp)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
        }

        void merge_sort(int[] array)
        {
            int length = array.Length;
            if (length < 2)
            {
                return;
            }
            int mid = length / 2;
            int[] left = new int[mid];
            int[] right = new int[length - mid];
            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            for (int i = mid; i < length; i++)
            {
                right[i - mid] = array[i];
            }
            merge_sort(left);
            merge_sort(right);
            merge(array, left, right);
        }

        void merge(int[] array, int[] left, int[] right)
        {
            int left_length = left.Length;
            int right_length = right.Length;
            int left_index = 0;
            int right_index = 0;
            int index = 0;

            while(left_index < left_length && right_index < right_length)
            {
                if (left[left_index] < right[right_index])
                {
                    array[index] = left[left_index];
                    left_index++;
                }
                else
                {
                    array[index] = right[right_index];
                    right_index++;
                }
                index++;
            }
            while(left_index < left_length)
            {
                array[index] = left[left_index];
                left_index++;
                index++;
            }
            while (right_index < right_length)
            {
                array[index] = right[right_index];
                right_index++;
                index++;
            }
        }

        void quick_sort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot_index = partition(array, start, end);
                quick_sort(array, start, pivot_index - 1);
                quick_sort(array, pivot_index + 1, end);
            }
        }

        int partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pivot_index = start;
            for (int i = start; i < end; i++)
            {
                if(array[i] < pivot)
                {
                    swap(array, i, pivot_index);
                    pivot_index++;
                }
            }
            swap(array, pivot_index, end);

            return pivot_index;
        }

        void print_array(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("");
        }

        void linear_search(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    Console.WriteLine("Linear: Value " + value + " found at index " + i + ".");
                    return;
                }
            }
            Console.WriteLine("Linear: Value " + value + " not found.");
        }

        void binary_search(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;
            int index = binary_search(array, low, high, value);

            if (index >= 0)
            {
                Console.WriteLine("Binary: Value " + value + " found at index " + index + ".");
                return;
            }
            Console.WriteLine("Binary: Value " + value + " not found.");
        }

        int binary_search(int[] array, int low, int high, int value)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = low + (high - low) / 2;
            if (array[mid] == value)
            {
                return mid;
            }
            else if (array[mid] > value)
            {
                return binary_search(array, low, mid-1, value);
            }
            return binary_search(array, mid + 1, high, value);
        }

        public Sorting()
        {
            int[] array = new int[] { 4, 11342, 4, 3, 314, 3, 67, 2, 89, 13, 56, 1, 8543, 3 };
            long start = Stopwatch.GetTimestamp();
            selection_sort(array);
            long end = Stopwatch.GetTimestamp();
            long time = end - start;
            print_array(array);
            Console.WriteLine("Selection Sort took {0} ticks.", time);

            array = new int[] { 4, 11342, 4, 3, 314, 3, 67, 2, 89, 13, 56, 1, 8543, 3 };
            start = Stopwatch.GetTimestamp();
            bubble_sort(array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            print_array(array);
            Console.WriteLine("Bubble Sort took {0} ticks.", time);

            array = new int[] { 4, 11342, 4, 3, 314, 3, 67, 2, 89, 13, 56, 1, 8543, 3 };
            start = Stopwatch.GetTimestamp();
            insertion_sort(array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            print_array(array);
            Console.WriteLine("Insertion Sort took {0} ticks.", time);

            array = new int[] { 4, 11342, 4, 3, 314, 3, 67, 2, 89, 13, 56, 1, 8543, 3 };
            start = Stopwatch.GetTimestamp();
            merge_sort(array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            print_array(array);
            Console.WriteLine("Merge Sort took {0} ticks.", time);

            array = new int[] { 4, 11342, 4, 3, 314, 3, 67, 2, 89, 13, 56, 1, 8543, 3 };
            start = Stopwatch.GetTimestamp();
            quick_sort(array, 0, array.Length - 1);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            print_array(array);
            Console.WriteLine("Quick Sort took {0} ticks.", time);


            int[] long_array = new int[10000];

            Random rnd = new Random();
            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next();
            }
            start = Stopwatch.GetTimestamp();
            selection_sort(long_array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            //print_array(long_array);
            Console.WriteLine("Selection Sort took {0} ticks.", time);

            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next();
            }
            start = Stopwatch.GetTimestamp();
            bubble_sort(long_array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            //print_array(long_array);
            Console.WriteLine("Bubble Sort took {0} ticks.", time);

            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next();
            }
            long_array[455] = 60;
            start = Stopwatch.GetTimestamp();
            insertion_sort(long_array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            //print_array(long_array);
            Console.WriteLine("Insertion Sort took {0} ticks.", time);

            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next();
            }
            long_array[455] = 60;
            start = Stopwatch.GetTimestamp();
            merge_sort(long_array);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            //print_array(long_array);
            Console.WriteLine("Merge Sort took {0} ticks.", time);

            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next();
            }
            start = Stopwatch.GetTimestamp();
            quick_sort(long_array, 0, long_array.Length - 1);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            //print_array(long_array);
            Console.WriteLine("Quick Sort took {0} ticks.", time);

            for (int j = 0; j < 10000; j++)
            {
                long_array[j] = rnd.Next(0, 10000);
            }
            long_array[455] = 6000;
            quick_sort(long_array, 0, long_array.Length - 1);
            // The above is just for the searches to find something.

            start = Stopwatch.GetTimestamp();
            linear_search(long_array, 6000);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            Console.WriteLine("Linear Search took {0} ticks.", time);

            start = Stopwatch.GetTimestamp();
            binary_search(long_array, 6000);
            end = Stopwatch.GetTimestamp();
            time = end - start;
            Console.WriteLine("Binary Search took {0} ticks.", time);




        }
    }
}
