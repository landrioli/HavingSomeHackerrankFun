﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    /*
        Given a sorted array of n distinct integers where each integer is in the range from 0 to m-1 and m > n. Find the smallest 
        number that is missing from the array.
        Examples
        Input: {0, 1, 2, 6, 9}, n = 5, m = 10
        Output: 3
        Input: {4, 5, 10, 11}, n = 4, m = 12
        Output: 0
        Input: {0, 1, 2, 3}, n = 4, m = 5
        Output: 4
        Input: {0, 1, 2, 3, 4, 5, 6, 7, 10}, n = 9, m = 11
        Output: 8
         */
    public static class FindSmallestIntSortedArray
    {
        /*
        Method 1 (Use Binary Search)
        For i = 0 to m-1, do binary search for i in the array. If i is not present in the array then return i.

        Time Complexity: O(m log n)

        Method 2 (Linear Search)
        If arr[0] is not 0, return 0. Otherwise traverse the input array starting from index 0, and for each pair of elements a[i] and a[i+1], find the difference between them. if the difference is greater than 1 then a[i]+1 is the missing number.

        Time Complexity: O(n)

        Method 3 (Use Modified Binary Search)
        Thanks to yasein and Jams for suggesting this method.
        In the standard Binary Search process, the element to be searched is compared with the middle element and on the basis of comparison result, we decide whether to search is over or to go to left half or right half.
        In this method, we modify the standard Binary Search algorithm to compare the middle element with its index and make decision on the basis of this comparison.

        …1) If the first element is not same as its index then return first index
        …2) Else get the middle index say mid
        …………a) If arr[mid] greater than mid then the required element lies in left half.
        …………b) Else the required element lies in right half.
        
             
       */
        // Utility function that puts all 
        // non-positive (0 and negative) 
        // numbers on left side of arr[] 
        // and return count of such numbers 
        static int segregate(int[] arr, int size)
        {
            int j = 0, i;
            for (i = 0; i < size; i++)
            {
                if (arr[i] <= 0)
                {
                    int temp;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    // increment count of non-positive 
                    // integers 
                    j++;
                }
            }

            return j;
        }

        // Find the smallest positive missing 
        // number in an array that contains 
        // all positive integers 
        static int findMissingPositive(int[] arr, int size)
        {
            int i;

            // Mark arr[i] as visited by making 
            // arr[arr[i] - 1] negative. Note that 
            // 1 is subtracted as index start from 
            // 0 and positive numbers start from 1 
            for (i = 0; i < size; i++)
            {
                if (Math.Abs(arr[i]) - 1 < size && arr[Math.Abs(arr[i]) - 1] > 0)
                    arr[Math.Abs(arr[i]) - 1] = -arr[Math.Abs(arr[i]) - 1];
            }

            // Return the first index value at 
            // which is positive 
            for (i = 0; i < size; i++)
                if (arr[i] > 0)
                    return i + 1;

            // 1 is added becuase indexes 
            // start from 0 
            return size + 1;
        }

        // Find the smallest positive 
        // missing number in array that 
        // contains both positive and 
        // negative integers 
        static int findMissing(int[] arr, int size)
        {

            // First separate positive and 
            // negative numbers 
            int shift = segregate(arr, size);
            int[] arr2 = new int[size - shift];
            int j = 0;

            for (int i = shift; i < size; i++)
            {
                arr2[j] = arr[i];
                j++;
            }

            // Shift the array and call 
            // findMissingPositive for 
            // positive part 
            return findMissingPositive(arr2, j);
        }
    }
}
